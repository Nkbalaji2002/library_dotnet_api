using backend.Models;

namespace backend.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book?>> GetAllAsync();

    Task<Book?> GetByIdAsync(int id);
    
    Task<Book> CreateAsync(Book book);

    Task UpdateAsync(Book? book);
    
    Task DeleteAsync(int id);
}