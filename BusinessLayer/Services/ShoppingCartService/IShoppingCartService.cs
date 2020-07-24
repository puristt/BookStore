

using Entities.DataModels;

namespace BusinessLayer.Services.ShoppingCartService
{
    public interface IShoppingCartService
    {
        int GetShoppingCartId(string userId);
        int AddItemToCart(int productId, int shoppingCartId,int quantity);
    }
}
