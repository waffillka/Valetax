using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Valetax.Db.Entities;

[Table("tree_nodes")]
public class TreeNodeEntity : BaseEntity
{
    [Required]
    [Column("name")]
    public string Name { get; set; }
    [Column("parent_id")]
    public Guid? ParentId { get; set; }
    
    public TreeNodeEntity? Parent { get; set; }
    
    [ForeignKey("ParentId")]
    public ICollection<TreeNodeEntity> Children { get; set; }
}