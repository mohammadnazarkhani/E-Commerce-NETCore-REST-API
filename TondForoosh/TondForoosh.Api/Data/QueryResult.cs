using System.Collections.Generic;

namespace TondForoosh.Api.Data;

public class QueryResult<TEntity>
{
    public List<TEntity> Items { get; set; } = new List<TEntity>();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public QueryResult(List<TEntity> items, int totalCount, int pageNumber, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}