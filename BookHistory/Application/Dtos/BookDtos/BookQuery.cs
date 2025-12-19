namespace BookHistory.Application.Dtos.BookDtos
{
    public class BookQuery
    {
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
