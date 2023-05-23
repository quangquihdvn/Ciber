using System;

namespace Ciber.Models.Entities.Bases
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
