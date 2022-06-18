using Domain;

namespace Repository
{
    public interface IUserRepository : IGenericRepository<User>
    { 
        public User GetUsingCredentials(string username, string password);
    }
}