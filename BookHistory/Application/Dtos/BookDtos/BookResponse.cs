using BookHistory.Application.Dtos.BookChangeDtos;

namespace BookHistory.Application.Dtos.BookDtos
{
    public sealed class BookResponse
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required DateOnly PublishDate { get; init; }
        public required IReadOnlyList<string> Authors { get; init; }
        public required IReadOnlyList<BookChangeResponse> LatestChanges { get; init; }
    }
}
