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
    public class EfGetModelsQuery :EfUseCase, IGetModelsQuery
    {
        public EfGetModelsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Search Models";

        public string Description => "Search all models";

        public IEnumerable<ModelDto> Execute(BaseSearch search)
        {
            var query=Context.Models.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }
            return query.Select(x => new ModelDto
            {
                Id = x.Id,
                Name = x.Name,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name
            }).ToList();

            
        }
    }
}
