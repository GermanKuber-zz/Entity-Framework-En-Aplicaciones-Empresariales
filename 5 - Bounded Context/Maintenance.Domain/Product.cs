using System;

namespace Maintenance.Domain
{
    //TODO : 02 - Defino una clase producto para el administrador
    public class Product
    {
        public Product()
        {
            IsAvailable = true;
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime ProductionStart { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int MaxQuantity { get; set; }
        public decimal CurrentPrice { get; set; }

        public void RemoveFromProduction()
        {
            IsAvailable = false;
        }
    }
}