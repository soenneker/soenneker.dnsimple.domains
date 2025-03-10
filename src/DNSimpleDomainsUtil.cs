using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.DNSimple.Client.Abstract;
using Soenneker.DNSimple.Domains.Abstract;
using Soenneker.DNSimple.Domains.Requests;
using Soenneker.DNSimple.Domains.Responses;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.ValueTask;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.Domains;

/// <inheritdoc cref="IDnSimpleDomainsUtil"/>
public class DNSimpleDomainsUtil: IDnSimpleDomainsUtil
{
    private readonly IDNSimpleClientUtil _clientUtil;
    private readonly ILogger<DNSimpleDomainsUtil> _logger;

    private readonly string _accountId;

    public DNSimpleDomainsUtil(IDNSimpleClientUtil clientUtil, IConfiguration configuration, ILogger<DNSimpleDomainsUtil> logger)
    {
        _clientUtil = clientUtil;
        _logger = logger;
        _accountId = configuration.GetValueStrict<string>("DNSimple:AccountId");
    }

    /// <summary>
    /// Lists all domains in the account.
    /// </summary>
    public async ValueTask<DomainListResponse?> ListDomains(string? nameFilter = null, int? registrantId = null, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/domains";
        if (!string.IsNullOrEmpty(nameFilter) || registrantId.HasValue)
        {
            endpoint += "?";
            if (!string.IsNullOrEmpty(nameFilter)) endpoint += $"name_like={nameFilter}&";
            if (registrantId.HasValue) endpoint += $"registrant_id={registrantId}";
        }

        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainListResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    /// <summary>
    /// Creates a new domain entry in the account.
    /// </summary>
    public async ValueTask<DomainResponse?> CreateDomain(DomainCreateRequest request, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/domains";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainResponse>(HttpMethod.Post, endpoint, request, _logger, cancellationToken);
    }

    /// <summary>
    /// Retrieves the details of an existing domain.
    /// </summary>
    public async ValueTask<DomainResponse?> GetDomain(string domain, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/domains/{domain}";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<DomainResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    /// <summary>
    /// Deletes a domain from the account.
    /// </summary>
    public async ValueTask<bool> DeleteDomain(string domain, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/domains/{domain}";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return (await client.SendToType<DomainResponse>(HttpMethod.Delete, endpoint, null, _logger, cancellationToken)) != null;
    }
}
