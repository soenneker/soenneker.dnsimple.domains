using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DNSimple.Client.Registrars;
using Soenneker.DNSimple.Domains.Abstract;

namespace Soenneker.DNSimple.Domains.Registrars;

/// <summary>
/// A .NET typesafe implementation of DNSimple's Domains API
/// </summary>
public static class DNSimpleDomainsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IDnSimpleDomainsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleDomainsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddDNSimpleClientUtilAsSingleton();
        services.TryAddSingleton<IDnSimpleDomainsUtil, DNSimpleDomainsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IDnSimpleDomainsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleDomainsUtilAsScoped(this IServiceCollection services)
    {
        services.AddDNSimpleClientUtilAsScoped();
        services.TryAddScoped<IDnSimpleDomainsUtil, DNSimpleDomainsUtil>();

        return services;
    }
}
