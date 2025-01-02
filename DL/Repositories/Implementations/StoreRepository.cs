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
        public Task<List<StoreDTO>> GetAllStoresAsync(string criteria)
        {
            return null;
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


        public async Task<PlannedProductDTO?> GetPlannedProductForStoreAsync(DateTimeOffset plannedDateTime)
        {
            try
            {
                var result = await _context.ProductCreationPlanHistories
                                          .Where(i => i.PlannedDateTime == plannedDateTime && i.CreatedDateTime == null && i.PlanStatus == PlanStatus.Initialized)
                                          .Join(_context.Products,
                                          i => i.ProductId,
                                          p => p.ProductId,
                                          (i, p) => new PlannedProductDTO
                                          {
                                              PlannedDateTime = i.PlannedDateTime,
                                              ProductId = p.ProductId,
                                              ProductName = p.ProductName!,
                                              ImplementationDateTime = i.ImplementationDateTime,
                                              Quantity = i.NeededCreationQuantity
                                          }
                                          )
                                          .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProductCreationPlanStatusAsync(DateTimeOffset plannedDateTime, DateTimeOffset createdDateTime, string planStatus)
        {
            try
            {
                var productCreationPlan = await _context.ProductCreationPlanHistories
                    .FirstOrDefaultAsync(p => p.PlannedDateTime == plannedDateTime);

                if (productCreationPlan == null)
                {
                    throw new Exception($"Không tìm thấy sản phẩm nào ứng với PlannedDateTime: {plannedDateTime}");
                }

                productCreationPlan.CreatedDateTime = createdDateTime;
                productCreationPlan.PlanStatus = planStatus;

                _context.ProductCreationPlanHistories.Attach(productCreationPlan);
                _context.Entry(productCreationPlan).Property(p => p.CreatedDateTime).IsModified = true;
                _context.Entry(productCreationPlan).Property(p => p.PlanStatus).IsModified = true;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình cập nhật trạng thái tạo sản phẩm. Vui lòng thử lại hoặc liên hệ đến bộ phận kỹ thuật", ex);
            }
        }

        public async Task<List<PlannedProductDTO>?> GetPlannedProductsForStoreAsync(DateTimeOffset todayDateTime, string storeId)
        {
            try
            {
                var result = await _context.ProductCreationPlanHistories
            .Where(p => p.PlannedDateTime.Date == todayDateTime.Date
                        && p.StoreId == storeId
                        && p.CreatedDateTime == null
                        && p.PlanStatus == PlanStatus.Initialized)
            .Join(_context.Products,
                  p => p.ProductId,
                  pr => pr.ProductId,
                  (p, pr) => new PlannedProductDTO
                  {
                      PlannedDateTime = p.PlannedDateTime,
                      ProductId = pr.ProductId,
                      ProductName = pr.ProductName!,
                      ImplementationDateTime = p.ImplementationDateTime,
                      Quantity = p.NeededCreationQuantity
                  })
            .ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
