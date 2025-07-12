using backend.Dtos;

namespace backend.Services;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllBooks();

    Task<BookDto?> GetBookById(int id);

    Task<BookDto> AddBook(CreateBookDto bookDto);

    Task<bool> UpdateBook(int id, UpdateBookDto bookDto);

    Task<bool> DeleteBook(int id);
}