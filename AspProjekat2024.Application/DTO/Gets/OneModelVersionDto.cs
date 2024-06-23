using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Gets
{
    public class OneModelVersionDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

        public int Stock { get; set; }
        public string Path { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<SpecificationDto> Specifications { get; set; }


    }
}
