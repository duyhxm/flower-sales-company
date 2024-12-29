using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using System.Diagnostics;
using DTO.Product;
using DTO;

namespace DL.Repositories.Implementations.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        //[TestMethod()]
        //public void AddProductTest()
        //{
        //    ProductRepository test = new ProductRepository();
        //    Product product = new Product();
        //    product.ProductName = "bó hoa hướng dương";
        //    product.FrepresentationId = "FR01";
        //    test.RemoveProduct(product);
        //}

        //[TestMethod()]
        //public void GetLastestProductIdTest()
        //{
        //    ProductRepository test = new ProductRepository();

        //    string? s = test.GetLastestProductId();

        //    Debug.WriteLine(s);
        //}

        //[TestMethod()]
        //public async Task AddCompleteProductAsyncTest()
        //{
        //    SystemRepository.Initialize();
        //    ProductRepository repo = new ProductRepository();

        //    DetailedProductDTO details = new DetailedProductDTO()
        //    {
        //        MaterialId = "F0001",
        //        UsedQuantity = 2
        //    };

        //    List<DetailedProductDTO> list = new List<DetailedProductDTO>();
        //    list.Add(details);

        //    ProductDTO productDto = new ProductDTO()
        //    {
        //        FrepresentationId = "FR01",
        //        ProductName = "bó hoa cúc",
        //        DetailedProducts = list
        //    };

        //    ProductCreationHistoryDTO log = new ProductCreationHistoryDTO()
        //    {
        //        CreatedDateTime = DateTimeOffset.UtcNow.ToLocalTime(),
        //        EmployeeId = "PTE0000001",
        //        CreatedQuantity = 1,
        //        UnitPrice = 100
        //    };

        //    await repo.AddProductAsync(productDto, log, "S001");

        //    Debug.WriteLine("Add successfully a new product");
        //}

        [TestMethod()]
        public async Task UpdateMaterialInventoryAsyncTest()
        {
            SystemRepository.Initialize();
            ProductRepository repo = new ProductRepository();

            DetailedProductDTO details = new DetailedProductDTO()
            {
                MaterialId = "F0002",
                UsedQuantity = 2
            };

            List<DetailedProductDTO> list = new List<DetailedProductDTO>();
            list.Add(details);

            ProductDTO productDto = new ProductDTO()
            {
                FrepresentationId = "FR01",
                ProductName = "bó hoa cúc",
                DetailedProducts = list
            };
            await repo.UpdateMaterialInventoryAsync(productDto, "S001", 100);
        }
    }
}