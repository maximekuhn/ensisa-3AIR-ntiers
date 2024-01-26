using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Infrastructure.SQLite.Model;

public class ReponseSQLite : Reponse
{
    [Column("id")] public new int Id { get; set; }
    [Column("type_reponse")] public new TypeReponse TypeReponse { get; set; }
    [Column("retribution")] public new double? Retribution { get; set; }
    [Column("horodatage")] public new DateTime Horodatage { get; set; }
}