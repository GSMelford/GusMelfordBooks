namespace GusMelfordBooks.Domain;

public class BookData
{
    public Guid Id { get; set; }
    public Guid? AuthorId { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<Guid>? PublisherIds { get; set; }
    public List<Guid>? GenresIds { get; set; }

    public BookData(
        Guid id,
        Guid? authorId,
        string title, 
        string language, 
        string? description,
        decimal price, 
        List<Guid>? publisherIds,
        List<Guid>? genresIds)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        Language = language;
        Description = description;
        Price = price;
        PublisherIds = publisherIds;
        GenresIds = genresIds;
    }
}