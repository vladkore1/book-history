namespace BookHistory.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateOnly PublishDate { get; set; }
        public required List<string> Authors { get; set; }

        public List<BookChange> BookChanges { get; set; } = [];
    }
}
