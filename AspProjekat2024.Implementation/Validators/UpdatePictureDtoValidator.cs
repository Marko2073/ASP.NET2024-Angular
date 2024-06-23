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
    public class UpdatePictureDtoValidator: AbstractValidator<UpdatePictureDto>
    {
        private readonly DatabaseContext _context;
        public UpdatePictureDtoValidator(DatabaseContext context)
        {
            _context = context;


            RuleFor(x => x.ModelVersionId)
                .Must(ModelVersionExists)
                .WithMessage("Model version with an id  does not exist.");
        }
        public bool ModelVersionExists(int modelVersionId)
        {
            return _context.ModelVersions.Any(x => x.Id == modelVersionId);
        }
    }
}
