using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Domain;

namespace ShoppingCart.Data.Tests
{
    //TODO  12 - Separo las pruebas que mockeo en un archivo distinto
    [TestClass]
    public class MockedShoppingCartIntegrationTests
    {
        private readonly string _theUri = "http://www.google.com";
        private readonly List<NewCart> _cartsInMemory;
        private ReferenceContext _refMockingContext;
        private readonly ShoppingCartContext _scMockingContext;

        public MockedShoppingCartIntegrationTests()
        {

            _cartsInMemory = new List<NewCart>();
            _scMockingContext = new ShoppingCartContext { Carts = TestHelpers.MockDbSet(_cartsInMemory) };
            _refMockingContext = new ReferenceContext();

        }

        [TestMethod]
        public async Task CanGetProductListAsyncMocked()
        {
            var productsInMemory = new List<Product> { new Product(), new Product() };
            _refMockingContext = new ReferenceContext { Products = TestHelpers.MockDbSet(productsInMemory) };
            var repo = new WebSiteOrderData(_scMockingContext, _refMockingContext);
            var result = await repo.GetProductsWithCategoryForShoppingAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CanGetProductAsyncMocked()
        {
            var productsInMemory = new List<Product> { new Product(), new Product() };
            _refMockingContext = new ReferenceContext { Products = TestHelpers.MockDbSet(productsInMemory) };
            var repo = new WebSiteOrderData(_scMockingContext, _refMockingContext);
            var result = await repo.GetFirstProductWithCategoryForShoppingAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanRetrieveCartAndItemsUsingCartCookieMocked()
        {
            var cart = NewCart.CreateCartFromProductSelection(_theUri, null, 1, 1, 9.99m);
            _cartsInMemory.Add(cart);
            var storedCartCookie = cart.CartCookie;
            var repo = new WebSiteOrderData(_scMockingContext, _refMockingContext);
            Assert.AreEqual(1, repo.RetrieveCart(storedCartCookie).CartItems.Count());
        }
    }
}