using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Response model for retrieving domain registration, renewal, and transfer prices.
/// </summary>
public class DomainPricesResponse
{
    /// <summary>
    /// The domain price details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainPricesData Data { get; set; }
}