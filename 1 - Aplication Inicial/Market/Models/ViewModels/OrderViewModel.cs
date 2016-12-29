using System;
using Market.Models.Enums;

namespace Market.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderSource OrderSource { get; set; }
        public int CustomerId { get; set; }
    }
}