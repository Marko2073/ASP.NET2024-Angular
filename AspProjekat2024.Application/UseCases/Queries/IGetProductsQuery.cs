using AspProjekat2024.Application.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspProjekat2024.Application.DTO.Gets;

namespace AspProjekat2024.Application.UseCases.Queries
{
    public interface IGetProductsQuery : IQuery<ProductsSearch, IEnumerable<ProductDto>>
    {
    }
}
