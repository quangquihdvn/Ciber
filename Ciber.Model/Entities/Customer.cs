using Ciber.Models.Entities.Bases;
using System.Collections.Generic;

namespace Ciber.Models.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
