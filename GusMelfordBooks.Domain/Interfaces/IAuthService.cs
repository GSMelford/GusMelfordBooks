using GusMelfordBooks.Domain.Auth;

namespace GusMelfordBooks.Domain.Interfaces;

public interface IAuthService
{
    Task<Jwt?> GetToken(UserCredentials userCredentials);
    Task Register(UserData userData, string userRole);
}