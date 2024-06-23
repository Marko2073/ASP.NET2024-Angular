using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class CreatePriceDtoValidator : AbstractValidator<CreatePriceDto>
    {
        private readonly DatabaseContext _context;
        public CreatePriceDtoValidator(DatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");

            RuleFor(x => x.ModelVersionId)
                .Must(ModelVersionExists)
                .WithMessage("Model version with an id of {PropertyValue} does not exist");

            RuleFor(x => x.DateFrom)
                .NotEmpty()
                .WithMessage("Date from is required")
                .Must(BeAValidDate)
                .WithMessage("Date from must be a valid date")
                .Must(BeInTheFuture)
                .WithMessage("Date from must be in the future");

            RuleFor(x => x.DateTo)
                .NotEmpty()
                .WithMessage("Date to is required")
                .Must(BeAValidDate)
                .WithMessage("Date to must be a valid date")
                .Must((model, dateTo) => BeGreaterThanDateFrom(model.DateFrom, dateTo))
                .WithMessage("Date to must be greater than date from");
        }

        private bool BeAValidDate(string date)
        {
            return DateTime.TryParse(date, out _);
        }

        private bool BeInTheFuture(string date)
        {
            if (DateTime.TryParse(date, out var parsedDate))
            {
                return parsedDate > DateTime.Now;
            }
            return false;
        }

        private bool BeGreaterThanDateFrom(string dateFrom, string dateTo)
        {
            if (DateTime.TryParse(dateFrom, out var parsedDateFrom) &&
                DateTime.TryParse(dateTo, out var parsedDateTo))
            {
                return parsedDateTo > parsedDateFrom;
            }
            return false;
        }

        private bool ModelVersionExists(int modelVersionId)
        {
            // Implement your logic to check if the model version exists in the database
            // For example:
            return _context.ModelVersions.Any(mv => mv.Id == modelVersionId);
        }
    }
}
