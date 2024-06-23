using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Domain
{
    public class Purchase:Entity
    {
        public int UserCartId { get; set; }
        public int ModelVersionId { get; set; }
        public int Quantity { get; set; }

        public virtual UserCart UserCart { get; set; }
        public virtual ModelVersion ModelVersion { get; set; }

    }
}
