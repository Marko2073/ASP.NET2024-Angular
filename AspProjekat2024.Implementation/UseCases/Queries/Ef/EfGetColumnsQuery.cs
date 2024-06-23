using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspProjekat2024.Implementation.UseCases.Queries.Ef
{
    public class EfGetColumnsQuery : EfUseCase, IGetColumnsQuery
    {
        public EfGetColumnsQuery(DatabaseContext context) : base(context)
        {
        }

        public int Id => 47;

        public string Name => "Get table columns";

        public string Description => "Get table columns";

        public IEnumerable<string> Execute(string search)
        {
            var columns = new List<string>();

            using (var context = new DatabaseContext())
            {
                var entityType = context.Model.GetEntityTypes()
                                    .FirstOrDefault(e => e.GetTableName().Equals(search, StringComparison.OrdinalIgnoreCase));

                if (entityType == null)
                {
                    throw new KeyNotFoundException($"Table {search} not found.");
                }

                var properties = entityType.GetProperties();

                foreach (var property in properties)
                {
                    var columnName = property.GetColumnName();
                    columns.Add(columnName);
                }
            }
            return columns;
        }
    }
}
