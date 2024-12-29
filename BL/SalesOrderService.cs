using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.SalesOrder;
using DL.Repositories.Implementations;

namespace BL
{
    public class SalesOrderService
    {
        private SalesOrderRepository _salesOrderRepository;

        public SalesOrderService()
        {
            _salesOrderRepository = new SalesOrderRepository();
        }
        public async Task<DiscountInfo?> GetCustomerDiscountInfoAsync(string rankName, decimal basePrice)
        {
            try
            {
                return await _salesOrderRepository.GetCustomerDiscountInfoAsync(rankName, basePrice);
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
                return await _salesOrderRepository.GetOrderDiscountInfoAsync(basePrice);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SalesOrderDTO?> AddSalesOrderAsync(SalesOrderDTO salesOrder, List<UsedPromotionHistoryDTO> usedPromotions, ShippingInformationDTO? shippingInformation, DateTimeOffset? deliveryDatetime)
        {
            try
            {
                return await _salesOrderRepository.AddSalesOrderAsync(salesOrder, usedPromotions, shippingInformation, deliveryDatetime);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
