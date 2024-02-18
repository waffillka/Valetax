using Valetax.Db.Repositories.Interfaces;
using Valetax.Domain.Models.Exceptions;
using Valetax.Services.Interfaces;
using Valetax.Services.Mappers;
using Valetax.Services.Model.DTOs;

namespace Valetax.Services.Services;

public class TreeService : ITreeService
{
    private readonly ITreeRepository _treeRepository;

    public TreeService(ITreeRepository treeRepository)
    {
        _treeRepository = treeRepository ?? throw new ArgumentNullException(nameof(treeRepository));
    }

    public async Task<List<TreeNodeDto>> GetNodeWithChildrenAsync(CancellationToken ct = default)
    {
        var result = await _treeRepository.GetNodeWithChildrenAsync(null, ct);

        if (result == null)
        {
            throw new SecureException("Cannot find item");
        }

        return result.Select(x => x.ToTreeNodeDto()).ToList();
    }

    public async Task<TreeNodeDto?> GetNodeByIdWithChildrenAsync(Guid nodeId, CancellationToken ct = default)
    {
        var rootEntity = await _treeRepository.GetAsync(x => x.Id == nodeId, ct);
        if (rootEntity == null)
        {
            return null;
        }

        var root = rootEntity.ToTreeNodeDto();
        var result = await _treeRepository.GetNodeWithChildrenAsync(nodeId, ct);

        if (result == null)
        {
            throw new SecureException("Cannot find item");
        }

        root.Children = result.Select(x => x.ToTreeNodeDto()).ToList();
        return root;
    }

    public async Task<IEnumerable<TreeNodeDto>> GetRootNodesAsync(CancellationToken ct = default)
    {
        var result = await _treeRepository.GetRootNodesAsync(ct);
        return result.Select(x => x.ToTreeNodeDto());
    }

    public async Task CreateNodeAsync(CreateTreeNodeDto node, CancellationToken ct = default)
    {
        await _treeRepository.InsertAsync(node.ToTreeNodeEntity(), ct);
    }

    public async Task DeleteNodeAsync(DeleteTreeNodeDto node, CancellationToken ct = default)
    {
        await _treeRepository.Delete(x => x.Id == node.Id && x.Name == node.Name, ct);
    }

    public async Task RenameNodeAsync(RenameTreeNodeDto node, CancellationToken ct = default)
    {
        var entity = await _treeRepository.GetAsync(x => x.Id == node.Id, ct);
        if (entity == null)
        {
            throw new SecureException("Cannot find item");
        }

        entity.Name = node.Name;
        await _treeRepository.UpdateAsync(entity, ct);
    }
}