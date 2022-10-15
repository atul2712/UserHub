using UserHub.DAL.Entities;
using UserHub.Models.User;

namespace UserHub.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        UserModel ValidateUser(string email, string password);
        bool CreateUser(User user, string role);
    }
}
