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
    public class EfDeleteSpecificationCommand : EfUseCase, IDeleteSpecificationCommand
    {
        private readonly DeleteSpecificationDtoValidator _validator;
        public EfDeleteSpecificationCommand(DatabaseContext context, DeleteSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;

        }

        public int Id => 34;

        public string Name => "Delete Specification";

        public string Description => "Delete Specification";

        public void Execute(DeleteDto request)
        {
            _validator.ValidateAndThrow(request);
            var specification = Context.Specifications.Find(request.Id);
            Context.Specifications.Remove(specification);
            Context.SaveChanges();
           
        }
    }
}
