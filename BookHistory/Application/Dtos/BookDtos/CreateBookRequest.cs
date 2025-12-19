namespace BookHistory.Application.Dtos.BookDtos
{
    public sealed class CreateBookRequest
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required DateOnly PublishDate { get; init; }
        public required List<string> Authors { get; init; }
    }
}
