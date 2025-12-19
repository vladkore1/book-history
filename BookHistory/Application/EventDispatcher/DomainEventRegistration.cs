using BookHistory.Application.Events.Handlers;
using BookHistory.Domain.Events;

namespace BookHistory.Application.Events
{
    public static class DomainEventsRegistration
    {
        public static IServiceCollection AddDomainEvents(
            this IServiceCollection services)
        {
            services.AddScoped<IDomainEventHandler<BookCreatedEvent>, RecordBookChangeHandler>();
            services.AddScoped<IDomainEventHandler<BookTitleChangedEvent>, RecordBookChangeHandler>();
            services.AddScoped<IDomainEventHandler<BookDescriptionChangedEvent>, RecordBookChangeHandler>();
            services.AddScoped<IDomainEventHandler<BookPublishDateChangedEvent>, RecordBookChangeHandler>();
            services.AddScoped<IDomainEventHandler<AuthorAddedToBookEvent>, RecordBookChangeHandler>();
            services.AddScoped<IDomainEventHandler<AuthorRemovedFromBookEvent>, RecordBookChangeHandler>();

            return services;
        }
    }
}
