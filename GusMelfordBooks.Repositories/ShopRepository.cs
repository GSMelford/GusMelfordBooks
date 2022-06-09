using GusMelfordBooks.CustomExceptions;
using GusMelfordBooks.Domain;
using GusMelfordBooks.Domain.Interfaces;
using GusMelfordBooks.Infrastructure.Interfaces;
using GusMelfordBooks.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GusMelfordBooks.Repositories;

public class ShopRepository : IShopRepository
{
    private readonly IDatabaseContext _databaseContext;
    
    public ShopRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IEnumerable<UserBookInfo> GetUserBooks(Guid userId)
    {
        return _databaseContext.Set<Order>()
            .Include(x => x.Customer)
            .Where(x => x.Customer.Id == userId)
            .Include(x => x.Books)
            .SelectMany(x => x.Books.Select(y => new {Book = y, OrderDate = x.Date}))
            .Select(x => new UserBookInfo(x.Book.Title, x.Book.Price, x.OrderDate));
    }

    public async Task BuyBooks(List<Guid> bookIds, Guid userId)
    {
        User user = await GetUserOrError(userId);
        Order order = new Order
        {
            Customer = user,
            Date = DateTime.UtcNow
        };

        foreach (Guid bookId in bookIds)
        {
            Book? book = await _databaseContext.Set<Book>().FirstOrDefaultAsync(x => x.Id == bookId);
            if (book is null) {
                continue;
            }
            
            order.Books.Add(book);
        }

        if (!order.Books.Any())
        {
            throw new ConflictException("You must select at least one book!");
        }

        order.Price = order.Books.Sum(x => x.Price);
        await _databaseContext.AddAsync(order);
        await _databaseContext.SaveChangesAsync();
    }

    private async Task<User> GetUserOrError(Guid userId)
    {
        User? user = await _databaseContext.Set<User>().FirstOrDefaultAsync(x => x.Id == userId);

        if (user is null)
        {
            throw new ConflictException("User is not exist");
        }

        return user;
    }
}