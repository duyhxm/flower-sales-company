using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DL.Repositories.Implementations;
using DTO.Customer;

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

        
    }
}
