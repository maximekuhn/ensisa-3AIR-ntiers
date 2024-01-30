using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Infrastructure.SQLite.Model;

public class DenonciationSQLite : Denonciation
{
    [Column("id")] public new Guid Id { get; set; }

    [Column("type_delit")] public new TypeDelit TypeDelit { get; set; }

    [Column("pays_evasion")] public new string? PaysEvasion { get; set; }
    
    [Column("horodatage")] public new DateTime Horodatage { get; set; }

    [Column("fk_informateur")] public int IdInformateur { get; set; }

    [Column("fk_suspect")] public int IdSuspect { get; set; }

    [Column("fk_reponse")] public int? IdReponse { get; set; }

    [ForeignKey(nameof(IdInformateur))] public virtual InformateurSQLite? Informateur { get; set; }

    [ForeignKey(nameof(IdSuspect))] public virtual SuspectSQLite? Suspect { get; set; }

    [ForeignKey(nameof(IdReponse))] public virtual ReponseSQLite? Reponse { get; set; }
}