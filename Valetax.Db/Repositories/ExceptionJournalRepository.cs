using Microsoft.EntityFrameworkCore;
using Valetax.Db.Context;
using Valetax.Db.Entities;
using Valetax.Db.Repositories.Interfaces;
using Valetax.Domain.Models;

namespace Valetax.Db.Repositories;

public class ExceptionJournalRepository : Repository<ExceptionJournalEntity>, IExceptionJournalRepository
{
    public ExceptionJournalRepository(AppDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<IList<ExceptionJournalEntity>> GetListAsync(RequestFeatures pagination,
        CancellationToken ct = default)
    {
        if (pagination == null) throw new ArgumentNullException(nameof(pagination));

        var entities = await DbContext.ExceptionJournal.Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize).ToListAsync(ct);

        return entities;
    }
}