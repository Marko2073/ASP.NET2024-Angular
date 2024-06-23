using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfUpdateModelVersionCommand : EfUseCase, IUpdateModelVersionCommand
    {

        public readonly UpdateModelVersionDtoValidator _validator;
        public EfUpdateModelVersionCommand(DatabaseContext context, UpdateModelVersionDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Update Model Version";

        public string Description => "Update Model Version";

        public void Execute(UpdateModelVersionDto request)
        {
            _validator.ValidateAndThrow(request);

            var modelVersion = Context.ModelVersions.Find(request.Id);

            modelVersion.ModelId = request.ModelId;

            
            Context.SaveChanges();

            
        }
    }
}
