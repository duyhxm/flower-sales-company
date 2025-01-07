using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DL.Repositories.Implementations;
using DTO.Customer;
using DTO.SalesOrder;

namespace BL
{
    public class CustomerService
    {
        private CustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public List<CustomerRankDTO> GetAllCustomerRanks()
        {
            try
            {
                return _customerRepository.GetAllCustomerRanks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CustomerRankHistoryDTO>> GetCustomerRankHistoryByQuarterAsync(List<int> months, int year)
        {
            try
            {
                return await _customerRepository.GetCustomerRankHistoryByQuarterAsync(months, year);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SalesStatisticsDataDTO>> GetSalesDataByQuarterAsync(List<int> months, int year)
        {
            try
            {
                return await _customerRepository.GetSalesDataByQuarterAsync(months, year);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
