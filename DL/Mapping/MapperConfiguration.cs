using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DL.Models;
using AutoMapper;
using DTO.Product;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DL.Mapping
{
    public static class MapperConfiguration
    {
        public static IMapper InitializeMapper(string filePath)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                var profile = new MappingProfile();
                var mappings = File.ReadAllLines(filePath);

                foreach (var mapping in mappings)
                {
                    var types = mapping.Split(',');
                    if (types.Length == 2)
                    {
                        var sourceTypeName = types[0].Trim();
                        var destinationTypeName = types[1].Trim();

                        var sourceAssemblyName = sourceTypeName.Split('.')[0];
                        var destinationAssemblyName = destinationTypeName.Split('.')[0];

                        var sourceType = Type.GetType($"{sourceTypeName}, {sourceAssemblyName}");
                        var destinationType = Type.GetType($"{destinationTypeName}, {destinationAssemblyName}");

                        if (sourceType != null && destinationType != null)
                        {
                            profile.CreateMap(sourceType, destinationType);
                        }
                        else
                        {
                            throw new Exception($"Type not found: {sourceTypeName} or {destinationTypeName}");
                        }
                    }
                }
                cfg.AddProfile(profile);
            });

            return config.CreateMapper();
        }
    }
}
