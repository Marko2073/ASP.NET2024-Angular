using AspProjekat2024.Application.DTO.Gets;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AspProjekat2024.Implementation.UseCases.Commands.Ef
{
    public class EfCreateProductCommand : EfUseCase, ICreateProductCommand
    {
        private readonly InsertProductDtoValidator _validator;

        public EfCreateProductCommand(DatabaseContext context, InsertProductDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 41;

        public string Name => "Insert Product";

        public string Description => "Insert Product";

        public void Execute(InsertProductDto request)
        {
            _validator.ValidateAndThrow(request);

            if (!DateTime.TryParse(request.DateFrom, out var dateFrom))
            {
                throw new ValidationException("DateFrom is not a valid date");
            }

            if (!DateTime.TryParse(request.DateTo, out var dateTo))
            {
                throw new ValidationException("DateTo is not a valid date");
            }

            var price = new Price
            {
                PriceValue = request.Price,
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            var modelVersionSpecifications = request.Specifications.Select(s => new ModelVersionSpecification
            {
                SpecificationId = s.Id
            }).ToList();

            var modelVersion = new ModelVersion
            {
                ModelId = request.ModelId,
                StockQuantity = request.StockQuantity,
                Prices = new List<Price> { price },
                ModelVersionSpecifications = modelVersionSpecifications,
            };

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

                var picture = new Picture
                {
                    Path = "/images/" + filename
                };

                modelVersion.Pictures = new List<Picture> { picture };
            }

            Context.ModelVersions.Add(modelVersion);
            Context.SaveChanges();
        }
    }
}
