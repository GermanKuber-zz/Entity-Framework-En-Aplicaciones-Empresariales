using System;
using Market.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market.Test.Domain
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void NewProductIsAvailable()
        {
            Assert.IsTrue((new Product()).IsAvailable);
        }

        [TestMethod]
        public void NewProductWithDataIsAvailable()
        {
            var product = new Product
            {
                Name = "test",
                Description = "testing",
                ProductionStart = DateTime.Today
            };
            Assert.IsTrue(product.IsAvailable);
        }

        [TestMethod]
        public void CanDisableProduct()
        {
            var product = new Product();
            product.RemoveFromProduction();
            Assert.IsFalse(product.IsAvailable);
        }

    }
}
