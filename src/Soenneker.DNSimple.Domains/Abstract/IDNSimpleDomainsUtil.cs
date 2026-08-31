using Soenneker.DNSimple.OpenApiClient.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.Domains.Abstract;

/// <summary>
/// Utility class for managing DNSimple domains
/// </summary>
public interface IDNSimpleDomainsUtil
{
    /// <summary>
    /// Lists the domains returned by DNSimple for the configured account.
    /// </summary>
    /// <param name="nameLike">Optional filter for domain names</param>
    /// <param name="registrantId">Optional filter by registrant ID</param>
    /// <param name="sort">Optional DNSimple sort value such as <c>name:asc</c> or <c>expiration:desc</c>.</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The domains in the API response.</returns>
    ValueTask<IEnumerable<Domain>> List(string? nameLike = null, int? registrantId = null, string? sort = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a specific domain by name or ID
    /// </summary>
    /// <param name="domainNameOrId">The domain name or ID</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The domain details</returns>
    ValueTask<Domain?> Get(string domainNameOrId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new domain
    /// </summary>
    /// <param name="domainName">The name of the domain to create</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>The created domain</returns>
    ValueTask<Domain?> Create(string domainName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a domain
    /// </summary>
    /// <param name="domainNameOrId">The domain name or ID to delete</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    ValueTask Delete(string domainNameOrId, CancellationToken cancellationToken = default);
}
