using Soenneker.DNSimple.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions;
using Soenneker.DNSimple.OpenApiClient.Item.Domains;
using Soenneker.DNSimple.OpenApiClient.Item.Domains.Item;
using Soenneker.DNSimple.OpenApiClient.Models;
using Soenneker.Extensions.String;

namespace Soenneker.DNSimple.Domains;

/// <inheritdoc cref="IDNSimpleDomainsUtil"/>
public sealed class DNSimpleDomainsUtil : IDNSimpleDomainsUtil
{
    private readonly IRequestAdapter _requestAdapter;
    private readonly string _accountId;

    public DNSimpleDomainsUtil(IRequestAdapter requestAdapter, string accountId)
    {
        _requestAdapter = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
        _accountId = accountId ?? throw new ArgumentNullException(nameof(accountId));
    }

    public async ValueTask<IEnumerable<Domain>> List(string? nameLike = null, int? registrantId = null, string? sort = null,
        CancellationToken cancellationToken = default)
    {
        var builder = new DomainsRequestBuilder(new Dictionary<string, object> {{"account", _accountId}}, _requestAdapter);

        var queryParams = new DomainsRequestBuilder.DomainsRequestBuilderGetQueryParameters();

        if (nameLike.HasContent())
            queryParams.NameLike = nameLike;

        if (registrantId.HasValue)
            queryParams.RegistrantId = registrantId.Value;

        if (sort.HasContent())
            queryParams.Sort = sort;

        DomainsGetResponse? response = await builder.GetAsDomainsGetResponseAsync(config => config.QueryParameters = queryParams, cancellationToken);
        return response?.Data ?? [];
    }

    public async ValueTask<Domain?> Get(string domainNameOrId, CancellationToken cancellationToken = default)
    {
        var builder = new WithDomainItemRequestBuilder(new Dictionary<string, object>
        {
            {"account", _accountId},
            {"domain", domainNameOrId}
        }, _requestAdapter);

        WithDomainGetResponse? response = await builder.GetAsWithDomainGetResponseAsync(cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<Domain?> Create(string domainName, CancellationToken cancellationToken = default)
    {
        var builder = new DomainsRequestBuilder(new Dictionary<string, object> {{"account", _accountId}}, _requestAdapter);

        var body = new DomainsPostRequestBody
        {
            Name = domainName
        };

        DomainsPostResponse? response = await builder.PostAsDomainsPostResponseAsync(body, cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask Delete(string domainNameOrId, CancellationToken cancellationToken = default)
    {
        var builder = new WithDomainItemRequestBuilder(new Dictionary<string, object>
        {
            {"account", _accountId},
            {"domain", domainNameOrId}
        }, _requestAdapter);

        await builder.DeleteAsync(cancellationToken: cancellationToken);
    }
}