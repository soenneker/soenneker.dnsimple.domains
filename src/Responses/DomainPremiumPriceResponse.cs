using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

public class DomainPremiumPriceResponse
{
    [JsonPropertyName("data")]
    public DomainPremiumPriceData Data { get; set; }
}