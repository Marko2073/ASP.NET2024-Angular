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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfUpdateUserAccessCommand : EfUseCase, IUpdateUseAccessCommand
    {
        private UpdateUserAccessDtoValidator _validator;
        public EfUpdateUserAccessCommand(DatabaseContext context, UpdateUserAccessDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Modify User Access";

        public string Description => "Modify user access";

        public void Execute(UpdateUserAccessDto request)
        {
            _validator.ValidateAndThrow(request);
            var userUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == request.UserId)
                                      .ToList();
            Context.UserUseCases.RemoveRange(userUseCases);

            Context.UserUseCases.AddRange(request.UseCaseIds.Select(x =>
            new Domain.UserUseCase
            {
                UserId = request.UserId,
                UseCaseId = x
            }));

            Context.SaveChanges();

            
        }
    }
}
