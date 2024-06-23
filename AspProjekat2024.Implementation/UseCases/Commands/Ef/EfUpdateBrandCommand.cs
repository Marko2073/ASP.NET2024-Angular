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
    public class EfUpdateBrandCommand : EfUseCase, IUpdateBrandCommand
    {
        private readonly UpdateBrandDtoValidator _validator;
        public EfUpdateBrandCommand(DatabaseContext context, UpdateBrandDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Update Brand";

        public string Description => "Update Brand";

        public void Execute(UpdateBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = Context.Brands.Find(request.Id);

            brand.Name = request.Name;

            Context.SaveChanges();
            
        }
    }
}
