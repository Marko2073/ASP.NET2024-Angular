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
    public class EfGetModelVersionSpecificationQuery : EfUseCase, IGetModelVersionSpecificationQuery
    {
        public EfGetModelVersionSpecificationQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Get Model Version Specification";

        public string Description => "Get Model Version Specification";

        public IEnumerable<ModelVersionSpecificationDto> Execute(BaseSearch search)
        {
            var query = Context.ModelVersionSpecifications.AsQueryable();
            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.ModelVersion.Model.Name.ToLower().Contains(search.Keyword.ToLower()) ||
                                    x.ModelVersion.Model.Brand.Name.ToLower().Contains(search.Keyword.ToLower()) ||
                                    x.ModelVersion.ModelVersionSpecifications.Any(y=>y.Specification.Name.ToLower().Contains(search.Keyword.ToLower())));
            }

            return query.Select(x => new ModelVersionSpecificationDto
            {
                Id = x.Id,
                ModelVersionId = x.ModelVersionId,
                SpecificationId = x.SpecificationId,
            }).ToList();

        }
    }
}
