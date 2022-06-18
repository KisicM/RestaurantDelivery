using Domain;
using DTO;

namespace Service
{
    public interface ILoginService
    {
        public User GetUsingCredentials(string username, string password);
    }
}