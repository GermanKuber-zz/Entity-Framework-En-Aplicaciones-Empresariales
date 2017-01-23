using System.Net;
using System.Web.Mvc;
using Market.Data;

namespace Market.Controllers
{
    public class CustomersWithOrdersController : Controller
    {
        private readonly CustomerWithOrdersData repo = new CustomerWithOrdersData();

        // GET: CustomersWithOrders
        public ActionResult Index()
        {
            return View(repo.GetAllCustomers());
        }

        // GET: CustomersWithOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = repo.FindCustomer(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}
