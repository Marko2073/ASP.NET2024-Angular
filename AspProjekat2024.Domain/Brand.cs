using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Domain
{
    public class Brand: Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }= new HashSet<Model>();
        
    }
}
