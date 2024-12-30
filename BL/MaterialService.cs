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

        //hàm này đặt sai vị trí, cần phải chuyển vô store service
        public async Task<List<FlowerDTO>?> GetAllFlowerByStoreAsync(string storeId)
        {
            try
            {
                return await _materialRepository.GetAllFlowerByStoreAsync(storeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<AccessoryDTO>> GetAccessoryListAsync(string criteria)
        {
            try
            {
                return await new MaterialRepository().GetAllAccessoryAsync(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FloralRepresentationDTO>?> GetFloralRepresentationAsync()
        {
            try
            {
                return await _materialRepository.GetFloralRepresentationAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FlowerDTO>> GetFlowerInventoryAsync()
        {
            try
            {
                return await _materialRepository.GetFlowerInventoryAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MaterialInventoryDTO>?> GetMaterialInventoryAsync()
        {
            try
            {
               return await _materialRepository.GetMaterialInventoryAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
