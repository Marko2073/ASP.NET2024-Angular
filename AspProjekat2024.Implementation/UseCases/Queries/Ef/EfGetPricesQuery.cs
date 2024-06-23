using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetPricesQuery : EfUseCase, IGetPriceQuery
    {
        public EfGetPricesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Get Prices";

        public string Description => "Get Prices";

        public IEnumerable<PriceDto> Execute(PriceSearch search)
        {
            var query = Context.Prices.AsQueryable();

            if (search.Price!=null)
            {
                query = query.Where(x => x.PriceValue == search.Price);
            }
            return query.Select(x => new PriceDto
            {
                Id = x.Id,
                Price = x.PriceValue,
                ModelVersionId = x.ModelVersionId,
                DateFrom = x.DateFrom.ToString(),
                DateTo = x.DateTo.ToString()

                
            }).ToList();

            
        }
    }
}
