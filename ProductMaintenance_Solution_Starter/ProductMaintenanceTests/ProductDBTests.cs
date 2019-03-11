using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductMaintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaintenance.Tests
{
    [TestClass()]
    public class ProductDBTests
    {
        private Product _testProduct;
        [TestInitialize]
        public void InitTest()
        {
            _testProduct = new Product { Code = "HAMS", Description = "Hamster food", Price = 9.99m };
            ProductDB.DeleteProduct(_testProduct);

            ProductDB.AddProduct(_testProduct);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            ProductDB.DeleteProduct(_testProduct);
        }

        [TestMethod()]
        public void GetProductTest()
        {
            var product = ProductDB.GetProduct(_testProduct.Code);
            Assert.AreEqual(_testProduct, product);
        }

        [TestMethod()]
        public void AddProductTest()
        {
            var product = ProductDB.GetProduct(_testProduct.Code);
            Assert.AreEqual(_testProduct, product);
        }

        [TestMethod()]
        public void UpdateProductTest()
        {
            var product = ProductDB.GetProduct(_testProduct.Code);
            product.Price = 18.99m;

            var success = ProductDB.UpdateProduct(_testProduct, product);
            _testProduct = product;

            Assert.IsTrue(success);
            Assert.AreEqual(_testProduct, product);
        }

        [TestMethod()]
        public void DeleteProductTest()
        {
            var success = ProductDB.DeleteProduct(_testProduct);
            var product = ProductDB.GetProduct(_testProduct.Code);

            Assert.IsTrue(success);
            Assert.IsNull(product);
        }
    }
}