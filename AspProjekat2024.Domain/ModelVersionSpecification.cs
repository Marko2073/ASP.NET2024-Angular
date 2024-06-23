using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Domain
{
    public class ModelVersionSpecification:Entity
    {
        public int ModelVersionId { get; set; }
        public int SpecificationId { get; set; }
        public virtual ModelVersion ModelVersion { get; set; }
        public virtual Specification Specification { get; set; }


    }
}
