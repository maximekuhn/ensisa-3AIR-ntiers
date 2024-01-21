using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Publique.Resources;

public class ReponseAPI
{
    public ReponseAPI(Reponse source)
    {
        TypeReponse = source.TypeReponse;
        Retribution = source.Retribution;
    }

    //Informations de la réponse
    [JsonPropertyName("type_reponse")] public TypeReponse TypeReponse { get; set; }
    [JsonPropertyName("retribution")] public double? Retribution { get; set; }
}