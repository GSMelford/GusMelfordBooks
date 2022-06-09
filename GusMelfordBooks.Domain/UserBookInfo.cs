namespace GusMelfordBooks.Domain;

public class UserBookInfo
{
    public string Title { get; }
    public decimal Price { get; }
    public DateTime DateOfPurchase { get; }

    public UserBookInfo(string title, decimal price, DateTime dateOfPurchase)
    {
        Title = title;
        Price = price;
        DateOfPurchase = dateOfPurchase;
    }
}