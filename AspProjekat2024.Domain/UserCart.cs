using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Domain
{
    public class UserCart:Entity
    {
        public int UserId { get; set; }
        public bool IsProcessed { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

    }
}
