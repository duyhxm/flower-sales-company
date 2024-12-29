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
                return await _context.Database.SqlQuery<DiscountInfo>($"SELECT * FROM dbo.fnGetOptimalCustomerPromotion({rankName}, {basePrice})").FirstOrDefaultAsync();
                
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
                return await _context.Database.SqlQuery<DiscountInfo>($"SELECT * FROM dbo.fnGetOptimalOrderPromotion({basePrice})").FirstOrDefaultAsync();
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
                string? currentId = GetLastestSalesOrderId();
                string newSalesOrderId = string.IsNullOrEmpty(currentId) ? "SO00000001" : GenerateId(currentId);

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
                    var newShippingInformation = _mapper.Map<ShippingInformation>(shippingInformation);
                    newShippingInformation.SalesOrderId = newSalesOrderId;
                    _context.ShippingInformations.Add(newShippingInformation);
                }

                // Kiểm tra OrderType và thêm vào bảng tương ứng
                if (salesOrder.OrderType == "đặt trước")
                {
                    var newPreSalesOrder = new PreSalesOrder
                    {
                        PreSalesOrderId = newSalesOrderId,
                        DeliveryDateTime = deliveryDatetime
                    };
                    _context.PreSalesOrders.Add(newPreSalesOrder);
                }
                else if (salesOrder.OrderType == "lấy ngay")
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

        public string? GetLastestSalesOrderId()
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

        public string GenerateId(string currentId)
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
    }
}
