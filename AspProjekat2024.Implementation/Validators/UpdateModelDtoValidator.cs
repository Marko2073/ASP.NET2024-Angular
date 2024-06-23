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
    public class UpdateModelDtoValidator : AbstractValidator<UpdateModelDto>
    {
        private readonly DatabaseContext _context;

        public UpdateModelDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Model name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name)
                        .Must((dto, name) => !_context.Models.Any(m => m.Name == name && m.Id != dto.Id))
                        .WithMessage(dto => $"Model with name {dto.Name} already exists in database.");
                });
            RuleFor(x => x.Id).Must(id => _context.Models.Any(m => m.Id == id))
                .WithMessage("Model with provided id does not exist in database.");
            RuleFor(x => x.BrandId).Must(id => _context.Brands.Any(b => b.Id == id))
                .WithMessage("Brand with provided id does not exist in database.");
        }
    }
}
