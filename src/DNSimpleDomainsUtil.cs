using Microsoft.Extensions.Configuration;
using Soenneker.DNSimple.Domains.Abstract;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.DNSimple.OpenApiClient.Item.Domains;
using Soenneker.DNSimple.OpenApiClient.Item.Domains.Item;
using Soenneker.DNSimple.OpenApiClient.Models;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.String;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.Domains;

/// <inheritdoc cref="IDNSimpleDomainsUtil"/>
public sealed class DNSimpleDomainsUtil : IDNSimpleDomainsUtil
{
    private readonly IDNSimpleOpenApiClientUtil _clientUtil;
    private readonly int _accountId;

    public DNSimpleDomainsUtil(IDNSimpleOpenApiClientUtil clientUtil, IConfiguration configuration)
    {
        _clientUtil = clientUtil;
        _accountId = configuration.GetValueStrict<int>("DNSimple:AccountId");
    }

    public async ValueTask<IEnumerable<Domain>> List(string? nameLike = null, int? registrantId = null, string? sort = null,
        CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();

        var queryParams = new DomainsRequestBuilder.DomainsRequestBuilderGetQueryParameters();

        if (nameLike.HasContent())
            queryParams.NameLike = nameLike;

        if (registrantId.HasValue)
            queryParams.RegistrantId = registrantId.Value;

        DomainsGetResponse? response = await client[_accountId]
                                             .Domains.GetAsync(config => config.QueryParameters = queryParams, cancellationToken)
                                             .NoSync();
        return response?.Data ?? [];
    }

    public async ValueTask<Domain?> Get(string domainNameOrId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();

        WithDomainGetResponse? response =
            await client[_accountId].Domains[domainNameOrId].GetAsync(cancellationToken: cancellationToken).NoSync();
        return response?.Data;
    }

    public async ValueTask<Domain?> Create(string domainName, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();

        var body = new DomainsPostRequestBody
        {
            Name = domainName
        };

        DomainsPostResponse? response = await client[_accountId].Domains.PostAsync(body, cancellationToken: cancellationToken).NoSync();
        return response?.Data;
    }

    public async ValueTask Delete(string domainNameOrId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();

        await client[_accountId].Domains[domainNameOrId].DeleteAsync(cancellationToken: cancellationToken).NoSync();
    }
}