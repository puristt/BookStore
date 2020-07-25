using DataAccessLayer.Repository.ShoppingCartRepository;
using Entities.DataModels;
using Entities.WebViewModels.CartItem;
using System.Collections.Generic;

namespace BusinessLayer.Services.ShoppingCartService
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, ICartItemRepository cartItemRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _cartItemRepository = cartItemRepository;
        }

        public int AddItemToCart(int productId, int shoppingCartId, int quantity)
        {
            var cartItem = this.PrepareEntity(productId, shoppingCartId, quantity);

            int result = _cartItemRepository.SaveModel(cartItem);

            return result;

        }

        public IEnumerable<CartItemModel> GetCartItems(int shoppingCartId)
        {
            var cartItems = _cartItemRepository.GetCartItemsByShoppingCartId(shoppingCartId);

            foreach (var item in cartItems)
            {
                item.Subtotal = (item.Quantity * item.UnitPrice);
            }

            return cartItems;
        }

        public int GetShoppingCartId(string userId)
        {
            var shoppingCart_db = _shoppingCartRepository.GetByUserId(userId);

            if (shoppingCart_db == null)
            {
                var newShoppingCartId = _shoppingCartRepository.Add(userId);
                return newShoppingCartId;
            }

            return shoppingCart_db.Id;
        }
        public CartItem PrepareEntity(int productId, int shoppingCartId, int quantity)
        {
            var cartItem_db = _cartItemRepository.GetByBookIdAndShoppingCartId(productId, shoppingCartId);

            if (cartItem_db != null)
            {
                cartItem_db.Quantity += quantity;
                return cartItem_db;
            }
            else
            {
                CartItem newCartItem = new CartItem
                {
                    BookId = productId,
                    ShoppingCartId = shoppingCartId,
                    Quantity = 1
                };

                return newCartItem;
            }
        }

    }
}
