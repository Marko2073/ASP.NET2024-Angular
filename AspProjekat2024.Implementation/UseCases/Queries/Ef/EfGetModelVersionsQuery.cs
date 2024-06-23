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
    public class EfGetModelVersionsQuery : EfUseCase, IGetModelVersionQuery
    {
        public EfGetModelVersionsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Get Model Versions";

        public string Description => "Get Model Versions";

        public IEnumerable<ModelVersionDto> Execute(BaseSearch search)
        {
            var query = Context.ModelVersions.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Model.Name.ToLower().Contains(search.Keyword.ToLower()) || x.Model.Brand.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new ModelVersionDto
            {
                Id = x.Id,
                ModelId = x.ModelId
            }).ToList();

        }
    }
}
