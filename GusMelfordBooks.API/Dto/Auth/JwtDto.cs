namespace GusMelfordBooks.API.Dto.Auth;

public class JwtDto
{
    public string? AccessToken { get; set; }
    public string? UserRole { get; set; }
    public string? ExpiresIn { get; set; }
    public string? Name { get; set; }
}