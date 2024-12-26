using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Product;
using DL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DL.Mapping.Tests
{
    [TestClass()]
    public class MapperConfigurationTests
    {
        [TestMethod()]
        public void InitializeMappterTest()
        {
            FlowerSalesCompanyDbContext db = new FlowerSalesCompanyDbContext();
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var mappingDirectory = Path.Combine(baseDirectory, "Mapping");
            var filePath = Path.Combine(mappingDirectory, "mappings.txt");
            var mapper = MapperConfiguration.InitializeMapper(filePath);

            ProductDTO productDto = new ProductDTO()
            {
                ProductId = "P000000001",
                ProductName = "Bó hoa hướng dương",
                FrepresentationId = "FR01"
            };


            Product product = mapper.Map<Product>(productDto);
            db.Products.Add(product);
            db.SaveChanges();

            var serviceCollection = new ServiceCollection();
            


        }
    }
}