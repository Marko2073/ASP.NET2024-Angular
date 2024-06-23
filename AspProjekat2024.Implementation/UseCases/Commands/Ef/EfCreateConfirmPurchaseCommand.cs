using AspProjekat2024.Application.DTO.Creates;
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
    public class EfCreateConfirmPurchaseCommand : EfUseCase, ICreateConfirmPurchaseCommand
    {
        private readonly CreateConfirmPurchaseDtoValidator _validator;
        public EfCreateConfirmPurchaseCommand(DatabaseContext context, CreateConfirmPurchaseDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Confirm purchase";

        public string Description => "Confirm purchase";

        public void Execute(CreateConfirmPurchaseDto request)
        {
            _validator.ValidateAndThrow(request);

            var purchase = Context.UserCarts.Where(x=>x.UserId==request.UserId && x.IsProcessed==false);
            if (purchase == null)
            {
                throw new Exception("User cart does not exist");
            }

            purchase.First().IsProcessed = true;

            purchase.First().UpdatedAt = DateTime.UtcNow;

            var usercart = new Domain.UserCart
            {
                UserId = request.UserId
            };

            Context.UserCarts.Add(usercart);


            Context.SaveChanges();
            
        }
    }
}
