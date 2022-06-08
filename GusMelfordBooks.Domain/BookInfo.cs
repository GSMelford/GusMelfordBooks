namespace GusMelfordBooks.Domain;

public class BookInfo
{
    public Guid Id { get; set; }
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Publishers { get; set; }
    public string Genres { get; set; }

    public BookInfo(Guid id, string authorName, string title, string language, string? description, decimal price, string publishers, string genres)
    {
        Id = id;
        AuthorName = authorName;
        Title = title;
        Language = language;
        Description = description;
        Price = price;
        Publishers = publishers;
        Genres = genres;
    }
}