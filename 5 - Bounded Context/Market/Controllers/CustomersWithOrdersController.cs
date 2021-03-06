﻿using System.Net;
using System.Web.Mvc;
using Maintenance.Data;

namespace Market.Web.Controllers
{
    public class CustomersWithOrdersController : Controller
    {
        private readonly CustomerWithOrdersData _repo = new CustomerWithOrdersData();

        // GET: CustomersWithOrders
        public ActionResult Index()
        {
            return View(_repo.GetAllCustomers());
        }

        // GET: CustomersWithOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _repo.FindCustomer(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}
