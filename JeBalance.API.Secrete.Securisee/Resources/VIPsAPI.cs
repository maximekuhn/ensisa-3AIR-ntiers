using System.Text.Json.Serialization;

namespace JeBalance.API.Secrete.Securisee.Resources;

public class VIPsAPI
{
    public VIPsAPI()
    {
        VIPs = Array.Empty<VIPGetAPI>();
        Count = 0;
    }

    public VIPsAPI(VIPGetAPI[] vips, int count)
    {
        VIPs = vips;
        Count = count;
    }

    [JsonPropertyName("count")] public int Count { get; set; }
    [JsonPropertyName("vips")] public VIPGetAPI[] VIPs { get; set; }
}