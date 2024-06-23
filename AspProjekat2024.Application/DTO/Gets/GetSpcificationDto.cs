using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Gets
{
    public class GetSpcificationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SpecificationDto> Specifications { get; set; } = new List<SpecificationDto>();
    }
}
