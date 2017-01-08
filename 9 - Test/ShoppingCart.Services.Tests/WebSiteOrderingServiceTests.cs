using System.Collections.Generic;
using System.Linq;
using Market.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.Data;
using ShoppingCart.Domain;

namespace ShoppingCart.Services.Tests
{
    //TODO 1 - Install-Package moq
    [TestClass]
    public class WebSiteOrderingServiceTests
    {
        private string theUri = "http://www.google.com";

        [TestMethod]
        public void InitializeCartReturnsRevisitedCart()
        {
            var scContext = new ShoppingCartContext { Carts = TestHelpers.MockDbSet<NewCart>() };
            var service = new WebSiteOrderingService(new WebSiteOrderData(scContext, new ReferenceContext()));
            Assert.IsInstanceOfType(service.ItemSelected(1, 1, 9.99m, theUri, null, 0), typeof(RevisitedCart));
        }
        [TestMethod]
        public void InitializeCartWithUnknownCustomerStoresZeroInCustomerId()
        {

            var newCartsInMemory = new List<NewCart>();
            var scContext = new ShoppingCartContext { Carts = TestHelpers.MockDbSet(newCartsInMemory) };
            var service = new WebSiteOrderingService(new WebSiteOrderData(scContext, new ReferenceContext()));
            service.ItemSelected(1, 1, 9.99m, theUri, null, 0);
            Assert.AreEqual(0, newCartsInMemory.FirstOrDefault().CustomerId);
        }
        [TestMethod]
        public void InitializeCartWithKnownCustomerStoresValueInCustomerId()
        {
            //TODO 2 - Genero Test con data en memoria
            var newCartsInMemory = new List<NewCart>();
            var mockCustomer = new Mock<Customer>();
            mockCustomer.SetupGet(c => c.CustomerCookie).Returns("CustomerCookieABCDE");
            mockCustomer.SetupGet(c => c.CustomerId).Returns(1);
            var customersInMemory = new List<Customer> { mockCustomer.Object };
            var scContext = new ShoppingCartContext { Carts = TestHelpers.MockDbSet(newCartsInMemory) };
            var refcontext = new ReferenceContext { Customers = TestHelpers.MockDbSet(customersInMemory) };
            var service = new WebSiteOrderingService(new WebSiteOrderData(scContext, refcontext));
            service.ItemSelected(1, 1, 9.99m, theUri, "CustomerCookieABCDE", 0);
            Assert.AreNotEqual(0, newCartsInMemory.FirstOrDefault().CustomerId);
        }

    }
}