using System.Net;
using System.Web.Mvc;
using Market.Data;
using Market.Domain;
using System.Data.Entity;

namespace Market.Controllers
{
    public class CustomersController : Controller
    {
        private GenericRepository<Customer> repo;
        //TODO : 03 - Se injecta repositorio
        
        public CustomersController(GenericRepository<Customer> _repo)
        //public CustomersController(GenericRepository<Customer> _repo, DbContext context)
        //TODO : 5 - New context
        {
            repo = _repo;
        }

        public ActionResult Index()
        {
            return View(repo.All());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Customer customer = repo.FindByKey(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Customer customer = repo.FindByKey(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Customer customer = repo.FindByKey(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}