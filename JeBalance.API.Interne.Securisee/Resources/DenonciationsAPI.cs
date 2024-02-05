using System.Text.Json.Serialization;

namespace JeBalance.API.Interne.Securisee.Resources;

public class DenonciationsAPI
{
    public DenonciationsAPI()
    {
        Count = 0;
        Denonciations = Array.Empty<DenonciationGetAPI>();
    }

    public DenonciationsAPI(DenonciationGetAPI[] denonciations, int count)
    {
        Denonciations = denonciations;
        Count = count;
    }

    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("denonciations")] public DenonciationGetAPI[] Denonciations { get; set; }
}