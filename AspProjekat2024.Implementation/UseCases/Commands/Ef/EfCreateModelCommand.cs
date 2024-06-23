using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfCreateModelCommand : EfUseCase, ICreateModelCommand
    {
        public EfCreateModelCommand(DatabaseContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Create Model";

        public string Description => "Create new Model";

        public void Execute(CreateModelDto request)
        {
            Context.Models.Add(new Domain.Model
            {
                Name = request.Name,
                BrandId = request.BrandId
            });
            Context.SaveChanges();


            
        }
    }
}
