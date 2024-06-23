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
    public class EfGetUserQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUserQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 42;

        public string Name => "Get Users";

        public string Description => "Get Users";

        public IEnumerable<UserDto> Execute(BaseSearch search)
        {
            var users = Context.Users.AsQueryable();
            if(!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                users = users.Where(x => x.FirstName.ToLower().Contains(search.Keyword.ToLower()) || x.LastName.ToLower().Contains(search.Keyword.ToLower()));
            }

            return users.Select(x => new UserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Path = x.Path,
                Phone = x.Phone,
                Address = x.Address,
                City = x.City,

            }).ToList();
            

            
        }
    }
}
