using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.DTO.Searches;
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
    public class EfGetTablesQuery : EfUseCase, IGetTablesQuery
    {
        public EfGetTablesQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 46;

        public string Name => "Get Tables";

        public string Description => "Get Tables";

        public IEnumerable<TablesDto> Execute(BaseSearch search)
        {
            var query = Context.Model.GetEntityTypes().Select(t=>t.GetTableName()).Distinct().ToList();

            return query.Select(q => new TablesDto
            {
                Name = q
            });
            

            
           
        }
    }
}
