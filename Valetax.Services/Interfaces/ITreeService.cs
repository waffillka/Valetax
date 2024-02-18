using Valetax.Services.Model.DTOs;

namespace Valetax.Services.Interfaces;

public interface ITreeService
{
    Task<TreeNodeDto?>GetNodeByIdWithChildrenAsync(Guid nodeId, CancellationToken ct = default);
    Task<List<TreeNodeDto>> GetNodeWithChildrenAsync(CancellationToken ct = default);
    Task<IEnumerable<TreeNodeDto>> GetRootNodesAsync(CancellationToken ct = default);
    Task CreateNodeAsync(CreateTreeNodeDto node, CancellationToken ct = default);
    Task DeleteNodeAsync(DeleteTreeNodeDto node, CancellationToken ct = default);
    Task RenameNodeAsync(RenameTreeNodeDto node, CancellationToken ct = default);
}