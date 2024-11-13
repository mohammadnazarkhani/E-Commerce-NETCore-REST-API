namespace TondForoosh.Api.Data;

public class QueryObjectParams
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public bool IsDescending { get; set; } = false;
    public string? SearchTerm { get; set; }
}