namespace GusMelfordBooks.Domain.Auth;

public class Jwt
{
    public string? AccessToken { get; }
    public string? UserEmail { get; }
    
    public Jwt(string? accessToken, string? userEmail)
    {
        AccessToken = accessToken;
        UserEmail = userEmail;
    }
}