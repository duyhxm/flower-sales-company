using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO;

namespace DL.Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        void Add(Material material);

        Task<List<Material>> GetAll();
        void Update(Material material);
        void Delete(Material material);
    }
}
