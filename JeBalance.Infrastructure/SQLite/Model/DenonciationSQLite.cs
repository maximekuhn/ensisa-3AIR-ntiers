using System.ComponentModel.DataAnnotations.Schema;

namespace JeBalance.Architecture.SQLite.Model;

public class DenonciationSQLite
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("nom_informateur")]
    public string NomInformateur { get; set; }
}