var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// A simple Fluent chain for a GET request
app.MapGet("/books/{id}", (int id) =>
{
    return Results.Ok(new { Id = id, Title = "The Great Gatsby" });
})
.WithName("GetBookById")
.WithSummary("Retrieves a single book by its unique ID");



// A Fluent chain for a POST request
app.MapPost("/books", (Book newBook) =>
{
    // Logic to save the book to a database would go here
    return Results.Created($"/books/{newBook.Id}", newBook);
})
.WithName("CreateBook")
.Accepts<Book>("application/json")
.Produces<Book>(201);

app.Run();

public record Book(int Id, string Title);

