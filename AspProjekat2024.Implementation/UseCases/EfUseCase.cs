using AspProjekat2024.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(DatabaseContext context) 
        {
            Context = context;
        }
        protected DatabaseContext Context {  get; }
            
    }
}
