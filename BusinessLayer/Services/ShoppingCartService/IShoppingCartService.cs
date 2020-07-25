

using Entities.DataModels;
using Entities.WebViewModels.CartItem;
using System.Collections.Generic;

namespace BusinessLayer.Services.ShoppingCartService
{
    public interface IShoppingCartService
    {
        int GetShoppingCartId(string userId);
        int AddItemToCart(int productId, int shoppingCartId,int quantity);
        IEnumerable<CartItemModel> GetCartItems(int shoppingCartId);
    }
}
