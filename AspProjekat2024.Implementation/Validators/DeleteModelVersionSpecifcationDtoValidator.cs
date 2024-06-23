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
    public class DeleteModelVersionSpecifcationDtoValidator : AbstractValidator<DeleteDto>
    {
        private readonly DatabaseContext _context;
        public DeleteModelVersionSpecifcationDtoValidator(DatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => _context.ModelVersionSpecifications.Any(mvs => mvs.Id == x)).WithMessage("Model version specification with provided id doesn't exist.");
        }
    }
}
