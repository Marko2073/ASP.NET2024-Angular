using AspProjekat2024.Application;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Implementation.UseCases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Logging
{
    public class EfUseCaseLogger : EfUseCase, IUseCaseLogger
    {
        public EfUseCaseLogger(DatabaseContext context) : base(context)
        {
        }

        public void Log(UseCaseLog log)
        {
            var logg =  new Domain.UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                ExecutedAt = DateTime.UtcNow,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData)
            };
            Context.UseCaseLogs.Add(logg);
            
            Context.SaveChanges();
            
        }
    }
}
