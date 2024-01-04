using JeBalance.Domain.Model;

namespace JeBalance.API.Publique.Resources;

public class DenonciationAPI
{
    public string? PaysEvasion { get; set; }
    public TypeDelit TypeDelit { get; set; }

    public DenonciationAPI()
    {
    }
}