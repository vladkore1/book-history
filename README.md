# book-history

ASP.NET Core Web API for managing books and tracking their change history with pagination, filtering, ordering, and grouping using domain events.

## Features

- Create and update books
- Track changes (title, description, authors, publish date)
- View change history with filtering, ordering, pagination
- Grouped history endpoint
- SQLite persistence
- Swagger UI

## Tech Stack

- ASP.NET Core
- Entity Framework Core
- SQLite

## Running the project

1. `dotnet ef database update`
2. `dotnet run`
3. Navigate to `/swagger`
