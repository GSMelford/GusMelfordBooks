namespace GusMelfordBooks.API.Dto.Auth;

public class JwtDto
{
    public string? AccessToken { get; set; }
    public string? UserEmail { get; set; }
}