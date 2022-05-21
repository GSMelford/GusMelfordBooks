using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GusMelfordBooks.Extensions;

public class Helper
{
    public static SymmetricSecurityKey GetSymmetricSecurityKey(string? key)
    {
        return new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(key ?? throw new Exception("Private key not set")));
    }
}