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
    public class EfGetOneModelQuery : EfUseCase, IGetOneModelQuery
    {
        public EfGetOneModelQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 38;

        public string Name => "Get One Model";

        public string Description => "Get One Model";

        public ModelDto Execute(int search)
        {
            var query = Context.Models
                            .Include(m => m.Brand)
                            .AsQueryable();

            var model = query.Where(x => x.Id == search).FirstOrDefault();
            if (model == null)
            {
                throw new Exception($"Model with an id of {search} doesn't exist.");
            }

            return new ModelDto
            {
                Id = model.Id,
                Name = model.Name,
                BrandName = model.Brand.Name, 
                BrandId = model.BrandId
            };
        }

    }
}
