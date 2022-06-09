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
    
    public async Task AddAuthorAsync(AuthorData authorData)
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

    public async Task AddAddress(AddressData addressData)
    {
        Address? address = await _databaseContext.Set<Address>()
            .FirstOrDefaultAsync(x => x.Country == addressData.Country && x.City == addressData.City && x.Street == addressData.Street);
        
        if (address is not null)
        {
            throw new ConflictException($"{address.Street} already exists");
        }
        
        await _databaseContext.AddAsync(new Address
        {
            Country = addressData.Country,
            City = addressData.City,
            Street = addressData.Street
        });
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task AddPublisher(PublisherData publisherData)
    {
        Publisher? publisher = await _databaseContext.Set<Publisher>()
            .FirstOrDefaultAsync(x => x.Name == publisherData.Name && x.Phone == publisherData.Phone);
        
        if (publisher is not null)
        {
            throw new ConflictException($"{publisher.Name} already exists");
        }

        Address? address = await _databaseContext.Set<Address>()
            .FirstOrDefaultAsync(x => x.Id == publisherData.AddressId);
        
        if (address is null)
        {
            throw new ConflictException($"Address id {publisherData.AddressId} not exists");
        }
        
        await _databaseContext.AddAsync(new Publisher
        {
            Address = address,
            Name = publisherData.Name,
            Phone = publisherData.Phone
        });
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task AddBook(BookData bookData)
    {
        await _databaseContext.AddAsync(await BuildBook(bookData));
        await _databaseContext.SaveChangesAsync();
    }

    private async Task<Book> BuildBook(BookData bookData)
    {
        Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x => x.Title == bookData.Title);
       
        if (book is not null)
        {
            throw new ConflictException($"{book.Title} already exists");
        }
        
        book = new Book();
        foreach (Guid genresId in bookData.GenresIds ?? new List<Guid>())
        {
            Genre? genre = await _databaseContext.Set<Genre>().FirstOrDefaultAsync(x => x.Id == genresId);
            if (genre is null)
            {
                continue;
            }
            
            book.Genres.Add(genre);
        }

        if (!book.Genres.Any())
        {
            throw new ConflictException($"The book {book.Title} has no genre");
        }
        
        foreach (Guid publisherId in bookData.PublisherIds ?? new List<Guid>())
        {
            Publisher? publisher = await _databaseContext.Set<Publisher>().FirstOrDefaultAsync(x => x.Id == publisherId);
            if (publisher is null)
            {
                continue;
            }
            
            book.Publishers.Add(publisher);
        }
        
        if (!book.Publishers.Any())
        {
            throw new ConflictException($"The book {book.Title} has no publisher");
        }
        
        Author? author = await _databaseContext.Set<Author>()
            .FirstOrDefaultAsync(x => x.Id == bookData.AuthorId);
        
        if (author is null)
        {
            throw new ConflictException($"Author id {bookData.AuthorId} not exists");
        }

        book.Author = author;
        book.Description = bookData.Description;
        book.Language = bookData.Language;
        book.Price = bookData.Price;
        book.Title = bookData.Title;

        return book;
    }
    
    public IEnumerable<GenreData> GetAllGenres()
    {
        return _databaseContext.Set<Genre>().Select(x => new GenreData(x.Id, x.Name, x.Description));
    }
    
    public IEnumerable<AuthorData> GetAllAuthor()
    {
        return _databaseContext.Set<Author>().Select(x => new AuthorData(x.Id, x.FirstName, x.MiddleName, x.LastName, x.DataOfBirth));
    }
    
    public IEnumerable<AddressData> GetAllAddresses()
    {
        return _databaseContext.Set<Address>().Select(x => new AddressData(x.Id, x.Country, x.City, x.Street));
    }
    
    public IEnumerable<PublisherInfo> GetAllPublishers()
    {
        return _databaseContext.Set<Publisher>()
            .Include(x=>x.Address)
            .Select(x => new PublisherInfo(
                x.Id,
                x.Name, 
                x.Phone,
                string.Join(" ", x.Address.Country, x.Address.City, x.Address.Street)));
    }
    
    public IEnumerable<BookInfo> GetAllBooks()
    {
        return _databaseContext.Set<Book>()
            .Include(x => x.Genres)
            .Include(x => x.Orders)
            .Include(x => x.Publishers)
            .Include(x => x.Author)
            .Select(x => new BookInfo(
                x.Id,
                string.Join(" ", x.Author.FirstName, x.Author.MiddleName, x.Author.LastName),
                x.Title,
                x.Language,
                x.Description,
                x.Price,
                string.Join(",", x.Publishers.Select(y => y.Name)),
                string.Join(",", x.Genres.Select(y => y.Name))));
    }

    public async Task UpdateGenre(GenreData genreData)
    {
        Genre? genre = await _databaseContext.Set<Genre>().FirstOrDefaultAsync(x=> x.Id == genreData.Id);
        
        if (genre is null)
        {
            throw new ConflictException($"Genre id {genreData.Id} not exists");
        }

        genre.Name = genreData.Name;
        genre.Description = genreData.Description;
        _databaseContext.Update(genre);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task UpdateAuthor(AuthorData authorData)
    {
        Author? author = await _databaseContext.Set<Author>().FirstOrDefaultAsync(x=> x.Id == authorData.Id);
        
        if (author is null)
        {
            throw new ConflictException($"Author id {authorData.Id} not exists");
        }

        author.FirstName = authorData.FirstName;
        author.MiddleName = authorData.MiddleName;
        author.LastName = authorData.LastName;
        author.DataOfBirth = authorData.DataOfBirth;
        _databaseContext.Update(author);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAddress(AddressData addressData)
    {
        Address? address = await _databaseContext.Set<Address>().FirstOrDefaultAsync(x=> x.Id == addressData.Id);
        
        if (address is null)
        {
            throw new ConflictException($"Address id {addressData.Id} not exists");
        }

        address.Street = addressData.Street;
        address.Country = addressData.Country;
        address.City = addressData.City;
        _databaseContext.Update(address);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task UpdatePublisher(PublisherData publisherData)
    {
        Publisher? publisher = await _databaseContext.Set<Publisher>().FirstOrDefaultAsync(x=> x.Id == publisherData.Id);
        
        if (publisher is null)
        {
            throw new ConflictException($"Publisher id {publisherData.Id} not exists");
        }
        
        publisher.Address = await _databaseContext.Set<Address>().FirstOrDefaultAsync(x=> x.Id == publisherData.AddressId) ?? new Address();
        publisher.Name = publisherData.Name;
        publisher.Phone = publisherData.Phone;
        _databaseContext.Update(publisher);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task UpdateBook(BookData bookData)
    {
        Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x=> x.Id == bookData.Id);
        
        if (book is null)
        {
            throw new ConflictException($"Book id {bookData.Id} not exists");
        }

        book.Description = bookData.Description;
        book.Language = bookData.Language;
        book.Price = bookData.Price;
        book.Title = bookData.Title;
        _databaseContext.Update(book);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task RemoveGenre(Guid genreId)
    {
        Genre? genre = await _databaseContext.Set<Genre>().FirstOrDefaultAsync(x=> x.Id == genreId);
        
        if (genre is null)
        {
            throw new ConflictException($"Genre id {genreId} not exists");
        }

        _databaseContext.Remove(genre);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task RemoveAuthor(Guid authorId)
    {
        Author? author = await _databaseContext.Set<Author>().FirstOrDefaultAsync(x=> x.Id == authorId);
        
        if (author is null)
        {
            throw new ConflictException($"Author id {authorId} not exists");
        }

        _databaseContext.Remove(author);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task RemoveAddress(Guid addressId)
    {
        Address? address = await _databaseContext.Set<Address>().FirstOrDefaultAsync(x=> x.Id == addressId);
        
        if (address is null)
        {
            throw new ConflictException($"Address id {addressId} not exists");
        }

        _databaseContext.Remove(address);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task RemovePublisher(Guid publisherId)
    {
        Publisher? publisher = await _databaseContext.Set<Publisher>().FirstOrDefaultAsync(x=> x.Id == publisherId);
        
        if (publisher is null)
        {
            throw new ConflictException($"Publisher id {publisherId} not exists");
        }

        _databaseContext.Remove(publisher);
        await _databaseContext.SaveChangesAsync();
    }
    
    public async Task RemoveBook(Guid bookId)
    {
        Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x=> x.Id == bookId);
        
        if (book is null)
        {
            throw new ConflictException($"Book id {bookId} not exists");
        }

        _databaseContext.Remove(book);
        await _databaseContext.SaveChangesAsync();
    }
}