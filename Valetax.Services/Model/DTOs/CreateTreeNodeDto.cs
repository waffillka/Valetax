namespace Valetax.Services.Model.DTOs;

public class CreateTreeNodeDto
{
    public Guid? ParentId { get; set; }
    public string Name { get; set; }
}