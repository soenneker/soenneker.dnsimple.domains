using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Response model for listing domains.
/// </summary>
public class DomainListResponse
{
    /// <summary>
    /// The list of domains in the account.
    /// </summary>
    [JsonPropertyName("data")]
    public List<DomainData> Data { get; set; }

    /// <summary>
    /// Pagination details.
    /// </summary>
    [JsonPropertyName("pagination")]
    public PaginationData Pagination { get; set; }
}