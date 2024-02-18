using Valetax.Db.Entities;
using Valetax.Domain.Models;

namespace Valetax.Db.Repositories.Interfaces;

public interface IExceptionJournalRepository  : IRepository<ExceptionJournalEntity>
{
    Task<IList<ExceptionJournalEntity>> GetListAsync(RequestFeatures pagination, CancellationToken ct = default);
}