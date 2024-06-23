using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using System;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfCreatePriceCommand : EfUseCase, ICreatePriceCommand
    {
        private readonly CreatePriceDtoValidator _validator;
        public EfCreatePriceCommand(DatabaseContext context, CreatePriceDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Add Price";

        public string Description => "Create product price";

        public void Execute(CreatePriceDto request)
        {
            _validator.ValidateAndThrow(request);

            if (!DateTime.TryParse(request.DateFrom, out var dateFrom))
            {
                throw new ValidationException("DateFrom is not a valid date");
            }
            if (!DateTime.TryParse(request.DateTo, out var dateTo))
            {
                throw new ValidationException("DateTo is not a valid date");
            }

            Context.Prices.Add(new Domain.Price
            {
                PriceValue = request.Price,
                ModelVersionId = request.ModelVersionId,
                DateFrom = dateFrom,
                DateTo = dateTo
            });

            Context.SaveChanges();
        }
    }
}
