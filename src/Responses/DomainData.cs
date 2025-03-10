using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

/// <summary>
/// Represents domain details.
/// </summary>
public class DomainData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }

    [JsonPropertyName("registrant_id")]
    public int? RegistrantId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("unicode_name")]
    public string UnicodeName { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("auto_renew")]
    public bool AutoRenew { get; set; }

    [JsonPropertyName("private_whois")]
    public bool PrivateWhois { get; set; }

    [JsonPropertyName("expires_on")]
    public string? ExpiresOn { get; set; }

    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }
}