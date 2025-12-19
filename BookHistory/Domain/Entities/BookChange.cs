using BookHistory.Domain.Enums;

namespace BookHistory.Domain.Entities
{
    public class BookChange
    {
        public Guid Id { get; set; }
        public required Guid BookId { get; set; }
        public required BookChangeType ChangeType { get; set; }
        public required string Description { get; set; }
        public required DateTime OccurredAt { get; set; }

        public Book Book { get; set; } = null!;
    }
}
