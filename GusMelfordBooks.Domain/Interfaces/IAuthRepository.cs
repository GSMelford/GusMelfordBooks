using GusMelfordBooks.Domain.Auth;
using GusMelfordBooks.Infrastructure.Models;

namespace GusMelfordBooks.Domain.Interfaces;

public interface IAuthRepository
{
    Task<User?> GetUser(string email, string password);
    Task<bool> AddUser(UserData? userData, string userRole);
    Task<Guid> GetUserId(string email);
}