using System.ComponentModel.DataAnnotations;

namespace GusMelfordBooks.Infrastructure.Models;

public class Author : BaseEntity
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [MaxLength(30)]
    public string MiddleName { get; set; }
    
    [MaxLength(30)]
    public string LastName { get; set; }
    
    public DateTime? DataOfBirth { get; set; }
}