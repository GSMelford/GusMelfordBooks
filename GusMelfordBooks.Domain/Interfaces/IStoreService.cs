namespace GusMelfordBooks.Domain.Interfaces;

public interface IStoreService
{
    Task AddAuthorAsync(AuthorData authorData);
    Task AddGenreAsync(GenreData genreData);
    Task AddAddress(AddressData addressData);
    Task AddPublisher(PublisherData publisherData);
    Task AddBook(BookData bookData);
    IEnumerable<GenreData> GetAllGenres();
    IEnumerable<AuthorData> GetAllAuthor();
    IEnumerable<AddressData> GetAllAddresses();
    IEnumerable<PublisherInfo> GetAllPublishers();
    IEnumerable<BookInfo> GetAllBooks();
    Task UpdateGenre(GenreData genreData);
    Task UpdateAuthor(AuthorData authorData);
    Task UpdateAddress(AddressData addressData);
    Task UpdatePublisher(PublisherData publisherData);
    Task UpdateBook(BookData bookData);
    Task RemoveGenre(Guid genreId);
    Task RemoveAuthor(Guid authorId);
    Task RemoveAddress(Guid addressId);
    Task RemovePublisher(Guid publisherId);
    Task RemoveBook(Guid bookId);
}