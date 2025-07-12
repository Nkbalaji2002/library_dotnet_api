using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class LibraryContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
}