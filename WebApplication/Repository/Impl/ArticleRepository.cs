using Domain;

namespace Repository.Impl
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly DatabaseContext _dbContext;

        public ArticleRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}