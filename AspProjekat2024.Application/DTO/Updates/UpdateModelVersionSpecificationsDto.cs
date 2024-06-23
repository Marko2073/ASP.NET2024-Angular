using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Updates
{
    public class UpdateModelVersionSpecificationsDto
    {
        public int ModelVersionId { get; set; }
        public List<int> SpecificationIds { get; set; }
    }
}
