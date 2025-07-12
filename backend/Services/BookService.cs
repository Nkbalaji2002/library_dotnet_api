using backend.Dtos;
using backend.Models;
using backend.Repositories;

namespace backend.Services;

public class BookService(IBookRepository repository) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetAllBooks()
    {
        var books = await repository.GetAllAsync();

        return books.Select(book => new BookDto()
        {
            Id = book!.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
        });
    }

    public async Task<BookDto?> GetBookById(int id)
    {
        var book = await repository.GetByIdAsync(id);

        return book == null ? null : new BookDto()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
        };
    }

    public async Task<BookDto> AddBook(CreateBookDto bookDto)
    {
        var book = new Book()
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            PublishedDate = bookDto.PublishedDate,
            IsAvailable = true
        };

        var created = await repository.CreateAsync(book);

        return new BookDto()
        {
            Id = created.Id,
            Title = created.Title,
            Author = created.Author,
            PublishedDate = created.PublishedDate
        };
    }

    public async Task<bool> UpdateBook(int id, UpdateBookDto bookDto)
    {
        var book = await repository.GetByIdAsync(id);

        if (book == null)
        {
            return false;
        }

        book.Title = bookDto.Title;
        book.Author = bookDto.Author;
        book.PublishedDate = bookDto.PublishedDate;
        book.IsAvailable = bookDto.IsAvailable;

        await repository.UpdateAsync(book);
        return true;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var existingBook = await repository.GetByIdAsync(id);

        if (existingBook == null)
        {
            return false;
        }

        await repository.DeleteAsync(id);
        return true;
    }
}