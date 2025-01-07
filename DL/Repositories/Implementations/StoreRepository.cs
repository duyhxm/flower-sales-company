using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO;
using DL.Repositories.Interfaces;
using DTO.Store;
using DTO.Material;
using Microsoft.EntityFrameworkCore;
using DTO.SalesOrder;
using DTO.Enum.SalesOrder;
using AutoMapper;
using DTO.Enum;

namespace DL.Repositories.Implementations
{
    public class StoreRepository : IStoreRepository
    {
        private FlowerSalesCompanyDbContext _context;
        private IMapper _mapper;

        public StoreRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
            _mapper = SystemRepository.Instance.GetMapper();
        }
        public int AddStore(StoreDTO store)
        {
            return 1;
        }
        //Read
        public async Task<List<StoreDTO>?> GetAllStoresAsync()
        {
            List<Store>? stores = await _context.Stores.ToListAsync();

            return _mapper.Map<List<StoreDTO>>(stores);
        }

        //Update
        public int UpdateStore(StoreDTO store)
        {
            return 1;
        }
        //Delete
        public int DeleteStore(StoreDTO store)
        {
            return 1;
            
        }

        //Các method trên hiện tại chưa dùng đến

        public async Task<List<MaterialInventoryDTO>> GetMaterialInventoryByStoreAsync(string storeId)
        {
            try
            {
                //Hàm này sẽ lấy toàn bộ các material của cửa hàng có trong bảng MaterialInventory
                return await _context.Database.SqlQuery<MaterialInventoryDTO>($"SELECT * FROM dbo.GetMaterialInventory({storeId})").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductInventoryDTO>?> GetProductInventoryByStoreAsync(string storeId)
        {
            try
            {
                return await _context.Database.SqlQuery<ProductInventoryDTO>($"SELECT * FROM dbo.GetProductStockDetails({storeId})").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProductInventoryByStoreAsync(string storeId, Dictionary<string, Tuple<DateOnly, int>> usedProducts)
        {
            try
            {
                foreach (var product in usedProducts)
                {
                    var productId = product.Key;
                    var stockDate = product.Value.Item1;
                    var usedQuantity = product.Value.Item2;

                    var productInventory = await _context.ProductInventories
                        .FirstOrDefaultAsync(pi => pi.StoreId == storeId && pi.ProductId == productId && pi.StockDate == stockDate);

                    if (productInventory == null)
                    {
                        throw new Exception($"Product inventory not found for StoreId: {storeId}, ProductId: {productId}, StockDate: {stockDate}");
                    }

                    if (productInventory.StockProductQuantity < usedQuantity)
                    {
                        throw new Exception($"Insufficient stock for ProductId: {productId} on StockDate: {stockDate}");
                    }

                    productInventory.StockProductQuantity -= usedQuantity;

                    _context.ProductInventories.Attach(productInventory);
                    _context.Entry(productInventory).Property(pi => pi.StockProductQuantity).IsModified = true;
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating product inventory", ex);
            }
        }

        public async Task<List<PreSalesOrderDTO>> GetPreSalesOrderByStoreAsync(string storeId)
        {
            try
            {
                var preSalesOrders = await (from salesOrder in _context.SalesOrders
                                            join preSalesOrder in _context.PreSalesOrders
                                            on salesOrder.SalesOrderId equals preSalesOrder.PreSalesOrderId
                                            where salesOrder.StoreId == storeId
                                            && salesOrder.OrderType == OrderType.PreSalesOrder
                                            select new PreSalesOrderDTO
                                            {
                                                SalesOrderId = salesOrder.SalesOrderId,
                                                DeliveryDateTime = preSalesOrder.DeliveryDateTime ?? DateTimeOffset.MinValue,
                                                OrderStatus = salesOrder.OrderStatus,
                                                FinalPrice = salesOrder.FinalPrice ?? 0
                                            }).ToListAsync();

                return preSalesOrders;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy danh sách các đơn hàng trong ngày, hoặc các đơn hàng chưa xử lý xong của cửa hàng
        public async Task<List<SalesOrderDTO>> GetSalesOrdersByStoreAsync(string storeId, DateTimeOffset date)
        {
            try
            {
                var salesOrders = await _context.SalesOrders
                                        .Where(so => so.StoreId == storeId && (so.CreatedDateTime!.Value.Date == date.Date || (so.CreatedDateTime!.Value.Date != date.Date && so.OrderStatus == OrderStatus.Confirmed)))
                                        .ToListAsync();
                var result = _mapper.Map<List<SalesOrderDTO>>(salesOrders);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ShippingInformationDTO?> GetShippingInfoByOrderIdAsync(string salesOrderId)
        {
            try
            {
                var shippingInfo = await _context.ShippingInformations
                                    .Where(si => si.SalesOrderId == salesOrderId).FirstOrDefaultAsync();

                return _mapper.Map<ShippingInformationDTO>(shippingInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task UpdateProductCreationPlanStatusAsync(PlannedProductDTO plannedProduct, DateTimeOffset createdDateTime, string planStatus)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    var productCreationPlan = await context.ProductCreationPlanHistories
                        .FirstOrDefaultAsync(p => p.PlannedDateTime == plannedProduct.PlannedDateTime && p.StoreId == plannedProduct.StoreId && p.ProductId == plannedProduct.ProductId);

                    if (productCreationPlan == null)
                    {
                        throw new Exception($"Không tìm thấy kế hoạch nào ứng với \n PlannedDateTime: {plannedProduct.PlannedDateTime} \n StoreId: {plannedProduct.StoreId} \n ProductId: {plannedProduct.ProductId}");
                    }

                    productCreationPlan.CreatedDateTime = createdDateTime;
                    productCreationPlan.PlanStatus = planStatus;

                    context.ProductCreationPlanHistories.Attach(productCreationPlan);
                    context.Entry(productCreationPlan).Property(p => p.CreatedDateTime).IsModified = true;
                    context.Entry(productCreationPlan).Property(p => p.PlanStatus).IsModified = true;

                    await context.SaveChangesAsync();
                } 
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình cập nhật trạng thái tạo sản phẩm. Vui lòng thử lại hoặc liên hệ đến bộ phận kỹ thuật", ex);
            }
        }

        public async Task<List<PlannedProductDTO>> GetPlannedProductsForStoreAsync(DateTime currentDate, string storeId, string planStatus)
        {
            try
            {
                var result = await _context.ProductCreationPlanHistories
            .Where(p => p.ImplementationDateTime.Date == currentDate.Date
                        && p.StoreId == storeId
                        && p.PlanStatus == planStatus)
            .Join(_context.Products,
                  p => p.ProductId,
                  pr => pr.ProductId,
                  (p, pr) => new 
                  {
                      p.PlannedDateTime,
                      pr.ProductId,
                      p.StoreId,
                      pr.FrepresentationId,
                      pr.ProductName,
                      p.ImplementationDateTime,
                      p.NeededCreationQuantity,
                  })
            .Join(_context.FloralRepresentations,
            combined => combined.FrepresentationId,
            fr => fr.FrepresentationId,
            (combined, fr) =>  new PlannedProductDTO{
                PlannedDateTime = combined.PlannedDateTime,
                ProductId = combined.ProductId,
                StoreId = combined.StoreId,
                FRName = fr.Frname!,
                ProductName = combined.ProductName!,
                ImplementationDateTime = combined.ImplementationDateTime,
                Quantity = combined.NeededCreationQuantity,
                ImplementationDateTimeFormatted = combined.ImplementationDateTime.ToString("dd/MM/yyyy HH:mm")
            }
            )
            .ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FlowerDTO>> GetAllFlowerByStoreAsync(string storeId)
        {
            try
            {
                //Hàm này sẽ chỉ trả về các flower có số lượng >0 trong bảng MaterialInventory tương ứng với cửa hàng
                var flowerList = await _context.Database.SqlQuery<FlowerDTO>($"SELECT * FROM dbo.GetAllFlowerByStore({storeId})").ToListAsync();

                return flowerList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RegionDTO>> GetAllRegionsAsync()
        {
            try
            {
                List<Region> regions = await _context.Regions.ToListAsync();

                return _mapper.Map<List<RegionDTO>>(regions); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<StoreDTO>> GetAllStoresByRegionId(string regionId)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    List<Store> stores = await context.Stores
                                                .Where(s => s.RegionId == regionId)
                                                .ToListAsync();

                    return _mapper.Map<List<StoreDTO>>(stores);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
