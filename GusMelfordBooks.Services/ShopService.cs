using GusMelfordBooks.Domain;
using GusMelfordBooks.Domain.Interfaces;

namespace GusMelfordBooks.Services;

public class ShopService : IShopService
{
    private readonly IShopRepository _shopRepository;

    public ShopService(IShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }

    public IEnumerable<UserBookInfo> GetUserBooksAsync(Guid userId)
    {
        return _shopRepository.GetUserBooks(userId);
    }

    public async Task BuyBooks(List<Guid> bookIds, Guid userId)
    {
        await _shopRepository.BuyBooks(bookIds, userId);
    }
}