using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Data;

namespace ShoppingCart.Tests.FullDb
{
    //TODO  13 - Creo un nuevo proyecto para las pruebas que corren 100% contra la DB
    [TestClass]
    public class ShoppingCartViaFullDatabaseTests
    {
        private readonly ShoppingCartContext _context = new ShoppingCartContext();
        private readonly ReferenceContext _refContext = new ReferenceContext();

        [TestMethod]
        public void ProductsHaveValuesWhenReturnedFromRepo()
        {
            var data = new WebSiteOrderData(_context, _refContext);
            var productList = data.GetProductsWithCategoryForShoppingAsync().Result;
            Assert.AreNotEqual("", productList[0].Name);
        }

        [TestMethod]
        public void CanGetProductListAsync()
        {
            var repo = new WebSiteOrderData(_context, _refContext);
            var result = repo.GetProductsWithCategoryForShoppingAsync().Result;
            Assert.IsNotNull(result);
        }
    }
}
