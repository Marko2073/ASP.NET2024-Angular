using AspProjekat2024.Application.Logging;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        private readonly DatabaseContext _context;
        public ConsoleExceptionLogger(DatabaseContext context)
        {
                _context = context;
        }
        public void Log(Exception ex)
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
        }
    }
}
