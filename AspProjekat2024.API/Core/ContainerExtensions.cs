using AspProjekat2024.Application.Logging;
using AspProjekat2024.Application.UseCases.Commands;
using AspProjekat2024.Application.UseCases.Queries;
using AspProjekat2024.Implementation.Logging;
using AspProjekat2024.Implementation.UseCases.Commands.Ef;
using AspProjekat2024.Implementation.UseCases.Queries.Ef;
using AspProjekat2024.Implementation;
using System.IdentityModel.Tokens.Jwt;
using AspProjekat2024.Implementation.Validators;
using AspProjekat2024.Application;
using AspProjekat2024.API.Core;
using AspProjekat2024.Application.Mail;

namespace AspProjekat2024.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<ICreateModelCommand, EfCreateModelCommand>();
            services.AddTransient<IGetModelsQuery, EfGetModelsQuery>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<IUpdateUseAccessCommand, EfUpdateUserAccessCommand>();
            services.AddTransient<UpdateUserAccessDtoValidator>();
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<CreateBrandDtoValidator>();
            services.AddTransient<CreateModelDtoValidator>();
            services.AddTransient<ICreateSpecificationCommand, EfCreateSpecificationCommand>();
            services.AddTransient<CreateSpecificationDtoValidator>();
            services.AddTransient<ICreateModelVersionCommand, EfCreateModelVesionsCommand>();
            services.AddTransient<CreateModelVersionDtoValidator>();
            services.AddTransient<IExLogger, DbExceptionLogger>();
            services.AddTransient<ICreateModelVersionSpecification, EfCreateModelVersionSpecificationCommand>();
            services.AddTransient<CreateModelVersionSpecificationDtoValidator>();
            services.AddTransient<ICreatePictureCommand, EfCreatePictureCommand>();
            services.AddTransient<CreatePictureDtoValidator>();
            services.AddTransient<ICreatePriceCommand, EfCreatePriceCommand>();
            services.AddTransient<CreatePriceDtoValidator>();
            services.AddTransient<ICreateUserCartCommand, EfCreateUserCartCommand>();
            services.AddTransient<CreateUserCartDtoValidator>();
            services.AddTransient<ICreatePurchaseCommand, EfCreatePurchaseCommand>();
            services.AddTransient<CreatePurchaseDtoValidator>();
            services.AddTransient<ICreateConfirmPurchaseCommand, EfCreateConfirmPurchaseCommand>();
            services.AddTransient<CreateConfirmPurchaseDtoValidator>();
            services.AddTransient<IGetProductsQuery, EfGetProductsQuery>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<UpdateBrandDtoValidator>();
            services.AddTransient<IUpdateModelCommand, EfUpdateModelCommand>();
            services.AddTransient<UpdateModelDtoValidator>();
            services.AddTransient<IGetModelVersionQuery, EfGetModelVersionsQuery>();
            services.AddTransient<IGetModelVersionSpecificationQuery, EfGetModelVersionSpecificationQuery>();
            services.AddTransient<IUpdateModelVersionCommand, EfUpdateModelVersionCommand>();
            services.AddTransient<UpdateModelVersionDtoValidator>();
            services.AddTransient<IUpdateModelVersionSpecificationsCommand, EfUpdateModeLVersionSpecificationsCommand>();
            services.AddTransient<UpdateModelVersionSpecificationsDtoValidator>();
            services.AddTransient<IGetPicturesQuery,EfGetPicturesQuery>();
            services.AddTransient<IUpdatePictureCommand, EfUpdatePictureCommand>();
            services.AddTransient<UpdatePictureDtoValidator>();
            services.AddTransient<IGetPriceQuery, EfGetPricesQuery>();
            services.AddTransient<IUpdatePriceCommand, EfUpdatePriceCommand>();
            services.AddTransient<UpdatePriceDtoValidator>();
            services.AddTransient<IGetSpecificationsQuery, EfGetSpecificationsQuery>();
            services.AddTransient<IUpdateSpecificationCommand, EfUpdateSpecificationCommand>();
            services.AddTransient<UpdateSpecificationDtoValidator>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<DeleteBrandDtoValidator>();
            services.AddTransient<IDeleteModelCommand, EfDeleteModelCommand>();
            services.AddTransient<DeleteModelDtoValidator>();
            services.AddTransient<IDeleteModelVersionCommand, EfDeleteModelVersionCommand>();
            services.AddTransient<DeleteModelVersionDtoValidator>();
            services.AddTransient<IDeleteModelVersionSpecificationCommand, EfDeleteModelversionSpecificationCommand>();
            services.AddTransient<DeleteModelVersionSpecifcationDtoValidator>();
            services.AddTransient<IDeletePictureCommand, EfDeletePictureCommand>();
            services.AddTransient<DeletePictureDtoValidator>();
            services.AddTransient<IDeletePriceCommand, EfDeletePriceCommand>();
            services.AddTransient<DeletePriceDtoValidator>();
            services.AddTransient<IDeleteSpecificationCommand, EfDeleteSpecificationCommand>();
            services.AddTransient<DeleteSpecificationDtoValidator>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<DeleteUSerDtoValidator>();
            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
            services.AddTransient<IGetOneBrandQuery, EfGetOneBrandQuery>();
            services.AddTransient<IGetOneModelQuery, EfGetOneModelQuery>();
            services.AddTransient<IGetOneModelVersionQuery, EfGetOneModelVersionQuery>();
            services.AddTransient<IDeletePurchaseCommand, EfDeletePurchaseCommand>();
            services.AddTransient<DeletePurchaseDtoValidator>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<InsertProductDtoValidator>();
            services.AddTransient<IGetUsersQuery, EfGetUserQuery>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<IGetOneSpecificationQuery, EfGetOneSpecificationQuery >();
            services.AddTransient<IGetLogsQuery, EfGetLogsQuery>();
            services.AddTransient<IGetTablesQuery, EfGetTablesQuery>();
            services.AddTransient<IGetColumnsQuery, EfGetColumnsQuery>();
            services.AddTransient<IGetAllSpecificationsQuery, EfGetAllSpecQuery>();
            services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
            services.AddTransient<IGetUserRoleQuery, EfGetUserRoleQuery>();





            services.AddTransient<IEmailService>(provider =>
                new EmailService("smtp.gmail.com", 587, "marko.markovic.33.21@ict.edu.rs", "huvumdbwlqayjfzm"));
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
