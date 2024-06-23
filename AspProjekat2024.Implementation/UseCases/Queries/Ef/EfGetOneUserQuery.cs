using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetOneUserQuery : EfUseCase, IGetOneUserQuery
    {
        public EfGetOneUserQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 43;

        public string Name => "Get One User";

        public string Description => "Get One User";

        public UserDto Execute(int search)
        {
            var query = Context.Users.AsQueryable();

            var user = query.Where(x => x.Id == search).FirstOrDefault();
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Path = user.Path,
                Phone = user.Phone,
                Address = user.Address,
                City = user.City,
            };
            
        }
    }
}
