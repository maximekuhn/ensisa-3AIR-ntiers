using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class ReponseSQLite : Reponse
{
    [Column("id")] public int Id { get; set; }
    [Column("type_reponse")] public TypeReponse TypeReponse { get; set; }
    [Column("retribution")] public double? Retribution { get; set; }
    [Column("horodatage")] public DateTime Horodatage { get; set; }
}