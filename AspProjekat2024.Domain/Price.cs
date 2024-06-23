using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Domain
{
    public class Price:Entity
    {
        public int ModelVersionId { get; set; }
        public decimal PriceValue { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public virtual ModelVersion ModelVersion { get; set; }
    }
}
