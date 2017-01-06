using System;
using Market.Domain.Enums;

namespace Market.Domain.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderSource OrderSource { get; set; }
        public int CustomerId { get; set; }
    }
}