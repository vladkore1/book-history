using BookHistory.Application.Events;
using BookHistory.Application.Services.BookChanges;
using BookHistory.Application.Services.Books;

namespace BookHistory.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookChangeService, BookChangeService>();
            services.AddDomainEvents();

            return services;
        }
    }
}
