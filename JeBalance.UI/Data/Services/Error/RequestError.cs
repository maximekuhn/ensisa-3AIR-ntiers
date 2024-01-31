using System.Text.Json.Serialization;

namespace JeBalance.UI.Data.Services.Error;

public class RequestError
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
}