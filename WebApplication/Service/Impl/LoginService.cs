using Domain;
using DTO;
using Repository;

namespace Service.Impl
{
    public class LoginService : ILoginService
    {

        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUsingCredentials(string username, string password)
        {
            return _userRepository.GetUsingCredentials(username, password);
        }
    }
}