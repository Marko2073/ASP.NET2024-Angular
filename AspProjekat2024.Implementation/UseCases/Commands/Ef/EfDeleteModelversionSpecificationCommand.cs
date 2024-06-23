using AspProjekat2024.Application.DTO;
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
    public class EfDeleteModelversionSpecificationCommand : EfUseCase, IDeleteModelVersionSpecificationCommand
    {
        private readonly DeleteModelVersionSpecifcationDtoValidator _validator;
        public EfDeleteModelversionSpecificationCommand(DatabaseContext context, DeleteModelVersionSpecifcationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 31;

        public string Name => "Delete Model Version Specification";

        public string Description => "Delete Model Version Specification";

        public void Execute(DeleteDto request)
        {
            _validator.ValidateAndThrow(request);
            var modelVersionSpecification = Context.ModelVersionSpecifications.Find(request.Id);
            Context.ModelVersionSpecifications.Remove(modelVersionSpecification);
            Context.SaveChanges();

            
        }
    }
}
