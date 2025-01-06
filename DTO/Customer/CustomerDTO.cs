using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Customer
{
    public class CustomerDTO
    {
        public string CustomerId { get; set; } = null!;

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public string? FirstName { get; set; }

        public DateOnly? Birthday { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public string? CustomerAddress { get; set; }

        public string? CustomerType { get; set; }
    }
}
