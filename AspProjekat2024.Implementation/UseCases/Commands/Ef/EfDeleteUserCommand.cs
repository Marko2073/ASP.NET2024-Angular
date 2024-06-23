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
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        private readonly DeleteUSerDtoValidator _validator;
        public EfDeleteUserCommand(DatabaseContext context, DeleteUSerDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>35;

        public string Name => "Delete User";

        public string Description => "Delete User";

        public void Execute(DeleteDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = Context.Users.Find(request.Id);
            Context.Users.Remove(user);
            Context.SaveChanges();
            
        }
    }
}
