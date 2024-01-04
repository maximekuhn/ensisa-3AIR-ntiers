using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class DenonciationSQLite: Denonciation
{
    [Column("id")] public int Id { get; set; }

    [Column("nom_informateur")] public string NomInformateur { get; set; }
}