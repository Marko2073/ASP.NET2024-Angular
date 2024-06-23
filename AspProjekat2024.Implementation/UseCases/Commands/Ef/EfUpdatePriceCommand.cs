using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfUpdatePriceCommand : EfUseCase, IUpdatePriceCommand
    {
        private readonly UpdatePriceDtoValidator _validator;
        public EfUpdatePriceCommand(DatabaseContext context, UpdatePriceDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 25;

        public string Name => "Update Price";

        public string Description => "Update Price";

        public void Execute(UpdatePriceDto request)
        {
            _validator.ValidateAndThrow(request);
            var price = Context.Prices.Find(request.Id);
            price.PriceValue = request.Price;
            price.DateFrom = DateTime.Parse(request.DateFrom);
            price.DateTo = DateTime.Parse(request.DateTo);
            Context.SaveChanges();
            
        }
    }
}
