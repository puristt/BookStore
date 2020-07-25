using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using Entities.WebViewModels.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.ShoppingCartRepository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly IDapperRepository<CartItem> _repository;
        public CartItemRepository(IDapperRepository<CartItem> repository)
        {
            _repository = repository;
        }
        public CartItem GetByBookIdAndShoppingCartId(int bookId, int shoppingCartId)
        {
            var parameters = new { BookId = bookId, ShoppingCartId = shoppingCartId };
            return _repository.LoadData("spGetCartItemByBookAndCartId", parameters).FirstOrDefault();
        }

        public IEnumerable<CartItemModel> GetCartItemsByShoppingCartId(int shoppingCartId)
        {
            return _repository.LoadData<CartItemModel>("spGetCartItemsByShoppingCartId", new { ShoppingCartId = shoppingCartId });
        }

        public int SaveModel(CartItem entity)
        {
            int result;
            if (entity.Id == default)
            {
                var parameters = new { entity.BookId, entity.ShoppingCartId, entity.Quantity };
                result = _repository.SaveData<CartItem>("spInsertCartItem", parameters);
            }
            else
            {
                var parameters = new { entity.Id, entity.Quantity };
                result = _repository.SaveData<CartItem>("spUpdateCartItem", parameters);
            }
            return result;
        }
    }
}
