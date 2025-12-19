using BookHistory.Domain.Enums;

namespace BookHistory.Application.Dtos.BookChangeDtos
{
    public class BookChangeQuery
    {
        public Guid? BookId { get; init; }
        public BookChangeType? Type { get; init; }
        public DateTime? FromDate { get; init; }
        public DateTime? ToDate { get; init; }


        public BookChangeOrderBy? OrderBy { get; init; } = BookChangeOrderBy.OccurredAt;
        public bool Desc { get; init; } = true;
    }
}
