namespace BookHistory.Application.Dtos.BookChangeDtos
{
    public class BookChangeQuery
    {
        public int Page { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
