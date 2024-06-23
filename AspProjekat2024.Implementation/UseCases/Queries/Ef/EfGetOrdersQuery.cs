using AspProjekat2024.Application;
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
    public class EfGetOrdersQuery : EfUseCase, IGetOrdersQuery
    {
        private readonly IApplicationActor _actor;
        public EfGetOrdersQuery(DatabaseContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 36;

        public string Name => "All Orders";

        public string Description => "All Orders";

        public IEnumerable<OrderDto> Execute(BaseSearch search)
        {
            var query = Context.UserCarts.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.User.Address.Contains(search.Keyword));
            }
            query = query.Where(x => x.User.Id == _actor.Id && x.IsProcessed == true);

            return query.Select(x => new OrderDto
            {
                Address = x.User.Address,
                Date = x.UpdatedAt ?? DateTime.MinValue,
                City = x.User.City,

                Products = x.Purchases.Select(ol => new OrderLineDto
                {
                    Quantity = ol.Quantity,
                    ProductBrand = ol.ModelVersion.Model.Brand.Name,
                    ProductName = ol.ModelVersion.Model.Name,
                    Price = ol.ModelVersion.Prices.Where(c=>c.DateFrom<DateTime.UtcNow && c.DateTo>DateTime.UtcNow).Select(i=>i.PriceValue).FirstOrDefault(),
                }).ToList()
            }).ToList(); 
            
        }
    }
}
