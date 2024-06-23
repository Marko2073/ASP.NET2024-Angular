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
    public class EfDeleteBrandCommand : EfUseCase, IDeleteBrandCommand
    {
        private readonly DeleteBrandDtoValidator _validator;
        public EfDeleteBrandCommand(DatabaseContext context, DeleteBrandDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 28;

        public string Name => "Delete Brand";

        public string Description => "Delete Brand";

        public void Execute(DeleteDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = Context.Brands.Find(request.Id);

            Context.Brands.Remove(brand);

            Context.SaveChanges();
            
        }
    }
}
