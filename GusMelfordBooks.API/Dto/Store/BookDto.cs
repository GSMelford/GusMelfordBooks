namespace GusMelfordBooks.API.Dto.Store;

public class BookDto
{
    public Guid? Id { get; set; }
    public Guid AuthorId { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public List<Guid> PublisherIds { get; set; }
    public List<Guid> GenreIds { get; set; }
}