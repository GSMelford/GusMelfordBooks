using System.ComponentModel.DataAnnotations;

namespace GusMelfordBooks.Infrastructure.Models;

public class Address : BaseEntity
{
    [MaxLength(30)]
    public string Country { get; set; }
    
    [MaxLength(30)]
    public string City { get; set; }
    
    [MaxLength(30)]
    public string Street { get; set; }
}