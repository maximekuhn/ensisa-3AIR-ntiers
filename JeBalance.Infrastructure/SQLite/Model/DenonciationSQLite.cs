using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class DenonciationSQLite : Denonciation
{
    [Column("id")] public int Id { get; set; }

    [Column("type_delit")] public TypeDelit TypeDelit { get; set; }

    [Column("pays_evasion")] public string? PaysEvasion { get; set; }

    [Column("statut")] public StatutDenonciation Statut { get; set; }

    [Column("id_informateur")] public int IdInformateur { get; set; }

    [Column("id_suspect")] public int IdSuspect { get; set; }

    [Column("horodatage")] public DateTime Horodatage { get; set; }

    [Column("id_reponse")] public int? IdReponse { get; set; }

    // [ForeignKey(nameof(IdInformateur))]
    // public virtual InformateurSQLite Informateur { get; set; }
}