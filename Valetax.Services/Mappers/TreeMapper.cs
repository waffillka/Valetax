using Valetax.Db.Entities;
using Valetax.Services.Model.DTOs;

namespace Valetax.Services.Mappers;

public static class TreeMapper
{
    public static TreeNodeDto ToTreeNodeDto(this TreeNodeEntity node)
    {
        var result = new TreeNodeDto()
        {
            Id = node.Id,
            Name = node.Name
        };

        if (node.Children != null && node.Children.Count() != 0)
        {
            result.Children = node.Children.Select(x => x.ToTreeNodeDto());
        }

        return result;
    }

    public static TreeNodeEntity ToTreeNodeEntity(this CreateTreeNodeDto node)
    {
        return new TreeNodeEntity()
        {
            ParentId = node.ParentId,
            Name = node.Name
        };
    }
}