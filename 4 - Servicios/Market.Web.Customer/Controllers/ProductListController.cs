﻿using System.Collections.Generic;
using System.Web.Mvc;
using Market.Services;
using Market.Web.Customer.ViewModels;

namespace Market.Web.Customer.Controllers
{
    //TODO : 6 - Implemento nuevo proyecto para la venta de productos
    public class ProductListController : Controller
    {
        private readonly WebSiteOrderingService _service;

        public ProductListController(WebSiteOrderingService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {

            var products = _service.GetProductList();
            var svm = BuildCartViewModelFromProductListAndTempData
                       (TempData["CartCount"], TempData["CartId"], products);
            ViewBag.CartCount = svm.CartCount;
            return View(svm);
        }

        private ShoppingViewModel BuildCartViewModelFromProductListAndTempData
           (object tempCount, object tempId, List<ProductLineItemViewModel> products)
        {
            var svm = new ShoppingViewModel { Products = products };
            int cartCount = 0;
            int cartId = 0;
            if (tempCount != null) int.TryParse(tempCount.ToString(), out cartCount);
            if (tempId != null) int.TryParse(tempId.ToString(), out cartId);
            svm.CartCount = cartCount;
            svm.CartId = cartId;
            return svm;
        }
    }
}