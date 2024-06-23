using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Application.DTO.Searches
{
    public class ProductsSearch
    {
        public int? BrandId { get; set; }
        public int? ModelVersionId { get; set; }
        public int? ModelId { get; set; }
        public List<int>? SpecificationIds { get; set; }
        public int? Page { get; set; } = 1;
        public int? ItemsPerPage { get; set; } = 5;

    }
}
