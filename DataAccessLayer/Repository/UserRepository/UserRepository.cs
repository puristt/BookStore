using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperRepository<User> _repository;
        public UserRepository(IDapperRepository<User> dapperRepository)
        {
            _repository = dapperRepository;
        }

        public User GetById(string id)
        {
            var parameters = new { Id = id };
            return _repository.LoadData("spGetUser", parameters).FirstOrDefault();
        }

        public int Save(User entity,bool isNewUser)
        {
            int result;

            if (isNewUser)
            {
                var parameters = new { entity.Id, entity.UserName, entity.Email };
                result = _repository.SaveData<User>("spInsertUser", parameters);
            }
            else
            {
                var parameters = new
                {
                    entity.Id,
                    entity.FirstName,
                    entity.LastName,
                    entity.UserName,
                    entity.Email,
                    entity.CreatedAt,
                    entity.PhoneNumber
                };
                result = _repository.SaveData<User>("spUpdateUser", parameters);
            }

            return result;

        }
    }
}
