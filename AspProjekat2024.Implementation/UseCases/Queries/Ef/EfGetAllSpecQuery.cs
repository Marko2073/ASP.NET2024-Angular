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
    public class EfGetAllSpecQuery : EfUseCase, IGetAllSpecificationsQuery
    {
        public EfGetAllSpecQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 48;

        public string Name => "IGetAllSpecificationsQuery";

        public string Description => "IGetAllSpecificationsQuery";

        public IEnumerable<AllSpec> Execute(BaseSearch search)
        {
            var query = Context.Specifications.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new AllSpec
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = (int)x.ParentId,
            }).ToList();
            
        }
    }
}
