using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Response model for domain registration.
/// </summary>
public class DomainRegistrationResponse
{
    /// <summary>
    /// The domain registration details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainRegistrationData Data { get; set; }
}