using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Architecture.SQLite.Model;

public class ReponseSQLite : Reponse
{
    [Column("id")] public int Id { get; set; }
}