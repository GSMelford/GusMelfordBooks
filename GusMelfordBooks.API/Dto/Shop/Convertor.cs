using GusMelfordBooks.Domain;

namespace GusMelfordBooks.API.Dto.Shop;

public static class Convertor
{
    public static UserBookInfoDto ToDomain(this UserBookInfo userBookInfo)
    {
        return new UserBookInfoDto
        {
            Price = userBookInfo.Price,
            Title = userBookInfo.Title,
            DateOfPurchase = userBookInfo.DateOfPurchase
        };
    }
}