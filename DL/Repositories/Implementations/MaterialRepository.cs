using AutoMapper;
using DL.Models;
using DL.Repositories.Interfaces;
using DTO;
using DTO.Material;
using Microsoft.EntityFrameworkCore;
using DTO.Enum;
using DTO.Enum.SalesOrder;
using System.Globalization;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DL.Repositories.Implementations
{
    public class MaterialRepository : IMaterialRepository
    {
        private FlowerSalesCompanyDbContext _context;
        private IMapper _mapper;

        public MaterialRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
            SystemRepository.Initialize();
            _mapper = SystemRepository.Instance.Mapper;
        }

        public void Add(MaterialDTO material)
        {
            try
            {
                Material convertedMaterial = _mapper.Map<Material>(material);
                _context.Materials.Add(convertedMaterial);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(MaterialDTO material)
        {
            try
            {
                Material convertedMaterial = _mapper.Map<Material>(material);
                _context.Materials.Update(convertedMaterial);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(MaterialDTO material)
        {
            try
            {
                Material convertedMaterial = _mapper.Map<Material>(material);
                _context.Materials.Remove(convertedMaterial);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Các hàm trên chưa sử dụng tới

        public async Task<List<MaterialDTO>> GetAllMaterials()
        {
            try
            {
                List<Material> materials = await _context.Materials.ToListAsync();
                return _mapper.Map<List<MaterialDTO>>(materials);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy ra danh sách toàn bộ phụ liệu có trong công ty
        public async Task<List<MaterialDTO>> GetAllAccessoriesAsync()
        {
            try
            {
                
                return await _context.Database.SqlQuery<MaterialDTO>($"SELECT * FROM dbo.GetAllAccessories()").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy ra danh sách toàn bộ hoa có trong công ty
        public async Task<List<FlowerDTO>> GetAllFlowersAsync()
        {
            try
            {
                return await _context.Database.SqlQuery<FlowerDTO>($"SELECT * FROM dbo.GetAllFlowers()").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy danh sách toàn bộ hình thức sản phẩm
        public async Task<List<FloralRepresentationDTO>> GetAllFRepresentationsAsync()
        {
            try
            {
                List<FloralRepresentation> result = await _context.FloralRepresentations.ToListAsync();

                return _mapper.Map<List<FloralRepresentationDTO>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PurchaseOrderDTO>> GetAllPurchaseOrdersInStockAsync()
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    var purchaseOrders = await context.PurchaseOrders
                .Where(po => po.DistributionStatus == DistributionStatus.HaveNotDistributed
                          || po.DistributionStatus == DistributionStatus.Distributing)
                .ToListAsync();

                    var purchaseOrderDTOs = purchaseOrders.Select(po => new PurchaseOrderDTO
                    {
                        PurchaseOrderId = po.PurchaseOrderId,
                        VendorId = po.VendorId,
                        OrderType = po.OrderType,
                        PurchasedDateTime = po.PurchasedDateTime,
                        TotalCost = po.TotalCost,
                        DistributionStatus = po.DistributionStatus,
                        PurchasedDateTimeFormatted = po.PurchasedDateTime.HasValue ? po.PurchasedDateTime.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty
                    }).ToList();

                    return purchaseOrderDTOs;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DetailedPurchaseOrderDTO>> GetDetailedPurchaseOrderByIdAsync(string purchaseOrderId)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    List<DetailedPurchaseOrder> detailedPurchaseOrder = await context.DetailedPurchaseOrders
                            .Where(dpo => dpo.PurchaseOrderId == purchaseOrderId)
                            .ToListAsync();

                    return _mapper.Map<List<DetailedPurchaseOrderDTO>>(detailedPurchaseOrder);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<bool, string>> DistributeMaterialsAsync(string purchaseOrderId, string storeId, DateTimeOffset distributedDateTime, int distributedQuantity, List<string> materialIds)
        {
            try
            {
                bool isFullyDistributed = false;
                string message = string.Empty;

                using (var context = new FlowerSalesCompanyDbContext())
                {
                    foreach (string materialId in materialIds)
                    {
                        //Gọi stored procedure để thêm vật liệu phân phối
                        await context.Database.ExecuteSqlInterpolatedAsync($@"
                    EXEC [dbo].[AddGoodsDistribution] 
                    @PurchaseOrderID = {purchaseOrderId}, 
                    @StoreID = {storeId}, 
                    @MaterialID = {materialId}, 
                    @DistributedQuantity = {distributedQuantity},
                    @DistributedDate = {distributedDateTime}");

                        //Gọi tiếp stored procedure khác để kiểm tra xem đơn hàng nhập đã phân phối đủ hay chưa
                        var isFullyDistributedParam = new SqlParameter
                        {
                            ParameterName = "@IsFullyDistributed",
                            SqlDbType = SqlDbType.Bit,
                            Direction = ParameterDirection.Output
                        };

                        await context.Database.ExecuteSqlInterpolatedAsync($@"
                    EXEC [dbo].[CheckAndUpdateDistributionStatus] 
                    @PurchaseOrderID = {purchaseOrderId}, 
                    @IsFullyDistributed = {isFullyDistributedParam} OUTPUT");

                        //Kiểm tra giá trị output trả về
                        isFullyDistributed = (bool)isFullyDistributedParam.Value;
                        if (isFullyDistributed)
                        {
                            message = $"Đơn hàng nhập đã được phân phối đủ. Các vật liệu còn dư: {string.Join(", ", materialIds)}";
                        }
                    }
                }
                return new Dictionary<bool, string>() { { isFullyDistributed, message } };
            }
            catch (Exception ex)
            {
                throw new Exception($"Đã xảy ra lỗi trong quá trình phân phối vật liệu: {ex.Message}", ex);
            }
        }
    }
}
