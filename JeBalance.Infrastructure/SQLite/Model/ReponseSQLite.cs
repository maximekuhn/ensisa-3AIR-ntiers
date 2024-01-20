using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Model;

namespace JeBalance.Infrastructure.SQLite.Model;

public class ReponseSQLite : Reponse
{
    [Column("id")] public int Id { get; set; }
}