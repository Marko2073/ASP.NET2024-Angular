using AspProjekat2024.Application;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;

namespace AspProjekat2024.API.Core
{
    public class DbExceptionLogger : IExLogger
    {
        private readonly DatabaseContext _context;

        public DbExceptionLogger(DatabaseContext context)
        {
            _context = context;
            
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            var log = new ErrorLog
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow,
            };

            _context.ErrorLogs.Add(log);

            _context.SaveChanges();

            return id;
        }
    }
}
