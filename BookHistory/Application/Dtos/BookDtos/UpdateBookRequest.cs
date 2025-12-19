namespace BookHistory.Application.Dtos.BookDtos
{
    public class UpdateBookRequest
    {
        public string? Title { get; init; }
        public string? Description { get; init; }
        public DateOnly? PublishDate { get; init; }
        public List<string>? Authors { get; init; }
    }
}
