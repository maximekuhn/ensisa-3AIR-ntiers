using System.Text.Json.Serialization;
using JeBalance.Domain.Model;

namespace JeBalance.API.Secrete.Securisee.Resources;

public class VIPGetAPI
{
    public VIPGetAPI()
    {
        Adresse = new AdresseAPI();
    }

    public VIPGetAPI(VIP vip)
    {
        Id = vip.Id;
        Nom = vip.Nom;
        Prenom = vip.Prenom;
        Adresse = new AdresseAPI(vip.Adresse);
    }

    [JsonPropertyName("id")] public int Id { get; set; }
    
    [JsonPropertyName("nom")] public string Nom { get; set; }

    [JsonPropertyName("prenom")] public string Prenom { get; set; }

    [JsonPropertyName("adresse")] public AdresseAPI Adresse { get; set; }
}