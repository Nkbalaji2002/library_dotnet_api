using backend.Dtos;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/v1/{controller}")]
public class BooksController(IBookService service) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAllBooks());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await service.GetBookById(id);
        return book == null ? NotFound($"Book with Id {id} Not Found") : Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto bookDto)
    {
        var created = await service.AddBook(bookDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id },
            $"Book Id : {created.Id} created Successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateBookDto bookDto)
    {
        return await service.UpdateBook(id, bookDto)
            ? Ok($"Book Id {id} updated Successfully")
            : NotFound($"Book with Id {id} Not Found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteBook(id) ? NoContent() : NotFound($"Book with Id {id} Not Found");
}