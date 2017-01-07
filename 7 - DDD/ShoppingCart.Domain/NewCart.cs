using System;
using System.Collections.Generic;
using Market.Core.Settings;
using ShoppingCart.Domain;

namespace ShoppingCart.Domain
{
    //TODO 6 - Private Setters & Constructors / 1
    public class NewCart
    {
        public static NewCart CreateCartFromProductSelection
          (string sourceUrl, string customerCookie, int productId, int quantity,
           decimal displayedPrice)
        {
            var cart = new NewCart(sourceUrl, customerCookie);
            cart.InitializeCart();
            cart.InsertNewCartItem(productId, quantity, displayedPrice);
            return cart;
        }

        private NewCart(string sourceUrl, string customerCookie)
        {
            SourceUrl = Uri.IsWellFormedUriString(sourceUrl, UriKind.Absolute) ? sourceUrl : "";

            CustomerCookie = customerCookie;
            CartItems = new List<CartItem>();
        }

        private void InsertNewCartItem(int productId, int quantity, decimal displayedPrice)
        {
            CartItems.Add(CartItem.Create(productId, quantity, displayedPrice, CartCookie));
        }

        private void InitializeCart()
        {
            Initialized = DateTime.Now;
            Expires = Initialized.Add(ShoppingCartSettings.CookieExpiration);
            CartCookie = Guid.NewGuid().ToString();
        }

        public void CustomerFound(int customerId)
        {
            CustomerId = customerId;
        }

        public int CartId { get; set; }
        public string CartCookie { get; private set; }
        public DateTime Initialized { get; private set; }
        public DateTime Expires { get; private set; }
        public string SourceUrl { get; private set; }
        public int CustomerId { get; private set; }
        //TODO 1 -  Aggregate
        public ICollection<CartItem> CartItems { get; private set; }
        public string CustomerCookie { get; private set; }

    }
}
