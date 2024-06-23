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
    public class EfGetRolesQuery : EfUseCase, IGetRolesQuery
    {
        public EfGetRolesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 51;

        public string Name => "GetRoles";

        public string Description => "GetRoles";

        public IEnumerable<RoleDto> Execute(BaseSearch search)
        {
            var query = Context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name
            });
            
        }
    }
}
