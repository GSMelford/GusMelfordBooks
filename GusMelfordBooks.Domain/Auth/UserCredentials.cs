namespace GusMelfordBooks.Domain.Auth;

public class UserCredentials
{
    public string? Email { get;  }
    public string? Password { get; }

    public UserCredentials(string email, string password)
    {
        Email = email;
        Password = password;
    }
}