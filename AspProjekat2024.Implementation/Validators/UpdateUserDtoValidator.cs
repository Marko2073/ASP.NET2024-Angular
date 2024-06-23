using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        private readonly DatabaseContext _context;

        public UpdateUserDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MinimumLength(2).WithMessage("First name must have at least 2 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MinimumLength(2).WithMessage("Last name must have at least 2 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not in the correct format")
                .Must((dto, email) => !_context.Users.Any(u => u.Email == email && u.Id != dto.Id))
                .WithMessage("Email is already taken");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must have at least 6 characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required")
                .MinimumLength(9).WithMessage("Phone must have at least 9 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MinimumLength(2).WithMessage("Address must have at least 2 characters");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required")
                .MinimumLength(2).WithMessage("City must have at least 2 characters");


        }   
    }
}
