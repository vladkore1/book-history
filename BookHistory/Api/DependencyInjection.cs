using BookHistory.Api.ExceptionHandlers;
using System.Text.Json.Serialization;

namespace BookHistory.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter());
                });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = "Book History API",
                    Version = "v1",
                    Description = "API for managing books and viewing change history"
                });
            });

            services.AddProblemDetails();
            services.AddExceptionHandler<AppExceptionHandler>();
            services.AddExceptionHandler<CatchAllExceptionHandler>();

            return services;
        }
    }
}
