using System.Collections.Generic;
using Domain;

namespace Service
{
    public interface IArticleService
    {
        public Article GetById(int id);
        public IEnumerable<Article> GetAll();
        public Article Create(Article article);
    }
}