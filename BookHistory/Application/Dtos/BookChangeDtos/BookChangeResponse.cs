using BookHistory.Domain.Enums;

namespace BookHistory.Application.Dtos.BookChangeDtos
{
    public sealed class BookChangeResponse
    {
        public required Guid Id { get; init; }
        public required Guid BookId { get; init; }

        public required BookChangeType Type { get; init; }
        public required string Description { get; init; }
        public required DateTime OccurredAt { get; init; }
    }
}
