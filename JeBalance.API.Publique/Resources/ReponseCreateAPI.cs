using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Publique.Resources;

public class ReponseCreateAPI
{
    //Informations de la réponse
    [JsonPropertyName("typeReponse")] public TypeReponse TypeReponse { get; set; }
    [JsonPropertyName("retribution")] public double? Retribution { get; set; }
    [JsonPropertyName("denonciationId")] public Guid DenonciationId { get; set; }
}