namespace GusMelfordBooks.Domain.Interfaces;

public interface IStoreRepository
{
    Task AddAuthor(AuthorData authorData);
    Task AddGenre(GenreData genreData);
    IEnumerable<GenreData> GetAllGenres();
    IEnumerable<AuthorData> GetAllAuthor();
}