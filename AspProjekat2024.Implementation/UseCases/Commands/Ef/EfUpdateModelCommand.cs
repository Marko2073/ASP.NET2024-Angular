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
    public class EfUpdateModelCommand : EfUseCase, IUpdateModelCommand
    {
        private readonly UpdateModelDtoValidator _validator;
        public EfUpdateModelCommand(DatabaseContext context, UpdateModelDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Update Model";

        public string Description => "Update Model";

        public void Execute(UpdateModelDto request)
        {
            _validator.ValidateAndThrow(request);

            var model = Context.Models.Find(request.Id);

            model.Name = request.Name;
            model.BrandId = request.BrandId;

            Context.SaveChanges();

            
        }
    }
}
