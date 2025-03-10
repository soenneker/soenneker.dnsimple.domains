using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Response model for domain transfer.
/// </summary>
public class DomainTransferResponse
{
    /// <summary>
    /// The domain transfer details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainTransferData Data { get; set; }
}