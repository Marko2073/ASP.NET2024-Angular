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
    public class EfUpdateModeLVersionSpecificationsCommand : EfUseCase, IUpdateModelVersionSpecificationsCommand
    {
        private readonly UpdateModelVersionSpecificationsDtoValidator _validator;
        public EfUpdateModeLVersionSpecificationsCommand(DatabaseContext context, UpdateModelVersionSpecificationsDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Update Model Version Specifications ";

        public string Description => "Update Model Version Specifications ";

        public void Execute(UpdateModelVersionSpecificationsDto request)
        {
            _validator.ValidateAndThrow(request);

            var modelVersionSpecifications = Context.ModelVersionSpecifications.Where(x => x.ModelVersionId == request.ModelVersionId).ToList();

            foreach (var item in modelVersionSpecifications)
            {
                Context.ModelVersionSpecifications.Remove(item);
            }

            foreach (var item in request.SpecificationIds)
            {
                Context.ModelVersionSpecifications.Add(new Domain.ModelVersionSpecification
                {
                    ModelVersionId = request.ModelVersionId,
                    SpecificationId = item,
                });
            }
            

            Context.SaveChanges();
            
        }
    }
}
