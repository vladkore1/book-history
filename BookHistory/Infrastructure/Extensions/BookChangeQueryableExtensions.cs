using BookHistory.Application.Dtos.BookChangeDtos;
using BookHistory.Domain.Entities;
using BookHistory.Domain.Enums;

namespace BookHistory.Infrastructure.Extensions
{
    public static class BookChangeQueryableExtensions
    {
        public static IQueryable<BookChange> ApplyFilters(
            this IQueryable<BookChange> query,
            BookChangeQuery request)
        {
            if (request.BookId != null)
                query = query.Where(c => c.BookId == request.BookId);

            if (request.Type != null)
                query = query.Where(c => c.ChangeType == request.Type);

            if (request.FromDate != null)
                query = query.Where(c => c.OccurredAt >= request.FromDate);

            if (request.ToDate is not null)
                query = query.Where(c => c.OccurredAt <= request.ToDate);

            return query;
        }

        public static IQueryable<BookChange> ApplyOrdering(
            this IQueryable<BookChange> query,
            BookChangeQuery request)
        {
            return request.OrderBy switch
            {
                BookChangeOrderBy.OccurredAt => request.Desc
                    ? query.OrderByDescending(c => c.OccurredAt)
                    : query.OrderBy(c => c.OccurredAt),

                BookChangeOrderBy.Type => request.Desc
                    ? query.OrderByDescending(c => c.ChangeType)
                    : query.OrderBy(c => c.ChangeType),

                _ => query
            };
        }
    }
}
