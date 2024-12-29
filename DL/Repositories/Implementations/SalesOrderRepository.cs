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
            try
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
