using UserHub.DAL.Entities;
using UserHub.Models.User;
using UserHub.Repositories.Interfaces;
using UserHub.Services.Interfaces;

namespace UserHub.Services.Implementations
{
    //We are using this for loosely coupled
    //Data access should call with business logic as per current project architecture.
    public class AuthService : IAuthService
    {

        IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(User user, string role)
        {
            return _userRepository.CreateUser(user, role);
        }

        public UserModel ValidateUser(string email, string password)
        {
            return _userRepository.ValidateUser(email, password);
        }
    }
}
