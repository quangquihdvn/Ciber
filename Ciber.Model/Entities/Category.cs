using Ciber.Models.Entities.Bases;
using System.Collections.Generic;

namespace Ciber.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
