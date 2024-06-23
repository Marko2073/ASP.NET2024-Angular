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
    public class UpdatePriceDtoValidator : AbstractValidator<UpdatePriceDto>
    {
        private readonly DatabaseContext _context;

        public UpdatePriceDtoValidator(DatabaseContext context)
        {
            _context = context;

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");
            RuleFor(x=>x.Id).Must(Exists).WithMessage("Price with an id of {PropertyValue} does not exist");
            RuleFor(x => x.DateFrom)
                .NotEmpty()
                .WithMessage("Date from is required")
                .Must(x => DateTime.TryParse(x, out _))
                .WithMessage("Date from is not in a valid format");
            RuleFor(x => x.DateTo)
                .NotEmpty()
                .WithMessage("Date to is required")
                .Must(x => DateTime.TryParse(x, out _))
                .WithMessage("Date to is not in a valid format")
                .Must((dto, dateTo) => DateTime.Parse(dateTo) > DateTime.Parse(dto.DateFrom))
                .WithMessage("Date to must be greater than date from");

        }

        private bool Exists(int id)
        {
            return _context.Prices.Any(x => x.Id == id);
        }

    }
}
