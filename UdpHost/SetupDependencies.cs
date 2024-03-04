using AdsbSupport.UdpServerSample.Application;
using AdsbSupport.UdpServerSample.Core;
using Microsoft.Extensions.DependencyInjection;


namespace AdsbSupport.UdpServerSample.UdpHost;

public static class SetupDependencies
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUdpListener, UdpListener>();
        services.AddScoped<IMessageHandler, EchoMessageHandler>();
        return services;
    }
}
