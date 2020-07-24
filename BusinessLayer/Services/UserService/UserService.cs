using DataAccessLayer.Repository.UserRepository;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int SaveUser(User user)
        {
            bool isNewUser = false;
            
            if(_userRepository.GetById(user.Id) == null)
            {
                isNewUser = true;
            }

            var result = _userRepository.Save(user, isNewUser);

            return result;

        }
    }
}
