using System.Collections.Generic;
using Domain;
using DTO;

namespace Service
{
    public interface IUserService
    {
        public User GetUser(int id);
        public IEnumerable<User> GetAllUsers();
        public User RegisterUser(User user);
        public User Update(User user);
        public User GetByUsername(string username);
    }
}