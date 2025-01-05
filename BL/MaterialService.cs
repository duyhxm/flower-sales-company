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

        public async Task<List<MaterialDTO>?> GetAllAccessoriesAsync()
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


        /*Method này được sử dụng trước đó ở MaterialAdjustmentForm. Tuy nhiên, hiện tại tạm thời không được sử dụng do đã có method thay thế phía trên là GetAllFlowersAsync*/

        //public async Task<List<FlowerDTO>?> GetFlowerInventoryAsync()
        //{
        //    try
        //    {
        //        return await _materialRepository.GetFlowerInventoryAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        /*Method này được sử dụng trước đó trong MaterialAdjustmentForm. Tuy nhiên, hiện tại tạm thời không được sử dụng nữa do đã có method thay thế phía trên là GetAllAccessoriesAsync*/

        //public async Task<List<MaterialDTO>?> GetMaterialInventoryAsync()
        //{
        //    try
        //    {
        //        return await _materialRepository.GetMaterialInventoryAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<List<FlowerWithProfitRateDTO>> GetFlowerProfitRates()
        {
            return null;
        }

    }
}
