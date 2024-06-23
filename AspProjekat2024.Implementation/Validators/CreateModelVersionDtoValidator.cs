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
    public class CreateModelVersionDtoValidator : AbstractValidator<CreateModelVersionDto>
    {
        public readonly DatabaseContext _context;
        public CreateModelVersionDtoValidator(DatabaseContext context)
        {
            _context = context;
            
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Model must have quantity");
            RuleFor(x => x.Quantity).GreaterThan(-1).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.ModelId).NotEmpty().WithMessage("Model id is required");
            RuleFor(x => x.ModelId).NotEmpty().Must(ModelExists).WithMessage("Model with provided id doesn't exist.");

            
        }
        private bool ModelExists(int modelId)
        {
            return _context.Models.Any(m => m.Id == modelId);

        }
    }
}
