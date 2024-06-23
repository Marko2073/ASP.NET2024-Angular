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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfCreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        private CreateBrandDtoValidator _validator;

        public EfCreateBrandCommand(DatabaseContext context, CreateBrandDtoValidator validator)
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Create Brand";

        public string Description => "Create new brand";

        public void Execute(CreateBrandDto request)
        {
            _validator.ValidateAndThrow(request);
            Context.Brands.Add(new Domain.Brand
            {
                Name = request.Name
            });
            Context.SaveChanges();

            
        }
    }
}
