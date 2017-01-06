using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain
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
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public ContactDetail ContactDetail { get; set; }

        public List<Order> Orders { get; set; }
        public List<Address> Addresses { get; set; }
        //TODO : 4 - Agrego propiedad de Cookies
        public string CustomerCookie { get; set; }
        public string FullName
        {
            get
            {
                return LastName.Trim() + ", " + FirstName;
            }
        }
    }
}