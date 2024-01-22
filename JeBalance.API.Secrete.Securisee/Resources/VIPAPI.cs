using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Secrete.Securisee.Resources;

public class VIPAPI
{
    public VIPAPI()
    {
    }

    public VIPAPI(VIP vip)
    {
        Nom = vip.Nom;
        Prenom = vip.Prenom;
        Adresse = new AdresseAPI(vip.Adresse);
    }
    [JsonPropertyName("nom")] public string Nom { get; set; }

    [JsonPropertyName("prenom")] public string Prenom { get; set; }

    [JsonPropertyName("adresse")] public AdresseAPI Adresse { get; set; }
}