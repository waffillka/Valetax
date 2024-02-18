namespace Valetax.Domain.Models;

public class RequestFeatures
{
    private const int MaxPageSize = 100;
    private int _pageSize = 100;
    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get { return _pageSize; }
        set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
    }
}