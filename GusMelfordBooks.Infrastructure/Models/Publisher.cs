using System.ComponentModel.DataAnnotations;

namespace GusMelfordBooks.Infrastructure.Models;

public class Publisher : BaseEntity
{
    public Address Address { get; set; }
    
    [MaxLength(30)]
    public string Name { get; set; }
    
    [MaxLength(30)]
    public string Phone { get; set; }
    public List<Book> Books { get; set; }
}