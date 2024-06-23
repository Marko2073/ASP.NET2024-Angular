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
    public class EfCreateUserCartCommand : EfUseCase, ICreateUserCartCommand
    {
        private readonly CreateUserCartDtoValidator _validator;
        public EfCreateUserCartCommand(DatabaseContext context, CreateUserCartDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Create User Cart";

        public string Description => "Create USer Cart d";

        public void Execute(CreateUserCartDto request)
        {
            _validator.ValidateAndThrow(request);

            Context.UserCarts.Add(new Domain.UserCart
            {
                UserId = request.UserId
            });


            Context.SaveChanges();
            
        }
    }
}
