using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.DTO.Searches;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetProductsQuery : EfUseCase, IGetProductsQuery
    {
        public EfGetProductsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Get Products";

        public string Description => "Get All Products";

        public IEnumerable<ProductDto> Execute(ProductsSearch search)
        {
            var query = Context.ModelVersions.AsQueryable();

            if (search.BrandId != null)
            {
                query = query.Where(x => x.Model.BrandId == search.BrandId);
            }
            if (search.ModelId != null)
            {
                query = query.Where(x => x.ModelId == search.ModelId);
            }
            if (search.ModelVersionId != null)
            {
                query = query.Where(x => x.Id == search.ModelVersionId);
            }
            if (search.SpecificationIds != null && search.SpecificationIds.Any())
            {
                var specifications = Context.Specifications
                    .Where(s => search.SpecificationIds.Contains(s.Id))
                    .Select(s => new { s.Id, s.ParentId })
                    .ToList();

                var groupedSpecIds = specifications
                    .GroupBy(s => s.ParentId)
                    .ToList();

                foreach (var group in groupedSpecIds)
                {
                    var specIds = group.Select(g => g.Id).ToList();
                    query = query.Where(modelVersion => modelVersion.ModelVersionSpecifications.Any(spec => specIds.Contains(spec.SpecificationId)));
                }
            }
            


            var skipCount = (search.Page.GetValueOrDefault(1) - 1) * search.ItemsPerPage.GetValueOrDefault(5);
            query = query.Skip(skipCount).Take(search.ItemsPerPage.GetValueOrDefault(5));
            var currentDate = DateTime.Now;
            var products = query.Select(x => new ProductDto
            {
                Id = x.Id,
                BrandId = x.Model.BrandId,
                BrandName = x.Model.Brand.Name,
                ModelId = x.ModelId,
                ModelName = x.Model.Name,
                ModelVersionId = x.Id,
                StockQuantity = x.StockQuantity,
                Price = x.Prices.Where(p => p.DateFrom <= currentDate && p.DateTo >= currentDate)
                                   .Select(p => p.PriceValue)
                                   .FirstOrDefault(),
                Specifications = x.ModelVersionSpecifications.Select(y => new SpecificationDto
                {
                    Id = y.SpecificationId,
                    Name = y.Specification.Name,
                    Parent = y.Specification.Parent.Name
                }).ToList(),
                Pictures = x.Pictures.Select(y => new PicturesDto
                {
                    Id = y.Id,
                    Path = y.Path,

                }).ToList()
            }).ToList();

            return products;
        }
    }
}
