using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class InformateurSQLite : Informateur
{
    [Column("id")] public int Id { get; set; }
    [Column("nom")] public string Nom { get; set; }

    [Column("prenom")] public string Prenom { get; set; }
    // [Column("addresse")] public string Addresse { get; set; }
}