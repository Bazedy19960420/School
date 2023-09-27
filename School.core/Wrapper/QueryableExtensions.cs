using Microsoft.EntityFrameworkCore;


namespace School.core.Wrapper
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source==null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 20 : pageSize;
            int count = await source.AsNoTracking().CountAsync();
            if (count==0) return PaginatedResult<T>.Success(new List<T>(), count, pageNumber, pageSize);
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }
    }
}
