using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class InsertProductDtoValidator : AbstractValidator<InsertProductDto>
    {
        private readonly DatabaseContext _context;

        public InsertProductDtoValidator(DatabaseContext context)
        {
            _context = context;

            

            RuleFor(x => x.ModelId)
                .NotEmpty()
                .WithMessage("Model Id is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.ModelId)
                        .Must(id => _context.Models.Any(p => p.Id == id))
                        .WithMessage("Model with an id of {PropertyValue} doesn't exist.");
                });
            RuleFor(x=>x.Price)
                .NotEmpty()
                .WithMessage("Price is required.")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.");
                
            RuleFor(x => x.PicturePath)
                .NotEmpty()
                .WithMessage("Product Pictures are required.");
            RuleFor(x => x.Specifications)
                .NotEmpty()
                .WithMessage("Product Specifications are required.");
            RuleFor(x => x.StockQuantity)
                .NotEmpty()
                .WithMessage("Stock Quantity is required.")
                .GreaterThan(0)
                .WithMessage("Stock Quantity must be greater than 0.");




          
        }
    }
}
