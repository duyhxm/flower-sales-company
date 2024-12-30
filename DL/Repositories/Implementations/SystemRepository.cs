using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Interfaces;
using DTO.Employee;
using DL.Models;
using DL.Mapping;
using AutoMapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using DTO;
using System.Diagnostics;

namespace DL.Repositories.Implementations
{
    public class SystemRepository : ISystemRepository
    {
        private static SystemRepository? _instance;
        private static readonly object _lock = new object();
        private FlowerSalesCompanyDbContext _context;
        private ServiceBusHost? _serviceBusHost = null;
        private readonly string connectionString = new ConfigurationManager().GetServiceBusConnectionString();

        public ServiceBusManager ServiceBusManager;
        public IMapper Mapper { get; private set; }

        private SystemRepository() 
        {
            try
            {
                _context = new FlowerSalesCompanyDbContext();
                ServiceBusManager = new ServiceBusManager(connectionString);
                _serviceBusHost = new ServiceBusHost(ServiceBusManager);
                Mapper = GetMapper();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SystemRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("SystemRepository is not initialized. Call Initialize() first.");
                }
                return _instance;
            }
        }

        public static void Initialize()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = new SystemRepository();
                }
            }
        }

        public IMapper GetMapper()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var mappingDirectory = Path.Combine(baseDirectory, "Mapping");
            var filePath = Path.Combine(mappingDirectory, "mappings.txt");

            try
            {
                return Mapping.MapperConfiguration.InitializeMapper(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserAccountDTO?> LoginAsync(UserAccountDTO userAccount)
        {
            UserAccount account = Mapper.Map<UserAccount>(userAccount);

            UserAccount? result = await _context.UserAccounts
        .Include(u => u.Employee)
        .SingleOrDefaultAsync(u => u.Username == account.Username && u.Password == account.Password);

            Debug.WriteLine("SystemRepository");

            if (result != null)
            {
                return Mapper.Map<UserAccountDTO>(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<LoginInformation?> GetExtraLoginInfo(UserAccountDTO userAccount)
        {
            try
            {
                var employee = _context.UserAccounts
                    .Where(u => u.Username == userAccount.Username && u.Password == userAccount.Password)
                    .Include(u => u.Employee);

                var extraInfo = await employee
                    .Join(_context.EmployeeJobTitles,
                          uc => uc.EmployeeId,
                          ejt => ejt.EmployeeId,
                          (uc, ejt) => new { ejt.JobTitleId })
                    .Join(_context.JobTitles,
                           ejt => ejt.JobTitleId,
                           jt => jt.JobTitleId,
                           (ejt, jt) => new { jt.JobTitleName, jt.JobTitleId, jt.FormId })
                    .Join(_context.Forms,
                           jt => jt.FormId,
                           f => f.FormId,
                           (jt, f) => new { f.FormName, jt.JobTitleName })
                    .Select(x => new
                    {
                        x.FormName,
                        x.JobTitleName
                    }).FirstOrDefaultAsync();

                if (extraInfo == null)
                {
                    return null;
                }

                var loginInformation = new LoginInformation
                {
                    AccessibleForm = extraInfo.FormName ?? string.Empty,
                    JobTitle = extraInfo.JobTitleName ?? string.Empty
                };

                if (userAccount.Employee?.WorkType == "part-time")
                {
                    var storeInfo = await employee
                        .Include(u => u.Employee!.Ptemployee)
                        .Join(_context.Stores,
                              uc => uc.Employee!.Ptemployee!.StoreId,
                              s => s.StoreId,
                              (uc, s) => new { s.StoreId, s.StoreName })
                        .FirstOrDefaultAsync();

                    if (storeInfo != null)
                    {
                        loginInformation.StoreID = storeInfo.StoreId;
                        loginInformation.StoreName = storeInfo.StoreName;
                    }
                }

                return loginInformation;
            }
            catch
            {
                throw;
            }
        }

        public void RunServiceBusHost(string topicName, string subscription)
        {
            if (_serviceBusHost != null)
            {
                _serviceBusHost.Start(topicName, subscription);
            }
        }

        public async Task StopServiceBusHost()
        {
            if (_serviceBusHost != null)
            {
                await _serviceBusHost.StopAsync();
            }
        }
    }
}
