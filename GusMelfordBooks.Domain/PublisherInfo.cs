namespace GusMelfordBooks.Domain;

public class PublisherInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public PublisherInfo(Guid id, string name, string phone, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Address = address;
    }
}