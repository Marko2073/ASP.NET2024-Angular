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
    public class EfGetLogsQuery : EfUseCase, IGetLogsQuery
    {
        public EfGetLogsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id =>45;

        public string Name => "Get Logs";

        public string Description => "Get Logs";

        public IEnumerable<LogsDto> Execute(LogsSearch search)
        {
            var query = Context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.User) || !string.IsNullOrWhiteSpace(search.User))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.User.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Datefrom) || !string.IsNullOrWhiteSpace(search.Datefrom))
            {
                query = query.Where(x => x.ExecutedAt >= DateTime.Parse(search.Datefrom));
            }

            if (!string.IsNullOrEmpty(search.DateTo) || !string.IsNullOrWhiteSpace(search.DateTo))
            {
                query = query.Where(x => x.ExecutedAt <= DateTime.Parse(search.DateTo));
            }

            var skipCount = (search.Page.GetValueOrDefault(1) - 1) * search.ItemsPerPage.GetValueOrDefault(5);
            query = query.Skip(skipCount).Take(search.ItemsPerPage.GetValueOrDefault(12));



            return query.Select(x => new LogsDto
            {
                Id = x.Id,
                User = x.Username,
                UseCaseName = x.UseCaseName,
                Data = x.UseCaseData,
                ExecutedAt = x.ExecutedAt
            });
            
        }
    }
}
