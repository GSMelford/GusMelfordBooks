namespace GusMelfordBooks.Domain.Interfaces;

public interface IStoreRepository
{
    Task AddAuthorAsync(AuthorData authorData);
    Task AddGenre(GenreData genreData);
    IEnumerable<GenreData> GetAllGenres();
    IEnumerable<AuthorData> GetAllAuthor();
}