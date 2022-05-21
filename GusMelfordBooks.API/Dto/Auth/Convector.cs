using GusMelfordBooks.Domain;
using GusMelfordBooks.Domain.Auth;

namespace GusMelfordBooks.API.Dto.Auth;

public static class Convector
{
    public static JwtDto ToDto(this Jwt jwt)
    {
        return new JwtDto
        {
            AccessToken = jwt.AccessToken,
            UserEmail = jwt.UserEmail
        };
    }

    public static UserCredentials ToDomain(this UserCredentialsDto userCredentialsDto)
    {
        return new UserCredentials(userCredentialsDto.Email ?? string.Empty, userCredentialsDto.Password ?? string.Empty);
    }

    public static UserData ToDomain(this UserDataDto userDataDto)
    {
        return new UserData(
            userDataDto.FirstName,
            userDataDto.MiddleName,
            userDataDto.LastName,
            userDataDto.Phone,
            userDataDto.Email,
            userDataDto.Password);
    }
}