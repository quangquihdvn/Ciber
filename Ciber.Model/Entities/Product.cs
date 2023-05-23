using Ciber.Models.Entities.Bases;
using System;
using System.Collections.Generic;

namespace Ciber.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
