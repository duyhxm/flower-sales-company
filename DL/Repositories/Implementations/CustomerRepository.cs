using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO.Customer;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DTO.SalesOrder;

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

        public async Task<List<CustomerRankHistoryDTO>> GetCustomerRankHistoryByQuarterAsync(List<int> months, int year)
        {
            try
            {
                var minMonth = months.Min();
                var maxMonth = months.Max();

                using (var context = new FlowerSalesCompanyDbContext())
                {
                    List<CustomerRankHistoryDTO> result = await context.CustomerRankHistories
                            .Join(context.RankingCycles,
                                crh => crh.RankingCycleId,
                                rc => rc.RankingCycleId,
                                (crh, rc) => new
                                {
                                    StartDate = rc.StartDateTime.Value.Date,
                                    EndDate = rc.EndDateTime.Value.Date,
                                    crh.CustomerId,
                                    crh.TotalSpending,
                                    crh.CustomerRankId,
                                    rc.RankingCycleId
                                })
                            .Where(i => i.StartDate.Year == year
                                        && i.EndDate.Year == year
                                        && i.StartDate.Month == minMonth
                                        && i.EndDate.Month == maxMonth)
                            .Join(context.Customers,
                                crh => crh.CustomerId,
                                c => c.CustomerId,
                                (crh, c) => new
                                {
                                    crh.CustomerId,
                                    CustomerName = c.LastName + " " + c.MiddleName + " " + c.FirstName,
                                    crh.TotalSpending,
                                    crh.CustomerRankId
                                })
                            .Join(context.CustomerRanks,
                                crh => crh.CustomerRankId,
                                cr => cr.CustomerRankId,
                                (crh, cr) => new CustomerRankHistoryDTO
                                {
                                    CustomerId = crh.CustomerId,
                                    CustomerName = crh.CustomerName,
                                    TotalSpending = crh.TotalSpending,
                                    RankName = cr.RankName
                                })
                            .ToListAsync();
                    return result;
                }  
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
                using (var context = new FlowerSalesCompanyDbContext())
                {
                    var salesData = await context.SalesOrders
                                                .Where(so => months.Contains(so.CreatedDateTime.Value.Month) && so.CreatedDateTime.Value.Year == year)
                                                .GroupBy(so => new
                                                {
                                                    Year = so.CreatedDateTime.Value.Year,
                                                    Month = so.CreatedDateTime.Value.Month
                                                })
                                                .ToListAsync(); // Fetch data from the database first

                    var result = salesData
                                .AsEnumerable() // Switch to client-side evaluation
                                .Select(g => new SalesStatisticsDataDTO
                                {
                                    YearMonth = new DateTime(g.Key.Year, g.Key.Month, 1),
                                    TotalRevenue = g.Sum(so => so.FinalPrice ?? 0),
                                    CustomerCount = g.Select(so => so.CustomerId).Distinct().Count(),
                                })
                                .OrderBy(g => g.YearMonth)
                                .ToList();

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
