using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetOneModelVersionQuery : EfUseCase, IGetOneModelVersionQuery
    {
        public EfGetOneModelVersionQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 39;

        public string Name => "Get one Model Version";

        public string Description => "Get one Model Version";

        public OneModelVersionDto Execute(int search)
        {
            var query = Context.ModelVersions
                            .Include(m => m.Model)
                            .ThenInclude(m => m.Brand)
                            .Include(m => m.Pictures)
                            .Include(m => m.Prices)
                            .Include(m => m.ModelVersionSpecifications)
                            .ThenInclude(m => m.Specification)
                            .ThenInclude(s => s.Parent)
                            .AsQueryable();

            var modelVersion = query.FirstOrDefault(x => x.Id == search);
            if (modelVersion == null)
            {
                throw new Exception($"Model with an id of {search} doesn't exist.");
            }

            var currentDate = DateTime.Now;
            var price = modelVersion.Prices
                                   .Where(p => p.DateFrom <= currentDate && p.DateTo >= currentDate)
                                   .Select(p => p.PriceValue)
                                   .FirstOrDefault();

            if (price == default)
            {
                throw new Exception($"No valid price found for Model Version with an id of {search}.");
            }

            return new OneModelVersionDto
            {
                Id = modelVersion.Id,
                ModelId = modelVersion.ModelId,
                Model = modelVersion.Model?.Name ?? "N/A",
                Brand = modelVersion.Model?.Brand?.Name ?? "N/A",
                Stock = modelVersion.StockQuantity,
                Path = modelVersion.Pictures.Select(x => x.Path).FirstOrDefault() ?? "N/A",
                Price = price,
                Specifications = modelVersion.ModelVersionSpecifications.Select(x => new SpecificationDto
                {
                    Id = x.SpecificationId,
                    Name = x.Specification?.Name ?? "N/A",
                    Parent = x.Specification?.Parent?.Name ?? "N/A",
                }).ToList()
            };
        }
    }
}
