using AspProjekat2024.Application.DTO.Creates;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.DataAccess;
using AspProjekat2024.Domain;
using AspProjekat2024.Implementation.UseCases;
using AspProjekat2024.Implementation.Validators;
using FluentValidation;

public class EfCreatePictureCommand : EfUseCase, ICreatePictureCommand
{
    private readonly CreatePictureDtoValidator _validator;
    public EfCreatePictureCommand(DatabaseContext context, CreatePictureDtoValidator validator) : base(context)
    {
        _validator = validator;
    }

    public int Id => 10;

    public string Name => "Upload picture";

    public string Description => "Picture upload";

    public void Execute(CreatePictureDto request)
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

            
        }
    }
}

