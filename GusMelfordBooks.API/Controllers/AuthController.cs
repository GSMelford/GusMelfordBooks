using GusMelfordBooks.API.Dto.Auth;
using GusMelfordBooks.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GusMelfordBooks.API.Controllers;

[ApiController]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] UserDataDto userDataDto)
    {
        await _authService.Register(userDataDto.ToDomain(), "Customer");
        return Ok();
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost("/admin/register")]
    public async Task<IActionResult> Register([FromBody] UserDataDto userDataDto, [FromQuery] string userRole)
    {
        await _authService.Register(userDataDto.ToDomain(), userRole);
        return Ok();
    }
    
    [HttpPost("/token")]
    public async Task<JwtDto> Token([FromBody] UserCredentialsDto userCredentialsDto)
    {
        return (await _authService.GetToken(userCredentialsDto.ToDomain()))?.ToDto() ?? new JwtDto();
    }
}