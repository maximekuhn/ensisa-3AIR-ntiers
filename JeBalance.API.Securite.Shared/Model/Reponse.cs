using System.Text.Json.Serialization;

namespace JeBalance.API.Securite.Shared.Model;

public class Response
{
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("message")] public string? Message { get; set; }
}