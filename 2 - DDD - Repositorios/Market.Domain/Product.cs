using System;
using System.Collections.Generic;

namespace Market.Domain
{
    public class Product
    {
        private ICollection<Category> _categories;
        private ICollection<LineItem> _lineItems;

        public Product()
        {
            //TODO 01 : Se agerga propiedad IsAvailable y logica correspondiente
            IsAvailable = true;
            _lineItems = new HashSet<LineItem>();
            _categories = new HashSet<Category>();
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime ProductionStart { get; set; }
        public bool IsAvailable { get; set; }


        public ICollection<LineItem> LineItems
        {
            get { return _lineItems; }
            set { _lineItems = value; }
        }

        public ICollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public void RemoveFromProduction()
        {
            IsAvailable = false;
        }
    }
}