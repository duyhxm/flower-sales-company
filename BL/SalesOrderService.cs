using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.SalesOrder;
using DL.Repositories.Implementations;
using DL.Models;
using DTO.Enum.SalesOrder;

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

        public async Task<List<dynamic>> GetProductsBySalesOrderIdAsync(string salesOrderId)
        {
            try
            {
                return await _salesOrderRepository.GetProductsBySalesOrderIdAsync(salesOrderId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateOrderStatusAsync(string salesOrderId, string orderStatus)
        {
            try
            {
                await _salesOrderRepository.UpdateOrderStatusAsync(salesOrderId, orderStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateShippingInfoAsync(ShippingInformationDTO shippingInfo)
        {
            try
            {
                await _salesOrderRepository.UpdateShippingInfoAsync(shippingInfo);
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
                return await _salesOrderRepository.LoadShippingCompaniesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
