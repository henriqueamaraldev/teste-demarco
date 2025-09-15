﻿namespace Infrastructure.Database.Pagination;

public class PaginatedQueryResult<T>
{
    public PaginatedQueryResult(List<T> items, int totalItems, int pageNumber, int pageSize = 10)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        Items = items;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);
    }

    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public List<T> Items { get; set; }
}