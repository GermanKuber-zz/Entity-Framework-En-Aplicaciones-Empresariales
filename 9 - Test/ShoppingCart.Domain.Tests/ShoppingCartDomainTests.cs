using System.Collections.Generic;
using System.Linq;
using Market.Core.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Domain.Tests
{

    [TestClass]
    public class ShoppingCartDomainTests
    {
        [TestMethod, TestCategory("ShoppingCart")]
        public void CanCreateRevisitedCartWithNoItems()
        {
            var cart = RevisitedCart.Create(1);

            Assert.AreEqual(1, cart.CartId);
        }

        [TestMethod, TestCategory("ShoppingCart")]
        public void CanCreateNewCartFromProductSelectionWithKnownCustomer()
        {
            var cart = NewCart.CreateCartFromProductSelection("http://www.google.com", "customerCookieString", 1, 1, 9.99m);
            Assert.AreEqual(9.99m, cart.CartItems.Single().CurrentPrice);
        }

        [TestMethod, TestCategory("ShoppingCart")]
        public void CanCreateNewCartFromProductSelectionWithNoKnownCustomer()
        {
            var cart = NewCart.CreateCartFromProductSelection("http://google.com", null, 1, 1, 9.99m);
            Assert.AreEqual(9.99m, cart.CartItems.Single().CurrentPrice);
        }

        [TestMethod, TestCategory("ShoppingCart")]
        public void CanInsertItemIntoEmptyRevisitedCart()
        {
            var cart = RevisitedCart.Create(1);
            cart.InsertNewCartItem(1, 1, 9.99m);
            Assert.AreEqual(1, cart.CartItems.Count());
        }

        [TestMethod, TestCategory("ShoppingCart")]
        public void CanCreateRevisitedCartWithExistingItems()
        {
            var cart = RevisitedCart.CreateWithItems(1, new List<CartItem> { CartItem.Create(1, 1, 9.99m, 1) });
            Assert.AreEqual(1, cart.CartItems.Count());
            Assert.AreEqual(9.99m, cart.CartItems.Single().CurrentPrice);
        }
        //TODO 11 - Creo pruebas de dominio
        [TestMethod]
        public void ItemUpdateQuantityCanChangeStateToModified()
        {
            var cart = NewCart.CreateCartFromProductSelection("", null, 1, 1, 9.99m);
            cart.CartItems.First().UpdateQuantity(2);
            Assert.AreEqual(ObjectState.Modified, cart.CartItems.First().State);
        }
    }
}