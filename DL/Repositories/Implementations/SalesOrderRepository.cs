using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Interfaces;
using DTO.SalesOrder;
using DL.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DTO.Enum;
using DTO.Enum.SalesOrder;

namespace DL.Repositories.Implementations
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private FlowerSalesCompanyDbContext _context;
        private IMapper _mapper;

        public SalesOrderRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
            _mapper = SystemRepository.Instance.GetMapper();
        }
     
        public async Task<DiscountInfo?> GetCustomerDiscountInfoAsync(string rankName, decimal basePrice)
        {
            try
            {
                return await _context.Database.SqlQuery<DiscountInfo>($"SELECT * FROM dbo.GetOptimalCustomerPromotion({rankName}, {basePrice})").FirstOrDefaultAsync();
                
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<DiscountInfo?> GetOrderDiscountInfoAsync(decimal basePrice)
        {
            try
            {
                return await _context.Database.SqlQuery<DiscountInfo>($"SELECT * FROM dbo.GetOptimalOrderPromotion({basePrice})").FirstOrDefaultAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<SalesOrderDTO?> AddSalesOrderAsync(SalesOrderDTO salesOrder, List<UsedPromotionHistoryDTO> usedPromotion, ShippingInformationDTO? shippingInformation, DateTimeOffset? deliveryDatetime)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Lấy SalesOrderId hiện tại
                string? currentSalesOrderId = GetLastestSalesOrderId();
                string newSalesOrderId = string.IsNullOrEmpty(currentSalesOrderId) ? "SO00000001" : GenerateId(currentSalesOrderId);

                // Mapping SalesOrderDTO to SalesOrder entity
                var newSalesOrder = _mapper.Map<SalesOrder>(salesOrder);
                newSalesOrder.SalesOrderId = newSalesOrderId;

                // Thêm SalesOrder vào context
                _context.SalesOrders.Add(newSalesOrder);

                // Kiểm tra và thêm UsedPromotionHistory
                if (usedPromotion != null && usedPromotion.Count > 0)
                {
                    foreach (var promo in usedPromotion)
                    {
                        var newUsedPromotionHistory = _mapper.Map<UsedPromotionHistory>(promo);
                        newUsedPromotionHistory.SalesOrderId = newSalesOrderId;
                        _context.UsedPromotionHistories.Add(newUsedPromotionHistory);
                    }
                }

                // Kiểm tra và thêm ShippingInformation
                if (shippingInformation != null)
                {
                    //Tạo id
                    string? currentShippingId = GetLastestShippingId();
                    string newShippingId = string.IsNullOrEmpty(currentShippingId) ? "SI00000001" : GenerateId(currentShippingId);


                    //Gán id mới vô biến input và map sang ShippingInformation
                    shippingInformation.ShippingId = newShippingId;
                    var newShippingInformation = _mapper.Map<ShippingInformation>(shippingInformation);
                    newShippingInformation.SalesOrderId = newSalesOrderId;

                    //Thêm mới một row
                    _context.ShippingInformations.Add(newShippingInformation);
                }

                // Kiểm tra OrderType và thêm vào bảng tương ứng
                if (salesOrder.OrderType == OrderType.PreSalesOrder)
                {
                    var newPreSalesOrder = new PreSalesOrder
                    {
                        PreSalesOrderId = newSalesOrderId,
                        DeliveryDateTime = deliveryDatetime
                    };
                    _context.PreSalesOrders.Add(newPreSalesOrder);
                }
                else if (salesOrder.OrderType == OrderType.ImmediateSalesOrder)
                {
                    var newImmediateSalesOrder = new ImmediateSalesOrder
                    {
                        IsalesOrderId = newSalesOrderId
                    };
                    _context.ImmediateSalesOrders.Add(newImmediateSalesOrder);
                }

                // Lưu các thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();

                // Trả về SalesOrderDTO đã thêm
                return salesOrder;
            }
            catch (Exception ex)
            {
                // Rollback transaction nếu có lỗi
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while adding the sales order", ex);
            }
        }

        private string? GetLastestShippingId()
        {
            try
            {
                return _context.ShippingInformations
                    .OrderByDescending(p => p.ShippingId)
                    .Select(p => p.ShippingId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string? GetLastestSalesOrderId()
        {
            try
            {
                return _context.SalesOrders
                    .OrderByDescending(p => p.SalesOrderId)
                    .Select(p => p.SalesOrderId)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GenerateId(string currentId)
        {
            int index = 0;
            while (index < currentId.Length && !char.IsDigit(currentId[index]))
            {
                index++;
            }

            StringBuilder letters = new StringBuilder(currentId.Substring(0, index));
            StringBuilder numbers = new StringBuilder(currentId.Substring(index));

            // Chuyển đổi phần số sang dạng số và cộng thêm 1
            int number;
            if (!int.TryParse(numbers.ToString(), out number))
            {
                throw new ArgumentException("Invalid number format in input string.");
            }

            number++;

            // Chuyển lại số thành chuỗi và ghép vào phần chữ
            StringBuilder newNumbers = new StringBuilder(number.ToString());
            while (newNumbers.Length < numbers.Length)
            {
                newNumbers.Insert(0, '0');
            }

            // Kiểm tra độ dài của chuỗi mới
            if (letters.Length + newNumbers.Length > currentId.Length)
            {
                throw new InvalidOperationException("Resulting string exceeds the original length.");
            }

            letters.Append(newNumbers);
            return letters.ToString();
        }


        //dùng để lấy danh sách sản phẩm của đơn hàng đặt trước để hiển thị trong PreorderListForm
        public async Task<List<dynamic>> GetProductsBySalesOrderIdAsync(string salesOrderId)
        {
            try
            {
                var products = await (from detailedOrder in _context.DetailedSalesOrders
                                      join product in _context.Products
                                      on detailedOrder.ProductId equals product.ProductId
                                      join floralRepresentation in _context.FloralRepresentations
                                      on product.FrepresentationId equals floralRepresentation.FrepresentationId
                                      where detailedOrder.SalesOrderId == salesOrderId
                                      select new
                                      {
                                          ProductId = product.ProductId,
                                          ProductName = product.ProductName,
                                          RepresentationName = floralRepresentation.Frname,
                                          Quantity = detailedOrder.Quantity ?? 0
                                      }).ToListAsync();

                return products.Cast<dynamic>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products by sales order ID", ex);
            }
        }

        //dùng khi mà user thay đổi trạng thái của đơn hàng đặt trước
        public async Task UpdateOrderStatusAsync(string salesOrderId, string orderStatus)
        {
            try
            {
                var salesOrder = await _context.SalesOrders.FindAsync(salesOrderId);
                if (salesOrder != null)
                {
                    salesOrder.OrderStatus = orderStatus;
                    _context.Entry(salesOrder).Property(s => s.OrderStatus).IsModified = true;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the order status", ex);
            }
        }


        public async Task UpdateShippingInfoAsync(ShippingInformationDTO shippingInfo)
        {
            try
            {
                ShippingInformation si = _mapper.Map<ShippingInformation>(shippingInfo);
                _context.ShippingInformations.Update(si);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ShippingCompanyDTO>> LoadShippingCompaniesAsync()
        {
            try
            {
                var shippingCompanies = await _context.ShippingCompanies.ToListAsync();

                return _mapper.Map<List<ShippingCompanyDTO>>(shippingCompanies);
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi trong quá trình lấy thông tin các công ty vận chuyển", ex);
            }
        }
    }
}
