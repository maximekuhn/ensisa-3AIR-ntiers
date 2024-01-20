using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class SuspectSQLite : Suspect
{
    [Column("id")] public int Id { get; set; }
    [Column("nom")] public new string Nom { get; set; }
    [Column("prenom")] public new string Prenom { get; set; }
    [Column("adresse")] public new string Adresse { get; set; }
}