using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Implementations;
using DTO.Material;
using DTO;
using DTO.Store;

namespace BL
{
    public class MaterialService
    {
        MaterialRepository _materialRepository;

        public MaterialService()
        {
            _materialRepository = new MaterialRepository();
        }

        public async Task<List<MaterialDTO>> GetAllMaterials()
        {
            try
            {
                return await _materialRepository.GetAllMaterials();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FloralRepresentationDTO>> GetAllFRepresentationsAsync()
        {
            try
            {
                return await _materialRepository.GetAllFRepresentationsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FlowerDTO>> GetAllFlowersAsync()
        {
            try
            {
                return await _materialRepository.GetAllFlowersAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MaterialDTO>> GetAllAccessoriesAsync()
        {
            try
            {
               return await _materialRepository.GetAllAccessoriesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FlowerWithProfitRateDTO>> GetFlowerProfitRates()
        {
            return null;
        }

        public async Task<List<PurchaseOrderDTO>> GetAllPurchaseOrdersInStockAsync()
        {
            try
            {
                return await _materialRepository.GetAllPurchaseOrdersInStockAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<DetailedPurchaseOrderDTO>> GetDetailedPurchaseOrderByIdAsync(string purchaseOrderId)
        {
            try
            {
                return await _materialRepository.GetDetailedPurchaseOrderByIdAsync(purchaseOrderId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<bool, string>> DistributeMaterialsAsync(string purchaseOrderId, string storeId, DateTimeOffset distributedDateTime, int distributedQuantity, List<string> materialIds)
        {
            try
            {
                return await _materialRepository.DistributeMaterialsAsync(purchaseOrderId, storeId, distributedDateTime, distributedQuantity, materialIds);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
