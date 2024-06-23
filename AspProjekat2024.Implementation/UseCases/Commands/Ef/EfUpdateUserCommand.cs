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
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly UpdateUserDtoValidator _validator;

        public EfUpdateUserCommand(DatabaseContext context, UpdateUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>28;

        public string Name => "Update User";

        public string Description => "Update User";

        public void Execute(UpdateUserDto request)
        {
            _validator.ValidateAndThrow(request);
            if (request.Path != null)
            {
                var extension = Path.GetExtension(request.Path.FileName);
                var filename = Guid.NewGuid().ToString() + extension;
                var savepath = Path.Combine("wwwroot", "images", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(savepath));

                using (var fs = new FileStream(savepath, FileMode.Create))
                {
                    request.Path.CopyTo(fs);
                }

                var user = Context.Users.Find(request.Id);

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.Password = request.Password;
                user.Phone = request.Phone;
                user.Address = request.Address;
                user.City = request.City;
                user.Path = "/images/" + filename;
            }
            

            Context.SaveChanges();
            
        }
    }
}
