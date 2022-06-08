namespace GusMelfordBooks.Domain;

public class GenreData
{
    public Guid Id { get; set; }
    public string Name { get; }
    public string? Description { get; }

    public GenreData(Guid id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}