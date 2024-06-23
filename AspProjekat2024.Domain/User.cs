using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Domain
{
    public class User:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Path { get; set; }

        public virtual int RoleId { get; set; }

        public virtual ICollection<UserCart> UserCarts { get; set; }

        public virtual ICollection<UserUseCase> UseCases { get; set; } = new HashSet<UserUseCase>();
    }
}
