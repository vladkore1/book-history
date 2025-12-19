namespace BookHistory.Domain.Events
{
    public sealed record BookDescriptionChangedEvent(
        Guid BookId
    ) : IDomainEvent;
}
