namespace Infrastructure.Database.Pagination;

public static class PagedQueryResultExtension
{
    public static PaginatedQueryResult<T> ToPaginatedList<T>(this List<T> source, int pageNumber, int pageSize)
        where T : class
    {
        var counter = source.Count;
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        var firstItemPage = (pageNumber - 1) * pageSize;
        var items = source.Skip(firstItemPage).Take(pageSize).ToList();
        return new PaginatedQueryResult<T>(items, counter, pageNumber, pageSize);
    }

    public static PaginatedQueryResult<T> ToPaginatedList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        where T : class
    {
        var counter = source.Count();
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        var firstItemPage = (pageNumber - 1) * pageSize;
        var items = source.Skip(firstItemPage).Take(pageSize).ToList();
        return new PaginatedQueryResult<T>(items, counter, pageNumber, pageSize);
    }

    public static PaginatedQueryResult<T> ToPaginatedList<T>(this ICollection<T> source, int pageNumber, int pageSize)
        where T : class
    {
        var counter = source.Count;
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        var firstItemPage = (pageNumber - 1) * pageSize;
        var items = source.Skip(firstItemPage).Take(pageSize).ToList();
        return new PaginatedQueryResult<T>(items, counter, pageNumber, pageSize);
    }

    public static PaginatedQueryResult<T> ToPaginatedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        where T : class
    {
        var counter = source.Count();
        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        var firstItemPage = (pageNumber - 1) * pageSize;
        var items = source.Skip(firstItemPage).Take(pageSize).ToList();
        return new PaginatedQueryResult<T>(items, counter, pageNumber, pageSize);
    }
}