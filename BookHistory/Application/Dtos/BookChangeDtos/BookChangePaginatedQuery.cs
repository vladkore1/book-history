using BookHistory.Application.Dtos.Common;

namespace BookHistory.Application.Dtos.BookChangeDtos
{
    public class BookChangePaginatedQuery : BookChangeQuery, IPaginationQuery
    {
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
