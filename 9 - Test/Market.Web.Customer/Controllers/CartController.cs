using System.Web.Mvc;
using Market.Core;
using ShoppingCart.Services;

namespace Market.Web.Customer.Controllers
{
    public class CartController : Controller
    {
        private readonly WebSiteOrderingService _service;

        public CartController(WebSiteOrderingService service)
        {
            _service = service;
        }

        public ActionResult ItemSelected(int? productId, int quant, decimal unitPrice,
                                         string memberCookie, int cartId)
        {
            if (productId != null)
            {
                var createdCart =
                    _service.ItemSelected(productId.Value, quant, unitPrice,
                        "http://google.com", memberCookie, cartId);
                ControllerContext.HttpContext.Response.Cookies.Add(
                    CookieUtilities.BuildCartCookie(createdCart.CartCookie, createdCart.CartCookieExpires));
                TempData["CartCount"] = createdCart.TotalItems;
                TempData["CartId"] = createdCart.CartId;
            }
            return RedirectToAction("../ProductList");
        }
    }
}