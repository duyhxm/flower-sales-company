using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Enum;
using DTO.Enum.SalesOrder;

namespace DL.Repositories.Implementations
{
    public class CEORepository
    {
        public decimal GetTotalExpense(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    var expenses = context.OperatingExpenseHistories
                        .Where(e => (e.ReportingYear > startDate.Year || (e.ReportingYear == startDate.Year && e.ReportingMonth >= startDate.Month)) &&
                                    (e.ReportingYear < endDate.Year || (e.ReportingYear == endDate.Year && e.ReportingMonth <= endDate.Month)))
                        .ToList();

                    decimal totalExpense = 0;
                    for (var date = startDate; date <= endDate; date = date.AddMonths(1))
                    {
                        var expense = expenses.FirstOrDefault(e => e.ReportingYear == date.Year && e.ReportingMonth == date.Month);
                        totalExpense += expense?.TotalExpense ?? 0;
                    }

                    return totalExpense;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    return context.SalesOrders
                        .Where(o => o.CreatedDateTime >= startDate && o.CreatedDateTime <= endDate
                                 && o.OrderStatus == OrderStatus.Success)
                        .Sum(o => (decimal?)o.FinalPrice) ?? 0;
                }
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
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    return context.RevenueHistories
                        .Where(r => r.ReportingYear > startDate.Year ||
                                   (r.ReportingYear == startDate.Year && r.ReportingMonth >= startDate.Month) &&
                                   r.ReportingYear < endDate.Year ||
                                   (r.ReportingYear == endDate.Year && r.ReportingMonth <= endDate.Month))
                        .OrderBy(r => r.ReportingYear).ThenBy(r => r.ReportingMonth)
                        .Select(r => new RevenueDataDTO
                        {
                            ReportingYear = r.ReportingYear,
                            ReportingMonth = r.ReportingMonth,
                            ExpectedFlowerRevenue = r.ExpectedFlowerRevenue,
                            NetFlowerRevenue = r.NetFlowerRevenue,
                            NetSuppMaterialRevenue = r.NetSuppMaterialRevenue,
                            Date = new DateTime((int)(r.ReportingYear.GetValueOrDefault()), (int)(r.ReportingMonth.GetValueOrDefault()), 1)
                        })
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
