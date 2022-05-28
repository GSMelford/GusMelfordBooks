namespace GusMelfordBooks.Domain;

public class GenreData
{
    public string Name { get; }
    public string? Description { get; }

    public GenreData(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}