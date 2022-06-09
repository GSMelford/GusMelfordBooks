namespace GusMelfordBooks.Infrastructure.Models;

public class Order : BaseEntity
{
    public User Customer { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public List<Book> Books { get; set; } = new();
}