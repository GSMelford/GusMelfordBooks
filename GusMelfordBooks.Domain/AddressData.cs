namespace GusMelfordBooks.Domain;

public class AddressData
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }

    public AddressData(Guid id, string country, string city, string street)
    {
        Id = id;
        Country = country;
        City = city;
        Street = street;
    }
}