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
using DTO.Enum.Material;

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

        public async Task<List<FlowerProfitRateDTO>> GetFlowerProfitRatesByIdAsync(string flowerId)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    return await context.FlowerSalesTargetHistories
                                        .Where(f => f.FlowerId == flowerId)
                                        .Join(context.FlowerSalesTargets,
                                              f => f.TargetId,
                                              fst => fst.TargetId,
                                              (f, fst) => new FlowerProfitRateDTO
                                              {
                                                  TargetId = f.TargetId,
                                                  FlowerId = f.FlowerId,
                                                  ExpectedQuantity = f.ExpectedQuantity,
                                                  ProfitRate = f.ProfitRate,
                                                  ApplyMonth = fst.ApplyMonth,
                                                  ApplyYear = fst.ApplyYear,
                                                  UsageStatus = fst.UsageStatus
                                              })
                                        .Where(i => i.UsageStatus == UsageStatus.Applying || i.UsageStatus == UsageStatus.ApplyingSoon)
                                        .ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateFlowerProfitRateAsync(string targetId, string flowerId, int expectedQuantity, decimal profitRate)
        {
            try
            {
                var flowerProfitRate = await _context.FlowerSalesTargetHistories.FirstOrDefaultAsync(f => f.TargetId == targetId && f.FlowerId == flowerId);

                if (flowerProfitRate != null)
                {
                    flowerProfitRate.ExpectedQuantity = expectedQuantity;
                    flowerProfitRate.ProfitRate = profitRate;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FlowerProfitRateDTO>> GetFlowerProfitRatesByMonthYearAsync(int applyMonth, int applyYear)
        {
            return await _context.FlowerSalesTargets
                                 .Where(fst => fst.ApplyMonth == applyMonth && fst.ApplyYear == applyYear)
                                 .Join(_context.FlowerSalesTargetHistories,
                                       fst => fst.TargetId,
                                       fsth => fsth.TargetId,
                                       (fst, fsth) => new FlowerProfitRateDTO
                                       {
                                           TargetId = fsth.TargetId,
                                           FlowerId = fsth.FlowerId,
                                           ExpectedQuantity = fsth.ExpectedQuantity,
                                           ProfitRate = fsth.ProfitRate,
                                           ApplyMonth = fst.ApplyMonth,
                                           ApplyYear = fst.ApplyYear,
                                           UsageStatus = fst.UsageStatus
                                       })
                                 .ToListAsync();
        }

        public async Task AddNewFlowerProfitRateAsync(string targetId, string flowerId, int expectedQuantity, decimal profitRate, int applyMonth, int applyYear)
        {
            try
            {
                var newTarget = new FlowerSalesTarget
                {
                    TargetId = targetId,
                    ApplyMonth = applyMonth,
                    ApplyYear = applyYear,
                    UsageStatus = UsageStatus.ApplyingSoon
                };

                var newRecord = new FlowerSalesTargetHistory
                {
                    TargetId = targetId,
                    FlowerId = flowerId,
                    ExpectedQuantity = expectedQuantity,
                    ProfitRate = profitRate
                };

                _context.FlowerSalesTargets.Add(newTarget);
                _context.FlowerSalesTargetHistories.Add(newRecord);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
