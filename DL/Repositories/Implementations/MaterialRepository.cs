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
        private IMapper mapper;

        public MaterialRepository()
        {
            _context = new FlowerSalesCompanyDbContext();
            SystemRepository.Initialize();
            mapper = SystemRepository.Instance.Mapper;
        }

        public void Add(Material material)
        {
            try
            {
                _context.Materials.Add(material);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Material>> GetAll()
        {
            try
            {
                return await _context.Materials.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Material material)
        {
            try
            {
                _context.Materials.Update(material);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Material material)
        {
            try
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Các hàm trên chưa sử dụng tới

        //Hàm này đang bị đặt sai chỗ
        public async Task<List<FlowerDTO>?> GetAllFlowerByStoreAsync(string storeId)
        {
            try
            {
                //Hàm này sẽ chỉ trả về các flower có số lượng >0 trong bảng MaterialInventory tương ứng với cửa hàng
                var flowerList = await _context.Database.SqlQuery<FlowerDTO>($"SELECT * FROM dbo.fnGetAllFlowerByStore({storeId})").ToListAsync();

                return flowerList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy ra danh sách toàn bộ phụ liệu
        public async Task<List<MaterialDTO>?> GetAccessoryListAsync()
        {
            try
            {
                return await _context.Database.SqlQuery<MaterialDTO>($"SELECT * FROM dbo.GetAllAccessory()").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy ra danh sách toàn bộ hoa
        public async Task<List<FlowerDTO>?> GetFlowerListAsync()
        {
            try
            {
                return await _context.Database.SqlQuery<FlowerDTO>($"SELECT * FROM dbo.GetAllFlower()").ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Lấy danh sách hình thức sản phẩm
        public async Task<List<FloralRepresentationDTO>?> GetFloralRepresentationAsync()
        {
            try
            {
                var result = await _context.FloralRepresentations.ToListAsync();

                if (result != null)
                {
                    return mapper.Map<List<FloralRepresentationDTO>>(result);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
