using AspProjekat2024.Application.DTO.Updates;
using AspProjekat2024.Application.Exceptions;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfUpdatePictureCommand : EfUseCase, IUpdatePictureCommand
    {
        private readonly UpdatePictureDtoValidator _validator;
        public EfUpdatePictureCommand(DatabaseContext context, UpdatePictureDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Update Picture";

        public string Description => "Update Picture";

        public void Execute(UpdatePictureDto request)
        {
            _validator.ValidateAndThrow(request);
            if (request.PicturePath != null)
            {
                var extension = Path.GetExtension(request.PicturePath.FileName);
                var filename = Guid.NewGuid().ToString() + extension;
                var savepath = Path.Combine("wwwroot", "images", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(savepath));

                using (var fs = new FileStream(savepath, FileMode.Create))
                {
                    request.PicturePath.CopyTo(fs);
                }

                var picture1 = Context.Pictures.Find(request.Id);
                picture1.Path = "/images/" + filename;

                
                Context.SaveChanges();
            }

        }
    }
}
