using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Response model for domain renewal.
/// </summary>
public class DomainRenewalResponse
{
    /// <summary>
    /// The domain renewal details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainRenewalData Data { get; set; }
}