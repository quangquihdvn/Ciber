using Ciber.Models.Entities.Bases;
using System;

namespace Ciber.Models.Entities
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
