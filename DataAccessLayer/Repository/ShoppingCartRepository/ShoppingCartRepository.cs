using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.ShoppingCartRepository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IDapperRepository<ShoppingCart> _repository;
        public ShoppingCartRepository(IDapperRepository<ShoppingCart> repository)
        {
            _repository = repository;
        }
        public int Add(string userId)
        {
            var parameters = new { UserId = userId };

            var res = _repository.SaveDataWithReturnId("spInsertShoppingCart", parameters);
            return res;
        }

        public ShoppingCart GetByUserId(string userId)
        {
            var parameters = new { UserId = userId };
            return _repository.LoadData("spGetShoppingCartByUserId", parameters).FirstOrDefault();
        }
    }
}
