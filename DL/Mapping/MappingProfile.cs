using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DL.Models;
using DTO;
using DTO.Product;
using DTO.SalesOrder;

namespace DL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.DetailedProducts, opt => opt.MapFrom(src => src.DetailedProducts));
            CreateMap<SalesOrderDTO, SalesOrder>()
                .ForMember(dest => dest.DetailedSalesOrders, opt => opt.MapFrom(src => src.DetailedSalesOrders));
        }
        public new void CreateMap(Type sourceType, Type destinationType)
        {
            base.CreateMap(sourceType, destinationType).ReverseMap();
        }
    }
}
