using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
    public class CEOService
    {
        private readonly CEORepository _ceoRepository;

        public CEOService()
        {
            _ceoRepository = new CEORepository();
        }

        public (decimal totalExpense, decimal totalRevenue) GetExpenseAndRevenue(DateTime startDate, DateTime endDate)
        {
            try
            {
                var totalExpense = _ceoRepository.GetTotalExpense(startDate, endDate);
                var totalRevenue = _ceoRepository.GetTotalRevenue(startDate, endDate);
                return (totalExpense, totalRevenue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RevenueDataDTO> GetRevenueData(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _ceoRepository.GetRevenueData(startDate, endDate);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
