using System.Collections.Generic;
using Market.Core;
using Market.Data;
using Market.Domain;
using Market.Web.Customer.ViewModels;

namespace Market.Services
{
    //TODO : 8 - Creo servicio para encapsular la logica de "Dominio"
    public class WebSiteOrderingService
    {
        private readonly WebSiteOrderData _siteOrderData;

        public WebSiteOrderingService(WebSiteOrderData siteOrderData)
        {
            _siteOrderData = siteOrderData;
        }

        public List<ProductLineItemViewModel> GetProductList()
        {
            var products = _siteOrderData.GetProductsWithCategoryForShopping();
            var lineitems = new List<ProductLineItemViewModel>();
            products.ForEach(p => lineitems.Add(new ProductLineItemViewModel
            {
                ProductId = p.ProductId,
                CategoryName = p.Category.Name,
                Description = p.Description,
                Name = p.Name,
                Quantity = 0,
                MaxQuantity = p.MaxQuantity,
                CurrentUnitPrice = p.CurrentPrice
            }));
            return lineitems;

        }

        public RevisitedCart ItemSelected(int productId, int quantity,
                                          decimal displayedPrice, string sourceUrl,
                                          string memberCookie, int cartId)
        {
            if (cartId == 0)
            {
                return InitializeCart(productId, quantity, displayedPrice, sourceUrl, memberCookie);
            }
            return AddItemToCart(productId, quantity, displayedPrice, cartId);

        }

        private RevisitedCart InitializeCart(int productId, int quantity,
                                            decimal displayedPrice, string sourceUrl,
                                            string memberCookie)
        {
            var cart = NewCart.CreateCartFromProductSelection
                        (sourceUrl, memberCookie, productId, quantity, displayedPrice);
            return _siteOrderData.StoreCartWithInitialProduct(cart);
        }

        private RevisitedCart AddItemToCart(int productId, int quantity,
                                            decimal displayedPrice, int cartId)
        {
            var cart = _siteOrderData.RetrieveCart(cartId);
            var item = cart.InsertNewCartItem(productId, quantity, displayedPrice);
            _siteOrderData.StoreNewCartItem(item);
            return cart;
        }

        public RevisitedCart RetrieveCart(string cartCookie)
        {
            if (CookieUtilities.IsCartCookie(cartCookie))
            {
                return _siteOrderData.RetrieveCart(cartCookie);

            }
            return null;
        }
    }
}
