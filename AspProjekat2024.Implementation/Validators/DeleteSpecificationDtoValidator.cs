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
    public class DeleteSpecificationDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly DatabaseContext _context;

        public DeleteSpecificationDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Specification Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Id)
                        .Must(id => _context.Specifications.Any(p => p.Id == id))
                        .WithMessage("Specification with an id of {PropertyValue} doesn't exist.");
                });
            RuleFor(x => x.Id)
                .Must(id => !_context.ModelVersionSpecifications.Any(ps => ps.SpecificationId == id))
                .WithMessage("Specification with an id of {PropertyValue} is used in ModelVersions.");
        }
    }
    
}
