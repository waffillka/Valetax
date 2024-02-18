namespace Valetax.Services.Model.DTOs;

public class ExceptionJournalDto
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public string? StackTrace { get; set; }
    public string? TraceIdentifier { get; set; }
    public string? RequestParameters { get; set; }
    public DateTime CreateAt { get; set; }
}