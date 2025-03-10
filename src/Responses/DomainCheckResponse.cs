using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Response model for checking domain availability.
/// </summary>
public class DomainCheckResponse
{
    /// <summary>
    /// The domain availability information.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainCheckData Data { get; set; }
}