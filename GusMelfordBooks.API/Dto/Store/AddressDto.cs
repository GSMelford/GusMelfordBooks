namespace GusMelfordBooks.API.Dto.Store;

public class AddressDto
{
    public Guid? Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
}