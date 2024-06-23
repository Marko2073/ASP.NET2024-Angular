using AspProjekat2024.Application.DTO;
using AspProjekat2024.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class UpdateUserAccessDtoValidator : AbstractValidator<UpdateUserAccessDto>
    {
        private static int updateUserAccessId = 6;
        public UpdateUserAccessDtoValidator(DatabaseContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => context.Users.Any(u => u.Id == x)).WithMessage("User with provided id doesn't exist.");


            RuleFor(x => x.UseCaseIds)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => x.All(id => id > 0 && id <=45)).WithMessage("Invalid usecase id range.")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");


        }
    }
}
