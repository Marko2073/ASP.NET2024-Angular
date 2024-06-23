using AspProjekat2024.Application.DTO.Creates;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Brand name is required.")
                .MinimumLength(3).WithMessage("Brand name must have at least 3 characters.")
                .MaximumLength(30).WithMessage("Brand name must have at most 30 characters.");
        }
    }
    

}
