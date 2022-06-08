namespace GusMelfordBooks.API.Dto.Store;

public class PublisherDataDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public Guid AddressId { get; set; }
}