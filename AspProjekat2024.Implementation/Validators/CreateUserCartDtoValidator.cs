using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat2024.Implementation.Validators
{
    public class CreateUserCartDtoValidator : AbstractValidator<CreateUserCartDto>
    {
        private readonly DatabaseContext _context;
        public CreateUserCartDtoValidator(DatabaseContext context)
        {
            _context = context;
            RuleFor(x => x.UserId).Must(UserExists).WithMessage("User with an id of {PropertyValue} does not exist.");
        }

        private bool UserExists(int userId)
        {
            return _context.Users.Any(x => x.Id == userId);
        }
    }
}
