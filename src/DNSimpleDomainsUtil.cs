using Soenneker.DNSimple.Domains.Abstract;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.DNSimple.OpenApiClient.Item.Domains;
using Soenneker.DNSimple.OpenApiClient.Models;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Extensions.String;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.DNSimple.OpenApiClient.Item.Domains.Item;
using Microsoft.Extensions.Configuration;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.Task;

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
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);

        var queryParams = new DomainsRequestBuilder.DomainsRequestBuilderGetQueryParameters();

        if (nameLike.HasContent())
            queryParams.NameLike = nameLike;

        if (registrantId.HasValue)
            queryParams.RegistrantId = registrantId.Value;

        if (sort.HasContent())
            queryParams.Sort = sort;

        DomainsGetResponse? response =
            await client[_accountId].Domains.GetAsDomainsGetResponseAsync(config => config.QueryParameters = queryParams, cancellationToken);
        return response?.Data ?? [];
    }

    public async ValueTask<Domain?> Get(string domainNameOrId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);

        WithDomainGetResponse? response =
            await client[_accountId].Domains[domainNameOrId].GetAsWithDomainGetResponseAsync(cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<Domain?> Create(string domainName, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);

        var body = new DomainsPostRequestBody
        {
            Name = domainName
        };

        DomainsPostResponse? response = await client[_accountId].Domains.PostAsDomainsPostResponseAsync(body, cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask Delete(string domainNameOrId, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);

        await client[_accountId].Domains[domainNameOrId].DeleteAsync(cancellationToken: cancellationToken).NoSync();
    }
}