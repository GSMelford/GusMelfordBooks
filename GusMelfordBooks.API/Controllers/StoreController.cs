using GusMelfordBooks.API.Dto.Store;
using GusMelfordBooks.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GusMelfordBooks.API.Controllers;

[ApiController]
[Route("api/store")]
public class StoreController : Controller
{
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpPost("genre")]
    public async Task AddGenre([FromBody] GenreDto genreDto)
    {
        await _storeService.AddGenreAsync(genreDto.ToDomain());
    }
    
    [HttpPost("author")]
    public async Task AddAuthor([FromBody] AuthorDto authorDto)
    {
        await _storeService.AddAuthorAsync(authorDto.ToDomain());
    }
    
    [HttpGet("genres")]
    public List<GenreDto> GetGenres()
    {
        return _storeService.GetAllGenres().Select(x=>x.ToDto()).ToList();
    }
    
    [HttpGet("authors")]
    public IEnumerable<AuthorDto> GetAuthors()
    {
        return _storeService.GetAllAuthor().Select(x=>x.ToDto()).ToList();
    }
}