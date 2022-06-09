using GusMelfordBooks.API.Dto.Shop;
using GusMelfordBooks.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GusMelfordBooks.API.Controllers;

[ApiController]
[Route("api/shop")]
public class ShopController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IShopService _shopService;
    
    public ShopController(IShopService shopService, IAuthService authService)
    {
        _shopService = shopService;
        _authService = authService;
    }

    [HttpGet]
    [Authorize]
    [Route("user-books")]
    public async Task<IEnumerable<UserBookInfoDto>> GetUserBooks()
    {
        return _shopService.GetUserBooksAsync(Guid.Parse(HttpContext.User.Identity?.Name ?? string.Empty)).Select(x=>x.ToDomain());
    }
    
    [HttpPost]
    [Authorize]
    [Route("buy-books")]
    public async Task BuyBooks([FromBody] BookForBuyDto bookForBuyDto)
    {
        await _shopService.BuyBooks(bookForBuyDto.BookIds, Guid.Parse(HttpContext.User.Identity?.Name ?? string.Empty));
    }
}