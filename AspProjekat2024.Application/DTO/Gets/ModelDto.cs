using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Gets
{
    public class ModelDto : BaseDto
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
