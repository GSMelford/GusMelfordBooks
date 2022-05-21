using GusMelfordBooks.Domain.Auth;
using GusMelfordBooks.Domain.Interfaces;
using GusMelfordBooks.Infrastructure.Interfaces;
using GusMelfordBooks.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GusMelfordBooks.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly IDatabaseContext _databaseContext;
    
    public AuthRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public async Task<User?> GetUser(string email, string password)
    {
        return await _databaseContext.Set<User>()
            .Include(x=>x.Role)
            .FirstOrDefaultAsync(user => user.Email.Equals(email) && user.Password.Equals(password));
    }
    
    public async Task<bool> AddUser(UserData? userData, string userRole)
    {
        Role? role = await _databaseContext.Set<Role>()
            .FirstOrDefaultAsync(x => x.Name.Equals(userRole));

        if (userData is null)
        {
            return false;
        }

        bool isFullData = !string.IsNullOrEmpty(userData.Email) ||
                          !string.IsNullOrEmpty(userData.Password) ||
                          !string.IsNullOrEmpty(userData.Phone) ||
                          !string.IsNullOrEmpty(userData.FirstName) ||
                          !string.IsNullOrEmpty(userData.LastName);

        if (!isFullData)
        {
            throw new Exception("Not all fields are filled! Try again.");
        }
        
        await _databaseContext.AddAsync(new User
        {
            Email = userData.Email!,
            Password = userData.Password!,
            Phone = userData.Phone!,
            FirstName = userData.FirstName!,
            MiddleName = userData.MiddleName,
            LastName = userData.LastName!,
            Role = role!
        });

        await _databaseContext.SaveChangesAsync();
        return true;
    }
}