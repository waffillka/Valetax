using Microsoft.EntityFrameworkCore;
using Valetax.Db.Context;
using Valetax.Db.Entities;
using Valetax.Db.Repositories.Interfaces;

namespace Valetax.Db.Repositories;

public class TreeRepository : Repository<TreeNodeEntity>, ITreeRepository
{
    public TreeRepository(AppDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<List<TreeNodeEntity>> GetNodeWithChildrenAsync(Guid? nodeId, CancellationToken ct = default)
    {
        var allTreeNodes = await DbContext.TreeNodes
            .Include(x => x.Children)
            .AsNoTracking()
            .Where(node => node.ParentId == nodeId)
            .ToListAsync(ct);
        
        foreach (var node in allTreeNodes)
        {
            node.Children = await GetNodeWithChildrenAsync(node.Id);
        }

        return allTreeNodes;
    }

    public async Task<IEnumerable<TreeNodeEntity>> GetRootNodesAsync(CancellationToken ct = default)
    {
        return await DbContext.TreeNodes.Where(node => node.ParentId == null).ToListAsync(ct);
        ;
    }
}