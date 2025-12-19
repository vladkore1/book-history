namespace BookHistory.Domain.Events
{
    public sealed record BookCreatedEvent(
        Guid BookId,
        string Title
    ) : IDomainEvent;
}
