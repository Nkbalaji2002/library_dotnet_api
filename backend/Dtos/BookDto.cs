namespace backend.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public DateTime PublishedDate { get; set; }
}