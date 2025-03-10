using Soenneker.DNSimple.Domains.Requests;
using Soenneker.DNSimple.Domains.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.Domains.Abstract;

/// <summary>
/// Interface for DNSimple domain-related operations.
/// </summary>
public interface IDnSimpleDomainsUtil
{
    /// <summary>
    /// Lists all domains in the account.
    /// </summary>
    /// <param name="nameFilter">Filter domains by name.</param>
    /// <param name="registrantId">Filter domains by registrant ID.</param>
    /// <param name="test">Indicates whether to use a test environment.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask<DomainListResponse?> ListDomains(string? nameFilter = null, int? registrantId = null, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a domain.
    /// </summary>
    ValueTask<DomainResponse?> CreateDomain(DomainCreateRequest request, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details of a domain.
    /// </summary>
    ValueTask<DomainResponse?> GetDomain(string domain, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a domain.
    /// </summary>
    ValueTask<bool> DeleteDomain(string domain, bool test = false, CancellationToken cancellationToken = default);
}
