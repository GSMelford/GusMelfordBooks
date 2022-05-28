using GusMelfordBooks.Domain;
using GusMelfordBooks.Domain.Interfaces;

namespace GusMelfordBooks.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task AddAuthorAsync(AuthorData authorData)
    {
        await _storeRepository.AddAuthorAsync(authorData);
    }
    
    public async Task AddGenreAsync(GenreData genreData)
    {
        await _storeRepository.AddGenre(genreData);
    }
    
    public IEnumerable<GenreData> GetAllGenres()
    {
        return _storeRepository.GetAllGenres();
    }
    
    public IEnumerable<AuthorData> GetAllAuthor()
    {
        return _storeRepository.GetAllAuthor();
    }
}