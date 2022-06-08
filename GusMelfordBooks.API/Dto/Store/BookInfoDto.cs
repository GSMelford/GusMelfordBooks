namespace GusMelfordBooks.API.Dto.Store;

public class BookInfoDto
{
    public Guid Id { get; set; }
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string Publishers { get; set; }
    public string Genres { get; set; }
}