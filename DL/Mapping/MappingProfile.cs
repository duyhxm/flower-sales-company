using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DL.Models;
using DTO;

namespace DL.Mapping
{
    public class MappingProfile : Profile
    {
        public new void CreateMap(Type sourceType, Type destinationType)
        {
            base.CreateMap(sourceType, destinationType);
        }
    }
}
