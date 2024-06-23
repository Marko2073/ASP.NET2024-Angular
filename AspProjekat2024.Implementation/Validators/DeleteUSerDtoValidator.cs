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
    public class DeleteUSerDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly DatabaseContext _context;
        public DeleteUSerDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => _context.Users.Any(p => p.Id == id))
                        .WithMessage("User with an id of {PropertyValue} doesn't exist.");
                });
            RuleFor(x => x.Id)
                .Must(DontHaveProccesedCarts)
                .WithMessage("User with an id of {PropertyValue} is used in UserUseCases.");
        }

        private bool DontHaveProccesedCarts(int id)
        {
            return !_context.UserCarts.Any(ps => ps.UserId == id && ps.IsProcessed==true);
        }
    }
}
