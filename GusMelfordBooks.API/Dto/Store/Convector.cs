using GusMelfordBooks.Domain;
using GusMelfordBooks.Extensions;

namespace GusMelfordBooks.API.Dto.Store;

public static class Convector
{
    public static AuthorData ToDomain(this AuthorDto authorDto)
    {
        return new AuthorData(
            authorDto.Id ?? Guid.Empty,
            authorDto.FirstName, 
            authorDto.MiddleName, 
            authorDto.LastName, 
            string.IsNullOrEmpty(authorDto.DateOfBirth) ? null : authorDto.DateOfBirth.ToDateTime());
    }
    
    public static GenreData ToDomain(this GenreDto genreDto)
    {
        return new GenreData(genreDto.Id ?? Guid.Empty, genreDto.Name, genreDto.Description);
    }
    
    public static AddressData ToDomain(this AddressDto addressDto)
    {
        return new AddressData(addressDto.Id ?? Guid.Empty, addressDto.Country, addressDto.City, addressDto.Street);
    }
    
    public static PublisherData ToDomain(this PublisherDataDto publisherDataDto)
    {
        return new PublisherData(publisherDataDto.Id ?? Guid.Empty, publisherDataDto.AddressId, publisherDataDto.Name, publisherDataDto.Phone);
    }

    public static BookData ToDomain(this BookDto bookDto)
    {
        return new BookData(
            bookDto.Id ?? Guid.Empty, 
            bookDto.AuthorId, 
            bookDto.Title, 
            bookDto.Language,
            bookDto.Description,
            bookDto.Price,
            bookDto.PublisherIds,
            bookDto.GenreIds);
    }
    
    public static GenreDto ToDto(this GenreData genreData)
    {
        return new GenreDto
        {
            Id = genreData.Id,
            Name = genreData.Name,
            Description = genreData.Description
        };
    }
    
    public static AuthorDto ToDto(this AuthorData authorData)
    {
        return new AuthorDto
        {
            Id = authorData.Id,
            FirstName = authorData.FirstName,
            MiddleName = authorData.MiddleName,
            LastName = authorData.LastName,
            DateOfBirth = authorData.DataOfBirth?.ToString("d")
        };
    }
    
    public static AddressDto ToDto(this AddressData addressData)
    {
        return new AddressDto
        {
            Id = addressData.Id,
            City = addressData.City,
            Country = addressData.Country,
            Street = addressData.Street
        };
    }
    
    public static PublisherDto ToDto(this PublisherInfo publisherInfo)
    {
        return new PublisherDto
        {
            Id = publisherInfo.Id,
            Name = publisherInfo.Name,
            Phone = publisherInfo.Phone,
            Address = publisherInfo.Address
        };
    }
    
    public static BookInfoDto ToDto(this BookInfo bookInfo)
    {
        return new BookInfoDto
        {
            Id = bookInfo.Id,
            Description = bookInfo.Description,
            Genres = bookInfo.Genres,
            Language = bookInfo.Language,
            Price = bookInfo.Price,
            Publishers = bookInfo.Publishers,
            Title = bookInfo.Title,
            AuthorName = bookInfo.AuthorName
        };
    }
}