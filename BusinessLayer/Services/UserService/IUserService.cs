using Entities.DataModels;


namespace BusinessLayer.Services.UserService
{
    public interface IUserService
    {
        int SaveUser(User user);
    }
}
