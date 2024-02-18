using Valetax.Db.Entities;
using Valetax.Services.Model.DTOs;

namespace Valetax.Services.Mappers;

public static class ExceptionJournalMapper
{
    public static ExceptionJournalEntity ToExceptionJournalEntity(this ExceptionJournalDto item)
    {
        return new ExceptionJournalEntity()
        {
            Id = item.Id,
            StackTrace = item.StackTrace,
            RequestParameters = item.RequestParameters,
            Type = item.Type,
            TraceIdentifier = item.TraceIdentifier,
        };
    }

    public static ExceptionJournalDto ToExceptionJournalDto(this ExceptionJournalEntity item)
    {
        return new ExceptionJournalDto()
        {
            Id = item.Id,
            StackTrace = item.StackTrace,
            RequestParameters = item.RequestParameters,
            Type = item.Type,
            CreateAt = item.CreateAt,
            TraceIdentifier = item.TraceIdentifier,
        };
    }
}