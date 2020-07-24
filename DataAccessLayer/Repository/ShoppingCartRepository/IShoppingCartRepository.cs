using Entities.DataModels;


namespace DataAccessLayer.Repository.ShoppingCartRepository
{
    public interface IShoppingCartRepository
    {
        int Add(string userId);
        ShoppingCart GetByUserId(string userId);
    }
}
