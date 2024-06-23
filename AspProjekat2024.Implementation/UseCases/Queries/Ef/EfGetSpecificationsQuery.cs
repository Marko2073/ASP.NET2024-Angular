using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetSpecificationsQuery : EfUseCase, IGetSpecificationsQuery
    {
        public EfGetSpecificationsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Get Specifications";

        public string Description => "Get Specifications";

        public IEnumerable<GetSpcificationDto> Execute(BaseSearch search)
        {
            var query = Context.Specifications.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Where(a=>a.ParentId==null).Select(x => new GetSpcificationDto
            {
                Id = x.Id,
                Name = x.Name,
                Specifications = x.Childrens.Select(y => new SpecificationDto
                {
                    Id = y.Id,
                    Name = y.Name,
                    Parent=y.Parent.Name

                
                }).ToList()
            }).ToList();
            
        }
    }
}
