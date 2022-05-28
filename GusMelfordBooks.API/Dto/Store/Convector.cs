using GusMelfordBooks.Domain;

namespace GusMelfordBooks.API.Dto.Store;

public static class Convector
{
    public static AuthorData ToDomain(this AuthorDto authorDto)
    {
        return new AuthorData(authorDto.FirstName, authorDto.MiddleName, authorDto.LastName, authorDto.DataOfBirth);
    }
    
    public static GenreData ToDomain(this GenreDto genreDto)
    {
        return new GenreData(genreDto.Name, genreDto.Description);
    }

    public static GenreDto ToDto(this GenreData genreData)
    {
        return new GenreDto
        {
            Name = genreData.Name,
            Description = genreData.Description
        };
    }
    
    public static AuthorDto ToDto(this AuthorData authorData)
    {
        return new AuthorDto
        {
            FirstName = authorData.FirstName,
            LastName = authorData.LastName,
            MiddleName = authorData.LastName,
            DataOfBirth = authorData.DataOfBirth
        };
    }
}