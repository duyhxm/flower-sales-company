using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Implementations;
using DTO.Store;
using DTO.SalesOrder;
using DTO;
using DL.Repositories.Interfaces;
using DTO.Material;

namespace BL
{
    public class StoreService
    {
        StoreRepository _storeRepository;

        public StoreService()
        {
            _storeRepository = new StoreRepository();
        }

        //Lấy vật liệu có trong cửa hàng
        public async Task<List<MaterialInventoryDTO>> GetMaterialInventoryByStoreAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetMaterialInventoryByStoreAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Lấy các product có trong kho của cửa hàng
        public async Task<List<ProductInventoryDTO>?> GetProductInventoryByStoreAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetProductInventoryByStoreAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update các product có trong kho của cửa hàng
        public async Task UpdateProductInventoryByStoreAsync
        (string storeId, Dictionary<string, Tuple<DateOnly, int>> usedProducts)
        {
            try
            {
                await _storeRepository.UpdateProductInventoryByStoreAsync(storeId, usedProducts);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PreSalesOrderDTO>> GetPreSalesOrderByStoreAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetPreSalesOrderByStoreAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ShippingInformationDTO?> GetShippingInfoByOrderIdAsync(string salesOrderId)
        {
            try
            {
                return await _storeRepository.GetShippingInfoByOrderIdAsync(salesOrderId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SalesOrderDTO>> GetSalesOrdersByStoreAsync(string storeId, DateTimeOffset date)
        {
            try
            {
                return await _storeRepository.GetSalesOrdersByStoreAsync(storeId, date);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProductCreationPlanStatusAsync(PlannedProductDTO plannedProduct, DateTimeOffset createdDateTime, string planStatus)
        {
            try
            {
                await _storeRepository.UpdateProductCreationPlanStatusAsync(plannedProduct, createdDateTime, planStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PlannedProductDTO>> GetPlannedProductsForStoreAsync(DateTime currentDate, string storeId, string planStatus)
        {
            try
            {
                return await _storeRepository.GetPlannedProductsForStoreAsync(currentDate, storeId, planStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FlowerDTO>> GetAllFlowerByStoreAsync(string storeId)
        {
            try
            {
                return await _storeRepository.GetAllFlowerByStoreAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RegionDTO>> GetAllRegionsAsync()
        {
            try
            {
                return await _storeRepository.GetAllRegionsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<StoreDTO>> GetAllStoresByRegionId(string? regionId)
        {
            if (regionId == null)
            {
                throw new ArgumentNullException($"RegionId không được phép null");
            }

            try
            {
                return await _storeRepository.GetAllStoresByRegionId(regionId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
