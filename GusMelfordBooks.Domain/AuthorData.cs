namespace GusMelfordBooks.Domain;

public class AuthorData
{
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }
    public DateTime? DataOfBirth { get; }

    public AuthorData(string firstName, string? middleName, string lastName, DateTime? dataOfBirth)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        DataOfBirth = dataOfBirth;
    }
}