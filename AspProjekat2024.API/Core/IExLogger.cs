using AspProjekat2024.Application;

namespace AspProjekat2024.API.Core
{
    public interface IExLogger
    {
        Guid Log(Exception ex, IApplicationActor actor );
    }
}
