using Valetax.Db.Repositories.Interfaces;
using Valetax.Domain.Models;
using Valetax.Services.Interfaces;
using Valetax.Services.Mappers;
using Valetax.Services.Model.DTOs;

namespace Valetax.Services.Services;

public class ExceptionJournalService : IExceptionJournalService
{
    private readonly IExceptionJournalRepository _exceptionJournalRepository;

    public ExceptionJournalService(IExceptionJournalRepository exceptionJournalRepository)
    {
        _exceptionJournalRepository = exceptionJournalRepository ??
                                      throw new ArgumentNullException(nameof(exceptionJournalRepository));
    }

    public async Task<ExceptionJournalDto> CreateNodeAsync(ExceptionJournalDto node, CancellationToken ct = default)
    {
        var result = await _exceptionJournalRepository.InsertAsync(node.ToExceptionJournalEntity(), ct);
        return result.ToExceptionJournalDto();
    }

    public async Task<IList<ExceptionJournalDto>> GetListAsync(RequestFeatures pagination,
        CancellationToken ct = default)
    {
        var result = await _exceptionJournalRepository.GetListAsync(pagination, ct);
        return result.Select(x => x.ToExceptionJournalDto()).ToList();
    }

    public async Task<ExceptionJournalDto> GetAsync(string id, CancellationToken ct = default)
    {
        var result = await _exceptionJournalRepository.GetAsync(x => x.TraceIdentifier == id, ct);

        if (result == null)
        {
            throw new ArgumentException("Cannot be found");
        }

        return result.ToExceptionJournalDto();
    }
}