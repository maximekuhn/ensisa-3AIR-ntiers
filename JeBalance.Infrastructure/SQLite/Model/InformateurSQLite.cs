using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Infrastructure.SQLite.Model;

public class InformateurSQLite : Informateur
{
    [Column("id")] public int Id { get; set; }
    [Column("nom")] public string Nom { get; set; }
    [Column("prenom")] public string Prenom { get; set; }
    [Column("calomniateur")] public bool EstCalomniateur { get; set; }
    [Column("adresse")] public string Adresse { get; set; }
}