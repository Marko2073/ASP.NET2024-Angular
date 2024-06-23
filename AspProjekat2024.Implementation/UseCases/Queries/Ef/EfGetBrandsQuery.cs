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
    public class EfGetBrandsQuery :EfUseCase, IGetBrandsQuery
    {
        public EfGetBrandsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Search Brands";

        public string Description => "Search Brands using entity framework";

        public IEnumerable<BrandDto> Execute(BaseSearch search)
        {
            
            var query = Context.Brands.AsQueryable();
            if(!string.IsNullOrEmpty(search.Keyword) )
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

        }
    }
}
