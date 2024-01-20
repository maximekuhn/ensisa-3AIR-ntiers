using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class DenonciationSQLite : Denonciation
{
    [Column("id")] public Guid Id { get; set; }

    [Column("type_delit")] public TypeDelit TypeDelit { get; set; }

    [Column("pays_evasion")] public string? PaysEvasion { get; set; }

    [Column("statut")] public StatutDenonciation Statut { get; set; }

    [Column("horodatage")] public DateTime Horodatage { get; set; }

    [Column("fk_informateur")] public int IdInformateur { get; set; }

    [Column("fk_suspect")] public int IdSuspect { get; set; }

    [Column("fk_reponse")] public int? IdReponse { get; set; }

    [ForeignKey(nameof(IdInformateur))] public virtual InformateurSQLite? Informateur { get; set; }

    [ForeignKey(nameof(IdSuspect))] public virtual SuspectSQLite? Suspect { get; set; }

    [ForeignKey(nameof(IdReponse))] public virtual ReponseSQLite? Reponse { get; set; }
}