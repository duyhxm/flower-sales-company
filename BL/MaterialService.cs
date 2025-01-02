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

        public async Task<List<FlowerDTO>?> GetFlowerListAsync()
        {
            try
            {
                return await _materialRepository.GetFlowerListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MaterialDTO>?> GetAccessoryListAsync()
        {
            try
            {
               return await _materialRepository.GetAccessoryListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
