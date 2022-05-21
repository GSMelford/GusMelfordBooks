using System.ComponentModel.DataAnnotations;

namespace GusMelfordBooks.Infrastructure.Models;

public class User : BaseEntity
{
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [MaxLength(30)]
    public string? MiddleName { get; set; }
    
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [MaxLength(20)]
    public string Phone { get; set; }
    
    [MaxLength(30)]
    public string Email { get; set; }
    
    public Role Role { get; set; }
    public string Password { get; set; }
}