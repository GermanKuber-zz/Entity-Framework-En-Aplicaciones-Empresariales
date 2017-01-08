using System;
using System.Collections.Generic;

namespace Maintenance.Domain
{
    public class Customer
    {
        public Customer()
        {
            FirstName = "";
            LastName = "";
            DateOfBirth = DateTime.Today;
            Orders = new List<Order>();
            Addresses = new List<Address>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ContactDetail ContactDetail { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public string FullName
        {
            get
            {
                return LastName.Trim() + ", " + FirstName;
            }
        }

        public string CustomerCookie { get; set; }
    }
}