using AspProjekat2024.Application.DTO;
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
    public class EfDeletePriceCommand : EfUseCase, IDeletePriceCommand
    {
        private readonly DeletePriceDtoValidator _validator;
        public EfDeletePriceCommand(DatabaseContext context, DeletePriceDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 33;

        public string Name => "Delete Price";

        public string Description => "Delete Price";

        public void Execute(DeleteDto request)
        {
            _validator.ValidateAndThrow(request);
            var price = Context.Prices.Find(request.Id);
            Context.Prices.Remove(price);
            Context.SaveChanges();

            
        }


    }
}
