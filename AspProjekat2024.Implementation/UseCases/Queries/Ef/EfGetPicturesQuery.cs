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
    public class EfGetPicturesQuery : EfUseCase, IGetPicturesQuery
    {
        public EfGetPicturesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Get Pictures";

        public string Description => "Get Pictures";

        public IEnumerable<PictureDto> Execute(BaseSearch search)
        {
            var query = Context.Pictures.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) || !string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(x => x.ModelVersion.Model.Name.ToLower().Contains(search.Keyword.ToLower())|| x.ModelVersion.Model.Brand.Name.ToLower().Contains(search.Keyword.ToLower()));
            }

            return query.Select(x => new PictureDto
            {
                Id = x.Id,
                ModelVersionId = x.ModelVersionId,
                Path = x.Path

            });
            
        }

    }
}
