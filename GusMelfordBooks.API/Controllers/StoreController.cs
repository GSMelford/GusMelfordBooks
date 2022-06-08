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
    
    [HttpPost("address")]
    public async Task AddAddress([FromBody] AddressDto addressDto)
    {
        await _storeService.AddAddress(addressDto.ToDomain());
    }
    
    [HttpPost("publisher")]
    public async Task AddPublisher([FromBody] PublisherDataDto publisherDataDto)
    {
        await _storeService.AddPublisher(publisherDataDto.ToDomain());
    }
    
    [HttpPost("book")]
    public async Task AddBook([FromBody] BookDto bookDto)
    {
        await _storeService.AddBook(bookDto.ToDomain());
    }
    
    [HttpGet("genres")]
    public List<GenreDto> GetGenres()
    {
        return _storeService.GetAllGenres().Select(x=>x.ToDto()).ToList();
    }
    
    [HttpGet("authors")]
    public List<AuthorDto> GetAuthors()
    {
        return _storeService.GetAllAuthor().Select(x=>x.ToDto()).ToList();
    }
    
    [HttpGet("addresses")]
    public List<AddressDto> GetAddresses()
    {
        return _storeService.GetAllAddresses().Select(x=>x.ToDto()).ToList();
    }
    
    [HttpGet("publishers")]
    public List<PublisherDto> GetPublishers()
    {
        return _storeService.GetAllPublishers().Select(x=>x.ToDto()).ToList();
    }
    
    [HttpGet("books")]
    public List<BookInfoDto> GetBooks()
    {
        return _storeService.GetAllBooks().Select(x=>x.ToDto()).ToList();
    }
    
    [HttpPut("genre")]
    public async Task UpdateGenre([FromBody] GenreDto genreDto)
    {
        await _storeService.UpdateGenre(genreDto.ToDomain());
    }
    
    [HttpPut("author")]
    public async Task UpdateAuthor([FromBody] AuthorDto authorDto)
    {
        await _storeService.UpdateAuthor(authorDto.ToDomain());
    }
    
    [HttpPut("address")]
    public async Task UpdateAddress([FromBody] AddressDto addressDto)
    {
        await _storeService.UpdateAddress(addressDto.ToDomain());
    }
    
    [HttpPut("publisher")]
    public async Task UpdatePublisher([FromBody] PublisherDataDto publisherDataDto)
    {
        await _storeService.UpdatePublisher(publisherDataDto.ToDomain());
    }
    
    [HttpPut("book")]
    public async Task UpdateBook([FromBody] BookDto bookDto)
    {
        await _storeService.UpdateBook(bookDto.ToDomain());
    }
    
    [HttpDelete("genre")]
    public async Task RemoveGenre([FromQuery] Guid genreId)
    {
        await _storeService.RemoveGenre(genreId);
    }
    
    [HttpDelete("author")]
    public async Task RemoveAuthor([FromQuery] Guid authorId)
    {
        await _storeService.RemoveAuthor(authorId);
    }
    
    [HttpDelete("address")]
    public async Task RemoveAddress([FromQuery] Guid addressId)
    {
        await _storeService.RemoveAddress(addressId);
    }
    
    [HttpDelete("publisher")]
    public async Task RemovePublisher([FromQuery] Guid publisherId)
    {
        await _storeService.RemovePublisher(publisherId);
    }
    
    [HttpDelete("book")]
    public async Task RemoveBook([FromQuery] Guid bookId)
    {
        await _storeService.RemoveBook(bookId);
    }
}