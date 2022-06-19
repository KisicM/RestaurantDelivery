using Domain;

namespace Repository
{
    public interface IUserRepository : IGenericRepository<User>
    { 
        public User GetByUsername(string username);

    }
}