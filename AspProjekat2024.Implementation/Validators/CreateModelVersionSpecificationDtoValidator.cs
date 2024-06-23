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
    public class CreateModelVersionSpecificationDtoValidator : AbstractValidator<CreateModelVersionSpecificationDto>
    {
        private readonly DatabaseContext _context;
        public CreateModelVersionSpecificationDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.ModelVersionId)
                .Must(ModelVersionExists)
                .WithMessage("Model version with an id  does not exist.");
                
                
            RuleFor(x => x.SpecificationId)
                .Must(SpecificationExists)
                .WithMessage("Specification with an id does not exist.");
               

        }
        public bool ModelVersionExists(int modelVersionId)
        {
            return _context.ModelVersions.Any(x => x.Id == modelVersionId);
        }
        public bool SpecificationExists(int specificationId)
        {
            return _context.Specifications.Any(x => x.Id == specificationId);
        }



    }
}
