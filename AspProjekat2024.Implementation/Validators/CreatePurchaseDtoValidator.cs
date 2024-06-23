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
    public class CreatePurchaseDtoValidator : AbstractValidator<CreatePurchaseDto>
    {
        private readonly DatabaseContext _context;

        public CreatePurchaseDtoValidator(DatabaseContext context)
        {
            _context = context;

           

            RuleFor(x => x.ModelVersionId)
                .NotEmpty()
                .WithMessage("Model version is required.")
                .Must(ModelVersionExists)
                .WithMessage("Model version does not exist.");

        }

        private bool ModelVersionExists(int modelVersionId)
        {
            return _context.ModelVersions.Any(x => x.Id == modelVersionId);
        }

        private bool UserCartExists(int userCartId)
        {
            return _context.UserCarts.Any(x => x.Id == userCartId);
        }

        

    }
}
