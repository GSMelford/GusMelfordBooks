using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using GusMelfordBooks.CustomExceptions;
using GusMelfordBooks.Domain.Auth;
using GusMelfordBooks.Domain.Interfaces;
using GusMelfordBooks.Domain.Settings;
using GusMelfordBooks.Extensions;
using GusMelfordBooks.Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;

namespace GusMelfordBooks.Services;

public class AuthService : IAuthService
{
    private readonly AppSettings _appSettings;
    private readonly IAuthRepository _authRepository;
    
    public AuthService(AppSettings appSettings, IAuthRepository authRepository)
    {
        _authRepository = authRepository;
        _appSettings = appSettings;
    }

    public async Task Register(UserData userData, string userRole)
    {
        if (!await _authRepository.AddUser(userData, userRole))
        {
            throw new Exception("Error creating user");
        }
    }
    
    public async Task<Jwt?> GetToken(UserCredentials userCredentials)
    {
        ClaimsIdentity? claimsIdentity = await GetIdentity(userCredentials);
        if (claimsIdentity == null)
        {
            throw new UnauthorizedException("Wrong login or password.");
        }

        DateTime utcNow = DateTime.UtcNow;
        TimeSpan lifeTime = TimeSpan.FromMinutes(_appSettings.AuthOptions?.Lifetime == 0
            ? 10
            : _appSettings.AuthOptions?.Lifetime ?? 10);

        DateTime expiresIn = utcNow.Add(lifeTime);
        var jwt = new JwtSecurityToken(
            _appSettings.AuthOptions?.Issuer,
            _appSettings.AuthOptions?.Audience,
            notBefore: utcNow,
            claims: claimsIdentity.Claims,
            expires: utcNow.Add(lifeTime),
            signingCredentials: new SigningCredentials(Helper.GetSymmetricSecurityKey(_appSettings.AuthOptions?.Key),
                SecurityAlgorithms.HmacSha256));
        
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return new Jwt(
            encodedJwt,
            claimsIdentity.Claims.FirstOrDefault(x=> x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value, 
            expiresIn.ToString(CultureInfo.InvariantCulture));
    }
    private async Task<ClaimsIdentity?> GetIdentity(UserCredentials userCredentials)
    {
        User? user = await _authRepository.GetUser(userCredentials.Email ?? string.Empty, userCredentials.Password ?? string.Empty);
        if (user is null)
        {
            return null;
        }
        
        List<Claim> claims = new List<Claim>
        {
            new (ClaimsIdentity.DefaultNameClaimType, user.Email),
            new (ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
        };
        
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
            claims, 
            "Token",
            ClaimsIdentity.DefaultNameClaimType, 
            ClaimsIdentity.DefaultRoleClaimType);
        
        return claimsIdentity;
    }
}