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
    public class UpdateModelVersionDtoValidator : AbstractValidator<UpdateModelVersionDto>
    {
        public readonly DatabaseContext _context;

        public UpdateModelVersionDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.ModelId)
                .NotEmpty()
                .WithMessage("Model id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.ModelId)
                        .Must(id => _context.Models.Any(m => m.Id == id))
                        .WithMessage(dto => $"Model with id {dto.ModelId} does not exist in database.");
                });
            RuleFor(x => x.Id)
                .Must(id => _context.ModelVersions.Any(mv => mv.Id == id))
                .WithMessage("Model version with provided id does not exist in database.");
        }
    }
}
