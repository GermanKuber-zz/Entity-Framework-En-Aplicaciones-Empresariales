using System.Collections.Generic;
using System.Linq;
using Market.Models.ViewModels;

namespace Market.Data
{
    public class CustomerWithOrdersData
    {
        public List<CustomerViewModel> GetAllCustomers()
        {
            using (var context = new MarketContext())
            {
                return context.Customers.AsNoTracking()
                .Select(c => new CustomerViewModel
                {
                    CustomerId = c.CustomerId,
                    Name = c.FirstName + " " + c.LastName,
                    OrderCount = c.Orders.Count()
                })
                .ToList();
            }
        }

        public CustomerViewModel FindCustomer(int? id)
        {
            using (var context = new MarketContext())
            {
                var cust =
                  context.Customers.AsNoTracking()
                                   .Select(c => new CustomerViewModel
                                   {
                                       CustomerId = c.CustomerId,
                                       Name = c.FirstName + " " + c.LastName,
                                       OrderCount = c.Orders.Count(),
                                       Orders = c.Orders.Select(
                                       o => new OrderViewModel
                                       {
                                           OrderSource = o.OrderSource,
                                           CustomerId = o.CustomerId,
                                           OrderDate = o.OrderDate
                                       }).ToList()
                                   })
                                    .FirstOrDefault(c => c.CustomerId == id);
                return cust;
            }
        }


    }
}
