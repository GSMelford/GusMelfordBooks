using GusMelfordBooks.CustomExceptions;
using GusMelfordBooks.Domain;
using GusMelfordBooks.Domain.Interfaces;
using GusMelfordBooks.Infrastructure.Interfaces;
using GusMelfordBooks.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GusMelfordBooks.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly IDatabaseContext _databaseContext;
    
    public StoreRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    public async Task AddAuthor(AuthorData authorData)
    {
        Author? author = await _databaseContext.Set<Author>()
            .FirstOrDefaultAsync(x => x.FirstName == authorData.FirstName && x.LastName == authorData.LastName);

        if (author is not null)
        {
            throw new ConflictException($"{author.FirstName} {author.LastName} already exists");
        }

        await _databaseContext.AddAsync(new Author
        {
            FirstName = authorData.FirstName,
            MiddleName = authorData.MiddleName,
            LastName = authorData.LastName,
            DataOfBirth = authorData.DataOfBirth
        });
        await _databaseContext.SaveChangesAsync();
    }

    public async Task AddGenre(GenreData genreData)
    {
        Genre? genre = await _databaseContext.Set<Genre>()
            .FirstOrDefaultAsync(x => x.Name == genreData.Name && x.Description == genreData.Description);
        
        if (genre is not null)
        {
            throw new ConflictException($"{genreData.Name} already exists");
        }
        
        await _databaseContext.AddAsync(new Genre
        {
            Name = genreData.Name,
            Description = genreData.Description
        });
        await _databaseContext.SaveChangesAsync();
    }

    public IEnumerable<GenreData> GetAllGenres()
    {
        return _databaseContext.Set<Genre>().Select(x => new GenreData(x.Name, x.Description));
    }
    
    public IEnumerable<AuthorData> GetAllAuthor()
    {
        return _databaseContext.Set<Author>().Select(x => new AuthorData(x.FirstName, x.MiddleName, x.LastName, x.DataOfBirth));
    }
}