using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories;

public class BookRepository(LibraryContext context) : IBookRepository
{
    public async Task<IEnumerable<Book?>> GetAllAsync() => await context.Books.ToListAsync();

    public async Task<Book?> GetByIdAsync(int id) => await context.Books.FindAsync(id);

    public async Task<Book> CreateAsync(Book book)
    {
        context.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateAsync(Book? book)
    {
        if (book != null) context.Books.Update(book);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await context.Books.FindAsync(id);

        if (book != null)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}