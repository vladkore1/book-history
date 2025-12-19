using BookHistory.Application.Events;
using BookHistory.Application.Services.BookChanges;
using BookHistory.Application.Services.Books;
using BookHistory.Infrastructure.Events;
using BookHistory.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Book History API",
        Version = "v1",
        Description = "API for managing books and viewing change history"
    });
});

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookChangeService, BookChangeService>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddDomainEvents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
