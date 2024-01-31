using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Interne.Securisee.Resources;

public class ReponseCreateAPI
{
    //Informations de la réponse
    [JsonPropertyName("typeReponse")] public TypeReponse TypeReponse { get; set; }
    [JsonPropertyName("retribution")] public double? Retribution { get; set; }
}