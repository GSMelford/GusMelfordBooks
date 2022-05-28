using GusMelfordBooks.Domain;
using GusMelfordBooks.Domain.Interfaces;

namespace GusMelfordBooks.Services;

public class StoreService
{
    private readonly IStoreRepository _storeRepository;

    public StoreService(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task AddAuthor(AuthorData authorData)
    {
        await _storeRepository.AddAuthor(authorData);
    }
    
    public async Task AddGenre(GenreData genreData)
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