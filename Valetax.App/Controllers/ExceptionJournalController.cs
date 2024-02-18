using Microsoft.AspNetCore.Mvc;
using Valetax.Domain.Models;
using Valetax.Services.Interfaces;

namespace Valetax.App.Controllers;

[ApiController]
[Route("api/journal")]
public class ExceptionJournalController : ControllerBase
{
    private readonly IExceptionJournalService _exceptionJournalService;

    public ExceptionJournalController(IExceptionJournalService exceptionJournalService)
    {
        _exceptionJournalService =
            exceptionJournalService ?? throw new ArgumentNullException(nameof(exceptionJournalService));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExceptionJournalAsync([FromRoute] string id, CancellationToken ct = default)
    {
        var result = await _exceptionJournalService.GetAsync(id, ct);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetExceptionJournalListAsync([FromQuery] RequestFeatures parametrs,
        CancellationToken ct = default)
    {
        var result = await _exceptionJournalService.GetListAsync(parametrs, ct);
        return Ok(result);
    }
}