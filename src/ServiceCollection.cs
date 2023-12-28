using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OregonNexus.Broker.Connector.Fixture;

public class ServiceCollection : IConnectorServiceCollection
{
    /*
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
    {
        return services;
    }
    */

    public static IServiceCollection AddDependencies(IServiceCollection services)
    {
        // Authentication
        //services.AddScoped<ThirdPartyApplication>();

        return services;
    }
}