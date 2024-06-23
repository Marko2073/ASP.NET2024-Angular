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
    public class UpdateModelVersionSpecificationsDtoValidator : AbstractValidator<UpdateModelVersionSpecificationsDto>
    {
        private readonly DatabaseContext _context;

        public UpdateModelVersionSpecificationsDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.ModelVersionId)
                .NotEmpty()
                .WithMessage("Model version id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.ModelVersionId)
                        .Must(id => _context.ModelVersions.Any(mv => mv.Id == id))
                        .WithMessage(dto => $"Model version with id {dto.ModelVersionId} does not exist in database.");
                });
            RuleForEach(x => x.SpecificationIds)
                .Must(SpecificationExist)
                .WithMessage("Specification with provided id does not exist in database.");
        }

        private bool SpecificationExist(int id)
        {
            return _context.Specifications.Any(s => s.Id == id);
        }
    }
}
