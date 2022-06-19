using Domain;
using System.Linq;

namespace Repository.Impl
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Username == username);
        }
    }
}