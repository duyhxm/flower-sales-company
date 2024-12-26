using Microsoft.VisualStudio.TestTools.UnitTesting;
using DL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Models;
using System.Diagnostics;

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

        [TestMethod()]
        public void GetLastestProductIdTest()
        {
            ProductRepository test = new ProductRepository();

            string? s = test.GetLastestProductId();

            Debug.WriteLine(s);
        }
    }
}