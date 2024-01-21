using System.Text.Json.Serialization;

namespace JeBalance.API.Secrete.Securisee.Resources;

public class VIPAPI
{
    [JsonPropertyName("nom")] public string Nom { get; set; }

    [JsonPropertyName("prenom")] public string Prenom { get; set; }

    [JsonPropertyName("adresse")] public AdresseAPI Adresse { get; set; }
}