using AutoMapper;
using DL.Models;
using DL.Repositories.Interfaces;
using DTO;
using DTO.Material;
using Microsoft.EntityFrameworkCore;
using DTO.Store;

namespace DL.Repositories.Implementations
{
    public class MaterialRepository : IMaterialRepository
    {
        private FlowerSalesCompanyDbContext _context;
        private IMapper _mapper;

        public MaterialRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
            SystemRepository.Initialize();
            _mapper = SystemRepository.Instance.Mapper;
        }

        public void Add(MaterialDTO material)
        {
            try
            {
                Material convertedMaterial = _mapper.Map<Material>(material);
                _context.Materials.Add(convertedMaterial);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(MaterialDTO material)
        {
            try
            {
                Material convertedMaterial = _mapper.Map<Material>(material);
                _context.Materials.Update(convertedMaterial);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(MaterialDTO material)
        {
            try
            {
                Material convertedMaterial = _mapper.Map<Material>(material);
                _context.Materials.Remove(convertedMaterial);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Các hàm trên chưa sử dụng tới

        public async Task<List<MaterialDTO>> GetAllMaterials()
        {
            try
            {
                List<Material> materials = await _context.Materials.ToListAsync();
                return _mapper.Map<List<MaterialDTO>>(materials);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy ra danh sách toàn bộ phụ liệu có trong công ty
        public async Task<List<MaterialDTO>?> GetAllAccessoriesAsync()
        {
            try
            {
                
                return await _context.Database.SqlQuery<MaterialDTO>($"SELECT * FROM dbo.GetAllAccessories()").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy ra danh sách toàn bộ hoa có trong công ty
        public async Task<List<FlowerDTO>> GetAllFlowersAsync()
        {
            try
            {
                return await _context.Database.SqlQuery<FlowerDTO>($"SELECT * FROM dbo.GetAllFlowers()").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy danh sách toàn bộ hình thức sản phẩm
        public async Task<List<FloralRepresentationDTO>> GetAllFRepresentationsAsync()
        {
            try
            {
                List<FloralRepresentation> result = await _context.FloralRepresentations.ToListAsync();

                return _mapper.Map<List<FloralRepresentationDTO>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*Method này tạm thời không được sử dụng do đã có method thay thế phía trên là GetAllFlowersAsync*/

        //public async Task<List<FlowerDTO>?> GetFlowerInventoryAsync()
        //{
        //    try
        //    {
        //        var flowerList = await _context.Database.SqlQuery<FlowerDTO>($"SELECT * FROM GetAllFlowers()").ToListAsync();

        //        return flowerList;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        /*Method này tạm thời không được sử dụng do đã có method thay thế phía trên là GetAllAccessoriesAsync*/

        //public async Task<List<MaterialDTO>?> GetMaterialInventoryAsync()
        //{
        //    try
        //    {
        //        // Create a new DbContext instance for this async operation
        //        using (var context = new FlowerSalesCompanyDbContext())
        //        {
        //            var flowerList = await context.Database.SqlQuery<MaterialDTO>($"SELECT * FROM GetAllAccessories()").ToListAsync();
        //            return flowerList;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
