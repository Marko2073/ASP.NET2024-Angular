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
    public class EfUpdateSpecificationCommand : EfUseCase, IUpdateSpecificationCommand
    {
        private readonly UpdateSpecificationDtoValidator _validator;
        public EfUpdateSpecificationCommand(DatabaseContext context, UpdateSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 27;

        public string Name => "Update Specification";

        public string Description => "Update Specification";

        public void Execute(UpdateSpecificationDto request)
        {
            _validator.ValidateAndThrow(request);

            var specification = Context.Specifications.Find(request.Id);

            specification.Name = request.Name;
            specification.ParentId = request.ParentId;

            Context.SaveChanges();
            
        }
    }
}
