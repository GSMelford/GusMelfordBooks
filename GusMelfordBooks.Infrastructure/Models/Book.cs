using System.ComponentModel.DataAnnotations;

namespace GusMelfordBooks.Infrastructure.Models;

public class Book : BaseEntity
{
    public Author Author { get; set; }
    
    [MaxLength(64)]
    public string Title { get; set; }
    
    [MaxLength(3)]
    public string Language { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<Publisher> Publishers { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Order> Orders { get; set; }
}