using UserHub.DAL.Entities;
using UserHub.Models.User;

namespace UserHub.Services.Interfaces
{
    public interface IAuthService
    {
        UserModel ValidateUser(string email, string password);
        bool CreateUser(User user, string role);
    }
}
