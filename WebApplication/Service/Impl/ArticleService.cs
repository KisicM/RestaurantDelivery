using Domain;
using System.Collections.Generic;
using AutoMapper;
using Repository;

namespace Service.Impl
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public Article Create(Article article)
        {
            return _articleRepository.Insert(article);
        }

        public IEnumerable<Article> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public Article GetById(int id)
        {
            return _articleRepository.GetById(id);
        }
    }
}