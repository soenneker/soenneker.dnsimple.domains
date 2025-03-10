using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Requests;

/// <summary>
/// Request model for domain renewal.
/// </summary>
public class DomainRenewalRequest
{
    /// <summary>
    /// The number of years to renew the domain.
    /// </summary>
    [JsonPropertyName("period")]
    public int Period { get; set; }
}