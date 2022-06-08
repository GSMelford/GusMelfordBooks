namespace GusMelfordBooks.API.Dto.Store;

public class AuthorDto
{
    public Guid? Id { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    public string? DateOfBirth { get; set; }
}