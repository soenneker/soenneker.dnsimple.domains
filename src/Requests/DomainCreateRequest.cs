using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Requests;

/// <summary>
/// Request model for creating a domain.
/// </summary>
public class DomainCreateRequest
{
    /// <summary>
    /// The domain name to be added.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
}