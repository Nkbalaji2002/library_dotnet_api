namespace backend.Dtos;

public class UpdateBookDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public bool IsAvailable { get; set; }
}