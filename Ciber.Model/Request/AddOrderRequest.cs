using System;

namespace Ciber.Models.Request
{
    public class AddOrderRequest
    {
        public string OrderName { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
    }
}
