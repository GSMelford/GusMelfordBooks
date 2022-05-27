namespace GusMelfordBooks.Domain.Auth;

public class Jwt
{
    public string? AccessToken { get; }
    public string? UserRole { get; }
    public string? ExpiresIn { get; }
    
    public Jwt(string? accessToken, string? userRole, string? expiresIn)
    {
        AccessToken = accessToken;
        UserRole = userRole;
        ExpiresIn = expiresIn;
    }
}