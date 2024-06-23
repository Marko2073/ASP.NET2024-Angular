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
    public class DeleteBrandDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly DatabaseContext _context;

        public DeleteBrandDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(Exists)
                .WithMessage("Brand with an id of {PropertyValue} does not exist.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(NotUsed)
                        .WithMessage("Brand with an id of {PropertyValue} is already in use.");
                });
        }

        private bool Exists(int id)
        {
            return _context.Brands.Any(x => x.Id == id);
        }

        private bool NotUsed(int id)
        {
            return !_context.Models.Any(x => x.BrandId == id);
        }
    }
}
