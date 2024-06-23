using AspProjekat2024.Application.DTO.Creates;
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
    public class EfCreateSpecificationCommand : EfUseCase, ICreateSpecificationCommand
    {
        private CreateSpecificationDtoValidator _validator;
        public EfCreateSpecificationCommand(DatabaseContext context, CreateSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>7;

        public string Name => "Adding new specification";

        public string Description => "Adding new specification";

        public void Execute(CreateSpecificationDto request)
        {
            _validator.ValidateAndThrow(request);

            var specification = new Domain.Specification
            {
                Name = request.Name,
                ParentId = request.ParentId
            };

            Context.Specifications.Add(specification);
            Context.SaveChanges();
            
        }
    }
}
