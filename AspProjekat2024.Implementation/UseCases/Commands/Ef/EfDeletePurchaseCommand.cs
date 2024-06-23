using AspProjekat2024.Application.DTO;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfDeletePurchaseCommand : EfUseCase, IDeletePurchaseCommand
    {
        private readonly DeletePurchaseDtoValidator _validator;
        public EfDeletePurchaseCommand(DatabaseContext context, DeletePurchaseDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 40;

        public string Name => "Delete Item From Cart";

        public string Description => "Delete Item From Cart";

        public void Execute(DeleteDto request)
        {
            _validator.ValidateAndThrow(request);

            var purchase = Context.Purchases
                .Include(p => p.UserCart) 
                .FirstOrDefault(p => p.Id == request.Id);

            if (purchase == null)
            {
                throw new Exception($"Purchase with an id of {request.Id} doesn't exist.");
            }

            if (purchase.UserCart.IsProcessed)
            {
                throw new Exception("Cart with that item is already processed.");
            }

            Context.Purchases.Remove(purchase);
            Context.SaveChanges();
        }
    }
}
