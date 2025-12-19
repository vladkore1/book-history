namespace BookHistory.Domain.Events
{
    public sealed record AuthorAddedToBookEvent(
        Guid BookId,
        string AuthorName
    ) : IDomainEvent;
}
