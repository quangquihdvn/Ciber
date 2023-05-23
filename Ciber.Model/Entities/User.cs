using Ciber.Models.Entities.Bases;
using Ciber.Models.Enum;

namespace Ciber.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
