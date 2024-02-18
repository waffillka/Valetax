using Valetax.Db.Entities;

namespace Valetax.Db.Repositories.Interfaces;

public interface ITreeRepository : IRepository<TreeNodeEntity>
{
    Task<List<TreeNodeEntity>>  GetNodeWithChildrenAsync(Guid? nodeId, CancellationToken ct = default);
    Task<IEnumerable<TreeNodeEntity>> GetRootNodesAsync(CancellationToken ct = default);
}