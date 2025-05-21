using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.DNSimple.Client.Registrars;
using Soenneker.DNSimple.Domains.Abstract;
using Soenneker.DNSimple.OpenApiClientUtil.Registrars;

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
        services.AddDNSimpleOpenApiClientUtilAsSingleton().TryAddSingleton<IDNSimpleDomainsUtil, DNSimpleDomainsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IDnSimpleDomainsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddDNSimpleDomainsUtilAsScoped(this IServiceCollection services)
    {
        services.AddDNSimpleOpenApiClientUtilAsSingleton().TryAddScoped<IDNSimpleDomainsUtil, DNSimpleDomainsUtil>();

        return services;
    }
}