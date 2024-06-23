using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class CreateModelDtoValidator : AbstractValidator<CreateModelDto>
    {
        private readonly DatabaseContext _context;
        public CreateModelDtoValidator(DatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Model name is required")
                .MinimumLength(3).WithMessage("Model name must have at least 3 characters")
                .MaximumLength(30).WithMessage("Model name must have at most 30 characters");

            RuleFor(x => x.BrandId)
                .NotEmpty().WithMessage("Brand id is required")
                .Must(BrandExists).WithMessage("Brand id must exist in the Brands table.");
        }

        private bool BrandExists(int brandId)
        {
            return _context.Brands.Any(b => b.Id == brandId);
        }
    }
}
