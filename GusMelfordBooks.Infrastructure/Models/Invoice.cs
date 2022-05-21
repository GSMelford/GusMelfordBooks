namespace GusMelfordBooks.Infrastructure.Models;

public class Invoice : BaseEntity
{
    public User User { get; set; }
    public decimal Amount { get; set; } = 8000;
}