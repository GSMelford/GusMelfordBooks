namespace GusMelfordBooks.Domain.Interfaces;

public interface IShopRepository
{
    IEnumerable<UserBookInfo> GetUserBooks(Guid userId);
    Task BuyBooks(List<Guid> bookIds, Guid userId);
}