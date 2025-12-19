namespace BookHistory.Application.Events
{
    public interface IDomainEventHandler<TEvent>
    {
        Task HandleAsync(TEvent evt);
    }
}
