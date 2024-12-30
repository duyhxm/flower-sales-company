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
        private const string GET_FLOWER_QUERY = @$"SELECT FlowerID, MaterialName, TypeName,                                                 ColorName, CharacteristicName
                                                   FROM Flower AS f
                                                   JOIN Material AS m
                                                        ON f.FlowerID = m.MaterialID
                                                   JOIN FloralCharacteristic AS fchar
                                                        ON f.FCharacteristicID = fchar.FCharacteristicID
                                                   JOIN FloralColor AS fcolor
                                                        ON f.FColorID = fcolor.FColorID
                                                   JOIN FloralType AS ftype
                                                        ON f.FTypeID = ftype.FTypeID
                                                   WHERE 1 = 1 AND";
        private const string GET_ACCESSORY_QUERY = "";
        FlowerSalesCompanyDbContext _context;
        IMapper mapper;

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

        public async Task<List<AccessoryDTO>> GetAllAccessoryAsync(string criteria)
        {
            try
            {
                return await _context.Set<AccessoryDTO>().FromSqlInterpolated($"{GET_ACCESSORY_QUERY} {criteria}").ToListAsync();
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
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FlowerDTO>?> GetFlowerInventoryAsync()
        {
            try
            {
                return null;
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
