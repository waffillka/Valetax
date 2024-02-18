using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valetax.Db.Entities;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
}