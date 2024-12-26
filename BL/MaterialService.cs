using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Repositories.Implementations;
using DTO.Material;
using DTO;

namespace BL
{
    public class MaterialService
    {
        MaterialRepository _materialRepository;

        public MaterialService()
        {
            _materialRepository = new MaterialRepository();
        }

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

        public async Task<List<MaterialInventoryDTO>> GetAllMaterialByStoreAsync(string storeId, string materialType = "both")
        {
            try
            {
                if (materialType != "phụ liệu" && materialType != "hoa")
                {
                    throw new InvalidOperationException("Loại vật liệu không tồn tại");
                }

                return await _materialRepository.GetAllMaterialByStoreAsync(storeId, materialType);
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

    }
}
