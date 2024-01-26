using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Infrastructure.SQLite.Model;

public class VIPsQLite : VIP
{
    [Column("id")] public new int Id { get; set; }
    [Column("nom")] public new string Nom { get; set; }
    [Column("prenom")] public new string Prenom { get; set; }
    [Column("adresse")] public new string Adresse { get; set; }
}