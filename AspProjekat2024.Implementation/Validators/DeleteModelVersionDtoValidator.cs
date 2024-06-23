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
    public class DeleteModelVersionDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly DatabaseContext _context;
        public DeleteModelVersionDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                 .Must(Exists)
                 .WithMessage("Model with an id of {PropertyValue} does not exist.")
                 .DependentRules(() =>
                 {
                     RuleFor(x => x.Id)
                         .Must(NotUsed)
                         .WithMessage("Model with an id of {PropertyValue} is already in use.");
                 });
        }

        private bool Exists(int id)
        {
            return _context.ModelVersions.Any(x => x.Id == id);
        }

        private bool NotUsed(int id)
        {
            return !_context.Purchases.Any(x => x.ModelVersionId == id);
        }
    }
}
