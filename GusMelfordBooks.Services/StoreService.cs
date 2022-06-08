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

    public async Task AddAddress(AddressData addressData)
    {
        await _storeRepository.AddAddress(addressData);
    }
    
    public async Task AddPublisher(PublisherData publisherData)
    {
        await _storeRepository.AddPublisher(publisherData);
    }
    
    public async Task AddBook(BookData bookData)
    {
        await _storeRepository.AddBook(bookData);
    }
    
    public IEnumerable<GenreData> GetAllGenres()
    {
        return _storeRepository.GetAllGenres();
    }
    
    public IEnumerable<AuthorData> GetAllAuthor()
    {
        return _storeRepository.GetAllAuthor();
    }
    
    public IEnumerable<AddressData> GetAllAddresses()
    {
        return _storeRepository.GetAllAddresses();
    }
    
    public IEnumerable<PublisherInfo> GetAllPublishers()
    {
        return _storeRepository.GetAllPublishers();
    }
    
    public IEnumerable<BookInfo> GetAllBooks()
    {
        return _storeRepository.GetAllBooks();
    }

    public async Task UpdateGenre(GenreData genreData)
    {
        await _storeRepository.UpdateGenre(genreData);
    }
    
    public async Task UpdateAuthor(AuthorData authorData)
    {
        await _storeRepository.UpdateAuthor(authorData);
    }
    
    public async Task UpdateAddress(AddressData addressData)
    {
        await _storeRepository.UpdateAddress(addressData);
    }
    
    public async Task UpdatePublisher(PublisherData publisherData)
    {
        await _storeRepository.UpdatePublisher(publisherData);
    }
    
    public async Task UpdateBook(BookData bookData)
    {
        await _storeRepository.UpdateBook(bookData);
    }
    
    public async Task RemoveGenre(Guid genreId)
    {
        await _storeRepository.RemoveGenre(genreId);
    }
    
    public async Task RemoveAuthor(Guid authorId)
    {
        await _storeRepository.RemoveAuthor(authorId);
    }
    
    public async Task RemoveAddress(Guid addressId)
    {
        await _storeRepository.RemoveAddress(addressId);
    }
    
    public async Task RemovePublisher(Guid publisherId)
    {
        await _storeRepository.RemovePublisher(publisherId);
    }
    
    public async Task RemoveBook(Guid bookId)
    {
        await _storeRepository.RemoveBook(bookId);
    }
}