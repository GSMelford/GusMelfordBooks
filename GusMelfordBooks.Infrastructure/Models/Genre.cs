using System.ComponentModel.DataAnnotations;

namespace GusMelfordBooks.Infrastructure.Models;

public class Genre : BaseEntity
{
    [MaxLength(30)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Book> Books { get; set; }
}