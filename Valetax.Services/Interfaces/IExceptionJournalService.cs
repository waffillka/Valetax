using Valetax.Domain.Models;
using Valetax.Services.Model.DTOs;

namespace Valetax.Services.Interfaces;

public interface IExceptionJournalService
{
    Task<ExceptionJournalDto> CreateNodeAsync(ExceptionJournalDto node, CancellationToken ct = default);

    Task<IList<ExceptionJournalDto>> GetListAsync(RequestFeatures pagination, CancellationToken ct = default);
    Task<ExceptionJournalDto> GetAsync(string id, CancellationToken ct = default);
}