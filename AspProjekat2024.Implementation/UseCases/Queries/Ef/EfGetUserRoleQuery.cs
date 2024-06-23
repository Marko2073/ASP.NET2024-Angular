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
    public class EfGetUserRoleQuery : EfUseCase, IGetUserRoleQuery
    {
        public EfGetUserRoleQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 50;

        public string Name => "User Role";

        public string Description => "User Role";

        public InfosDto Execute(AuthRequest search)
        {
            // Log the incoming email
            Console.WriteLine($"Searching for user with email: {search.Email}");

            var user = Context.Users.Where(x => x.Email == search.Email).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return new InfosDto
            {
                RoleId = user.RoleId,
                UserId = user.Id,
                UserCartId = 0
            };
        }

    }
}
