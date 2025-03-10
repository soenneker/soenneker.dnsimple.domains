using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Response model for domain operations.
/// </summary>
public class DomainResponse
{
    /// <summary>
    /// The domain details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainData Data { get; set; }
}