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
    public class EfDeletePictureCommand : EfUseCase, IDeletePictureCommand
    {
        private readonly DeletePictureDtoValidator _validator;
        public EfDeletePictureCommand(DatabaseContext context, DeletePictureDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Delete Picture";

        public string Description => "Delete Picture";

        public void Execute(DeleteDto request)
        {
            _validator.ValidateAndThrow(request);
            var picture = Context.Pictures.Find(request.Id);
            Context.Pictures.Remove(picture);
            Context.SaveChanges();
            
        }
    }
}
