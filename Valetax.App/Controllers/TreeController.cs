using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Valetax.Services.Interfaces;
using Valetax.Services.Model.DTOs;

namespace Valetax.App.Controllers;

[ApiController]
[Route("api/tree")]
public class TreeController : ControllerBase
{
    private readonly ITreeService _treeService;

    public TreeController(ITreeService treeService)
    {
        _treeService = treeService ?? throw new ArgumentException(nameof(treeService));
    }

    [HttpGet()]
    public async Task<IActionResult> GetNodeAsync(CancellationToken ct = default)
    {
        var result = await _treeService.GetNodeWithChildrenAsync(ct);
        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetNodeByIdAsync(Guid id, CancellationToken ct = default)
    {
        var result = await _treeService.GetNodeByIdWithChildrenAsync(id, ct);
        return Ok(result);
    }

    [HttpGet("root-nodes")]
    public async Task<IActionResult> GetRootNodeAsync(Guid id, CancellationToken ct = default)
    {
        var result = await _treeService.GetRootNodesAsync(ct);
        return Ok(result);
    }


    [HttpPost("create")]
    public async Task<IActionResult> CreateNodeAsync([FromBody] CreateTreeNodeDto node, CancellationToken ct = default)
    {
        await _treeService.CreateNodeAsync(node, ct);
        return Ok();
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteNodeAsync([Required] [FromBody] DeleteTreeNodeDto node,
        CancellationToken ct = default)
    {
        await _treeService.DeleteNodeAsync(node, ct);
        return Ok();
    }

    [HttpPost("remane")]
    public async Task<IActionResult> RenameNodeAsync([FromBody] RenameTreeNodeDto node, CancellationToken ct = default)
    {
        await _treeService.RenameNodeAsync(node, ct);
        return Ok();
    }
}