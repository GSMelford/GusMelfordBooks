namespace GusMelfordBooks.Domain.Interfaces;

public interface IShopService
{
    IEnumerable<UserBookInfo> GetUserBooksAsync(Guid userId);
    Task BuyBooks(List<Guid> bookIds, Guid userId);
}