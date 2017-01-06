using System.Web.Mvc;
using System.Web.Routing;

namespace Market.Web.Customer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "ProductList", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                         "Default",
                         "{controller}/{action}/{id}",
                         new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                         new[] { "Market.Web.Customer.Controllers" }
                     );
        }
    }
}