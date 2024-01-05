using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class SuspectSQLite : Suspect
{
    [Column("id")] public int Id { get; set; }
    [Column("nom")] public string Nom { get; set; }

    [Column("prenom")] public string Prenom { get; set; }
    // [Column("adresse")] public string Adresse { get; set; }
}