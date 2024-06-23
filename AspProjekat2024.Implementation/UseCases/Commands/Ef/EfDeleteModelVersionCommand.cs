using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfDeleteModelVersionCommand : EfUseCase, IDeleteModelVersionCommand
    {
        private readonly DeleteModelVersionDtoValidator _validator;
        public EfDeleteModelVersionCommand(DatabaseContext context, DeleteModelVersionDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Delete Model Version";

        public string Description => "Delete Model Version";

        public void Execute(DeleteDto request)
        {
            var modelVersion = Context.ModelVersions.Find(request.Id);
            modelVersion.ModelVersionSpecifications.Clear();
            modelVersion.Pictures.Clear();
            modelVersion.Prices.Clear();


            Context.ModelVersions.Remove(modelVersion);

            Context.SaveChanges();
            
        }
    }
}
