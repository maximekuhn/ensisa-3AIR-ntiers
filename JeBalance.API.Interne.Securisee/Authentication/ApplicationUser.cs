using Microsoft.AspNetCore.Identity;

namespace JeBalance.API.Interne.Securisee.Authentication;

public class ApplicationUser : IdentityUser
{
    public int AssociatedAdministrateurFiscaleId { get; set; }
}