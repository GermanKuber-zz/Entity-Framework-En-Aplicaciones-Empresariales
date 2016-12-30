using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Market.Domain;

namespace Market.Data
{
    public class CustomerData
    {
    public List<Customer> GetAllCustomers() {
      using (var context = new MarketContext()) {
        return context.Customers.AsNoTracking().ToList();
      }
  }

    public Customer FindCustomer(int? id) {
      using (var context = new MarketContext()) {
                try
                {
                    return context.Customers
       .AsNoTracking()
       .SingleOrDefault(c => c.CustomerId == id);
                }
                catch (System.Exception ex)
                {

                    throw;
                }
     
      }
    }

    public void AddCustomer(Customer customer) {
      using (var context=new MarketContext()) {
        context.Customers.Add(customer);
        context.SaveChanges();
      }
    }

    public void UpdateCustomer(Customer customer) {
      using (var context = new MarketContext()) {
        context.Entry(customer).State = EntityState.Modified;
        context.SaveChanges();
      }
    }

    public void RemoveCustomer(int id) {
      using (var context = new MarketContext()) {
        context.Customers.Remove(context.Customers.Find(id));
        context.SaveChanges();
      }
    }
  }
}
