namespace GusMelfordBooks.Domain;

public class PublisherData
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public PublisherData(Guid id, Guid addressId, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
        AddressId = addressId;
    }
}