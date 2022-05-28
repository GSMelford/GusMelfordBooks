using GusMelfordBooks.Infrastructure.Interfaces;

namespace GusMelfordBooks.Repositories;

public class ShopRepository
{
    private readonly IDatabaseContext _databaseContext;
    
    public ShopRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
}