using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using DTO.Material;

namespace DL.Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        void Add(MaterialDTO material);

        Task<List<MaterialDTO>> GetAllMaterials();

        void Update(MaterialDTO material);

        void Delete(MaterialDTO material);

    }
}
