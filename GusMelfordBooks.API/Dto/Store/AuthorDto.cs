namespace GusMelfordBooks.API.Dto.Store;

public class AuthorDto
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime? DataOfBirth { get; set; }
}