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
    public class DeletePriceDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly DatabaseContext _context;

        public DeletePriceDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Price Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => _context.Prices.Any(p => p.Id == id))
                        .WithMessage("Price with an id of {PropertyValue} doesn't exist.");
                });
        }


    }
}
