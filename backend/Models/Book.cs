using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("myBooks")]
public class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }
    
    public string? Author { get; set; }

    public DateTime PublishedDate { get; set; }

    public bool IsAvailable { get; set; }
}