namespace Valetax.Services.Model.DTOs;

public class TreeNodeDto
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<TreeNodeDto>? Children { get; set; }
}