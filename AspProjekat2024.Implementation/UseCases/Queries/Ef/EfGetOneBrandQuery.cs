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
    public class EfGetOneBrandQuery : EfUseCase, IGetOneBrandQuery
    {
        public EfGetOneBrandQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "Get One Brand";

        public string Description => "Get One Brand";

        public BrandDto Execute(int search)
        {
            var query = Context.Brands.AsQueryable();
            
            var brand = query.Where(x => x.Id == search).FirstOrDefault();
            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name
            };
           
        }
    }
}
