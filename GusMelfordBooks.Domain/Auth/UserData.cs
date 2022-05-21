namespace GusMelfordBooks.Domain.Auth;

public class UserData
{
    public string? FirstName { get; }
    public string? MiddleName { get; }
    public string? LastName { get; }
    public string? Phone { get; }
    public string? Email { get; }
    public string? Password { get; }

    public UserData(
        string? firstName,
        string? middleName,
        string? lastName,
        string? phone, 
        string? email, 
        string? password)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Password = password;
    }
}