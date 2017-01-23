using System;
using System.Collections.Generic;

namespace Market.Domain
{
    public class Product
    {
        public Product()
        {

            IsAvailable = true;
            LineItems = new HashSet<LineItem>();
            Categories = new HashSet<Category>();
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime ProductionStart { get; set; }
        public bool IsAvailable { get; set; }
        //TODO : 7 - Agrego categoria
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public ICollection<LineItem> LineItems { get; set; }

        public ICollection<Category> Categories { get; set; }
        public int MaxQuantity { get; set; } = 2;
        public decimal CurrentPrice { get; set; }

        public void RemoveFromProduction()
        {
            IsAvailable = false;
        }
    }
}