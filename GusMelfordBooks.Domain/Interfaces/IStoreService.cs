namespace GusMelfordBooks.Domain.Interfaces;

public interface IStoreService
{
    Task AddAuthorAsync(AuthorData authorData);
    Task AddGenreAsync(GenreData genreData);
    IEnumerable<GenreData> GetAllGenres();
    IEnumerable<AuthorData> GetAllAuthor();
}