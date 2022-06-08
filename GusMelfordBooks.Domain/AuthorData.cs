namespace GusMelfordBooks.Domain;

public class AuthorData
{
    public Guid Id { get; set; }
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }
    public DateTime? DataOfBirth { get; }

    public AuthorData(Guid id, string firstName, string? middleName, string lastName, DateTime? dataOfBirth)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        DataOfBirth = dataOfBirth;
    }
}