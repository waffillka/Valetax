using System.Collections;

namespace Valetax.Domain.Models.Exceptions;

public class ErrorDetails
{
    public string Type { get; set; }
    public string Id { get; set; }
    public string Data { get; set; }
}