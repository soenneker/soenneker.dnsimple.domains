using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Domains.Responses;

public class DomainPremiumPriceData
{
    [JsonPropertyName("premium_price")]
    public string PremiumPrice { get; set; }

    [JsonPropertyName("action")]
    public string Action { get; set; }
}