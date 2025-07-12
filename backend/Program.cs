using backend.Data;
using backend.Repositories;
using backend.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* Load .env file */
Env.Load();

/* Configure logging */
builder.Logging.AddConsole();
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

/*  Add services to the container */
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

/* DBContext for User */
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

/* Register Services and Repos */
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();