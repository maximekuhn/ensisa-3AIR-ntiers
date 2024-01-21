using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Secrete.Securisee.Resources;

public class VIPAPI
{
    public VIPAPI(VIP source)
    {
        Nom = source.Nom;
        Prenom = source.Prenom;
        Adresse = new AdresseAPI(source.Adresse);
    }

    [JsonPropertyName("nom")] public string Nom { get; set; }

    [JsonPropertyName("prenom")] public string Prenom { get; set; }

    [JsonPropertyName("adresse")] public AdresseAPI Adresse { get; set; }
}