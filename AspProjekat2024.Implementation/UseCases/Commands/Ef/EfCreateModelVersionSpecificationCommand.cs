using AspProjekat2024.Application.DTO.Creates;
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
    public class EfCreateModelVersionSpecificationCommand : EfUseCase, ICreateModelVersionSpecification
    {
        public readonly CreateModelVersionSpecificationDtoValidator _validator;
        public EfCreateModelVersionSpecificationCommand(DatabaseContext context, CreateModelVersionSpecificationDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id =>9;

        public string Name => "Add specification to Model";

        public string Description => "Adding specification to model version";

        public void Execute(CreateModelVersionSpecificationDto request)
        {
            _validator.ValidateAndThrow(request);

            var modelVersionSpecification = new ModelVersionSpecification
            {
                ModelVersionId = request.ModelVersionId,
                SpecificationId = request.SpecificationId
            };

            Context.ModelVersionSpecifications.Add(modelVersionSpecification);
            Context.SaveChanges();

            
        }
    }
}
