using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Requests;

/// <summary>
/// Request model for domain registration.
/// </summary>
public class DomainRegistrationRequest
{
    /// <summary>
    /// The ID of an existing contact in your account.
    /// </summary>
    [JsonPropertyName("registrant_id")]
    public int RegistrantId { get; set; }

    /// <summary>
    /// Whether to enable auto-renewal for the domain.
    /// </summary>
    [JsonPropertyName("auto_renew")]
    public bool AutoRenew { get; set; }
}