using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Employee;
using DL.Repositories.Implementations;
using DTO;
using System.Diagnostics;

namespace BL
{
    public class SystemService
    {
        private static SystemService? _instance;
        private static readonly object _lock = new object();
        SystemRepository _systemRepository;

        private SystemService()
        {
            SystemRepository.Initialize();
            _systemRepository = SystemRepository.Instance;
        }

        public static SystemService Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("SystemService chưa được khởi tạo. Gọi Initialize() trước tiên.");
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
                    _instance = new SystemService();
                }
            }
        }

        public async Task<UserAccountDTO?> LoginAsync(UserAccountDTO userAccount)
        {
            try
            {
                return await _systemRepository.LoginAsync(userAccount);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<LoginInformation?> GetExtraLoginInfo(UserAccountDTO userAccount)
        {
            try
            {
                return await _systemRepository.GetExtraLoginInfo(userAccount);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RunServiceBusHost(string topicName, string subscription)
        {
            try
            {
                _systemRepository.RunServiceBusHost(topicName, subscription);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task StopServiceBusHost()
        {
            await _systemRepository.StopServiceBusHost();
        }
    }
}
