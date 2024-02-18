namespace Valetax.Db.Entities;

public class ExceptionJournalEntity : BaseEntity
{
    public string? Type { get; set; }
    public string? StackTrace { get; set; }
    public string? TraceIdentifier { get; set; }
    public string? RequestParameters { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}