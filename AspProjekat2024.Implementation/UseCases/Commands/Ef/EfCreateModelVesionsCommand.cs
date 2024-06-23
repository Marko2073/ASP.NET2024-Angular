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
    public class EfCreateModelVesionsCommand : EfUseCase, ICreateModelVersionCommand
    {
        private CreateModelVersionDtoValidator _validator;
        public EfCreateModelVesionsCommand(DatabaseContext context, CreateModelVersionDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Model Create";

        public string Description => "Create new model";

        public void Execute(CreateModelVersionDto request)
        {
            _validator.ValidateAndThrow(request);

            var model = new Domain.ModelVersion
            {
                StockQuantity = request.Quantity,
                ModelId = request.ModelId
            };

            Context.ModelVersions.Add(model);
            Context.SaveChanges();
            
        }
    }
}
