using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO.Customer;
using AutoMapper;

namespace DL.Repositories.Implementations
{
    public class CustomerRepository
    {
        private IMapper _mapper;
        public CustomerRepository()
        {
            _mapper = SystemRepository.Instance.GetMapper();
        }

        private FlowerSalesCompanyDbContext CreateContext()
        {
            return new FlowerSalesCompanyDbContext();
        }
        public List<CustomerRankDTO> GetAllCustomerRanks()
        {
            try
            {
                List<CustomerRank> customerRanks;

                using (var context = CreateContext())
                {
                    customerRanks = context.CustomerRanks.ToList();
                }

                return _mapper.Map<List<CustomerRankDTO>>(customerRanks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string? GetLastestCustomerId()
        {
            using (var context = new FlowerSalesCompanyDbContext())
            {
                return context.Customers.OrderByDescending(c => c.CustomerId).FirstOrDefault()?.CustomerId;
            }
        }
    }
}
