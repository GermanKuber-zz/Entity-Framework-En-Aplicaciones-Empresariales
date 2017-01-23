using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ShoppingCart.Domain;

namespace ShoppingCart.Data.Tests
{
    [TestClass]
    public class ShoppingCartIntegrationTests
    {
        private const string TheUri = "http://www.google.com";
        private readonly StringBuilder _logBuilder = new StringBuilder();
        private string _log;
        private readonly ShoppingCartContext _context;
        private readonly ReferenceContext _refContext;

        public ShoppingCartIntegrationTests()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShoppingCartContext>());
            _context = new ShoppingCartContext();
            _refContext = new ReferenceContext();
            _context.Database.Initialize(force: true);
            SetupLogging();
        }

        [TestMethod]
        public void CanAddNewCartWithProductToCartsDbSet()
        {
            var cart = NewCart.CreateCartFromProductSelection(TheUri, null, 1, 1, 9.99m);
            _context.Carts.Add(cart);
            Assert.AreEqual(1, _context.Carts.Local.Count);
        }

        [TestMethod]
        public void CanStoreCartWithInitialProduct()
        {
            var cart = NewCart.CreateCartFromProductSelection(TheUri, null, 1, 1, 9.99m);
            var data = new WebSiteOrderData(_context, _refContext);
            var resultCart = data.StoreCartWithInitialProduct(cart);
            WriteLog();
            Assert.AreNotEqual(0, resultCart.CartId);
        }

        [TestMethod]
        public void CanUpdateCartItems()
        {
            //Arrange
            var goodId = _context.Carts.Where(c => c.CartItems.Any())
              .Select(c => c.CartId)
              .FirstOrDefault();
            var data1 = new WebSiteOrderData(new ShoppingCartContext(), _refContext);
            RevisitedCart existingCart = data1.RetrieveCart(goodId);
            var lineItemCount = existingCart.CartItems.Count();
            var firstItem = existingCart.CartItems.First();
            var originalTotalItems = existingCart.TotalItems;
            var originalQuantity = firstItem.Quantity;
            existingCart.CartItems.First().UpdateQuantity(originalQuantity + 1);
            existingCart.InsertNewCartItem(1, 1, new decimal(100));
            //Act
            var data2 = new WebSiteOrderData(new ShoppingCartContext(), _refContext);
            data2.UpdateItemsForExistingCart(existingCart);
            //Assert
            var data3 = new WebSiteOrderData(new ShoppingCartContext(), _refContext);
            RevisitedCart existingCartAgain = data3.RetrieveCart(goodId);
            Assert.AreEqual(lineItemCount + 1, existingCartAgain.CartItems.Count());
            Assert.AreEqual(originalTotalItems + 2, existingCartAgain.TotalItems);



        }
        //TODO 05 - Private Setters & Constructors / 3
        [TestMethod]
        public void ProductsHaveValuesWhenReturnedFromRepo()
        {
            var data = new WebSiteOrderData(_context, _refContext);
            var productList = data.GetProductsWithCategoryForShopping();
            Assert.AreNotEqual("", productList[0].Name);
        }

        //TODO 07 - Private Setters & Constructors / 2
        [TestMethod]
        public void CanRetrieveCartFromRepoUsingCartId()
        {
            //Arrange
            var cart = NewCart.CreateCartFromProductSelection(TheUri, null, 1, 1, 9.99m);
            var data = new WebSiteOrderData(_context, _refContext);
            var createdCart = data.StoreCartWithInitialProduct(cart);
            Debug.WriteLine($"Stored Cart Id from database {createdCart.CartId}");
            //Act (retrieve) and Assert
            Assert.AreEqual(createdCart.CartId, data.RetrieveCart(cart.CartId).CartId);
        }

        private void WriteLog()
        {
            Debug.WriteLine(_log);
        }

        private void SetupLogging()
        {
            _context.Database.Log = BuildLogString;
        }

        private void BuildLogString(string message)
        {
            _logBuilder.Append(message);
            _log = _logBuilder.ToString();
        }
    }
}