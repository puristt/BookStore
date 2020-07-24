using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.ShoppingCartRepository
{
    public interface ICartItemRepository
    {
        CartItem GetByBookIdAndShoppingCartId(int bookId, int shoppingCartId);
        int SaveModel(CartItem entity);

    }
}
