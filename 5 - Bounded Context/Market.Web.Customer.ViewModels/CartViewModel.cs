using System.Collections.Generic;

namespace Market.Web.Customer.ViewModels
{
    public class ShoppingViewModel
    {
        public int CartId { get; set; }
        public string CartCookie { get; set; }
        public int CartCount { get; set; }
        public List<ProductLineItemViewModel> Products { get; set; }
    }
}
