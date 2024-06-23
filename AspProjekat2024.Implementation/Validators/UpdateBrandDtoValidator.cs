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
    public class UpdateBrandDtoValidator: AbstractValidator<UpdateBrandDto>
    {
        private readonly DatabaseContext _context;

        public UpdateBrandDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Brand name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                        .Must((dto, name) => !_context.Brands.Any(b => b.Name == name && b.Id != dto.Id))
                        .WithMessage(dto => $"Brand with name {dto.Name} already exists in database.");
                });
            RuleFor(x=>x.Id).Must(id => _context.Brands.Any(b => b.Id == id))
                .WithMessage("Brand with provided id does not exist in database.");
        }


    }
}
