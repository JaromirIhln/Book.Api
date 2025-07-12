using Book.Api;
using Book.Api.Interfaces;
using Book.Data;
using Book.Data.Interfaces;
using Book.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Book.Api.Services;


// Create a new web application builder
var builder = WebApplication.CreateBuilder(args);

// Define the connection string for the database
var connectionString = builder.Configuration.GetConnectionString("BookDatabaseConnection");
#region Service Configuration
//Add DbContext with proxies and lazy loading
builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseSqlServer(connectionString)
    .UseLazyLoadingProxies()
        .ConfigureWarnings(x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));

// Add Json serialization options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Add AutoMapper  - endpoints to the assembly containing the mapping profile
builder.Services.AddEndpointsApiExplorer();

// Add Swagger generation
builder.Services.AddSwaggerGen( options =>
    options.SwaggerDoc("book", new OpenApiInfo()
    {
        Title = "Books API",
        Version = "v1",
        Description = "API for managing books",
    }));
#endregion

#region Dependency Injection Configuration
//Add DI - Dependency Injection
//Books Repository DI
builder.Services.AddScoped<IBookRepository,BookRepository>();
//API Controllers DI
builder.Services.AddScoped<IBookServices, BookService>();
//Mapper DI
#endregion

// Mapper configuration - older way .Net 7 and below
//builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));

//New and correct the AutoMapper configuration registration -
///not use other in dependency injection registration region
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperConfiguration>());
// Add controllers
builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/book/swagger.json", "Books API v1"));
}
//Use MapControllers
app.MapControllers(); // <-- This line is necessary to map the controllers
// Default route
app.MapGet("/", () => "Hello World!");
//Run the application
app.Run();
