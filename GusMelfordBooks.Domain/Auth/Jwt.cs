namespace GusMelfordBooks.Domain.Auth;

public class Jwt
{
    public string? AccessToken { get; }
    public string? UserRole { get; }
    public string? ExpiresIn { get; }
    public string? Name { get; }
    
    public Jwt(string? accessToken, string? userRole, string? expiresIn, string? name)
    {
        AccessToken = accessToken;
        UserRole = userRole;
        ExpiresIn = expiresIn;
        Name = name;
    }
}