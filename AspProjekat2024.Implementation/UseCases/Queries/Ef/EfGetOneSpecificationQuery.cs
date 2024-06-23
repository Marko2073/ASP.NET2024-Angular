using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetOneSpecificationQuery : EfUseCase, IGetOneSpecificationQuery
    {
        public EfGetOneSpecificationQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 44;

        public string Name => "Get One Specification";

        public string Description => "Get One Specification";

        public SpecificationDto Execute(int search)
        {
            var query = Context.Specifications
                          .Include(x => x.Parent)
                          .AsQueryable();

            var rez = query.FirstOrDefault(x => x.Id == search);

            if (rez == null)
            {
                throw new Exception("Specification with an id of {search} doesn't exist.");
            }

            return new SpecificationDto
            {
                Id = rez.Id,
                Name = rez.Name,
                Parent = rez.Parent.Name
            };
        }
    }
}
