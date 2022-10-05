using HynteloCodingChallenge.Exceptions;
using HynteloCodingChallenge.Models;
using HynteloCodingChallenge.Repos.Interfaces;

namespace HynteloCodingChallenge.Repos.Implementations
{
    public class LocalRepository : IRepository
    {
        private List<Article> _articles;

        public LocalRepository()
        {
            _articles = new List<Article>()
            {
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Title = "Omega Shoes",
                    Text = "These shoes are really stylish, perfect for autumn and winter."
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Title = "Delta Shirt",
                    Text = "Do you wanna be cool? That's our answer!"
                },
                new Article()
                {
                    Id = Guid.NewGuid(),
                    Title = "Sigma Socks",
                    Text = "Well..just a pair of socks"
                }
            };
        }

        public Guid Create(Article article)
        {
            if (article == null || string.IsNullOrEmpty(article.Title))
                throw new ArticleException("Incorrect data provided");

            article.Id = Guid.NewGuid();
            _articles.Add(article);
            return (Guid)article.Id;
        }

        public bool Delete(Guid id)
        {
            Article? article = _articles.Find(x => x.Id == id);
            if (article == null)
                return false;
            _articles.Remove(article);
            return true;
        }

        public Article? Get(Guid id)
        {
            return _articles.Find(x => x.Id == id);
        }

        public bool Update(Article articleToUpdate)
        {
            if (articleToUpdate == null || string.IsNullOrEmpty(articleToUpdate.Title))
                throw new ArticleException("Incorrect data provided");

            Article? oldArticle = _articles.Find(x => x.Id == articleToUpdate.Id);
            if (oldArticle == null)
                return false;
            _articles.Remove(oldArticle);
            _articles.Add(articleToUpdate);
            return true;
        }
    }
}
