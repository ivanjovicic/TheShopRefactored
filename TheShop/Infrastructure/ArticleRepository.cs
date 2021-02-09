using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop.Infrastructure
{
    public class ArticleRepository : IRepository, IDisposable
    {
        private readonly List<Article> _articles = new List<Article> { new Article {ID = 1, ArticleName = "Article1", ArticlePrice = 25 }, new Article { ID = 2, ArticleName = "Article2", ArticlePrice = 22 } };

        public virtual Article GetArticleById(int Id)
        {
            return _articles.SingleOrDefault(x => x.ID == Id);
        }

        public virtual void InsertItem(int id)
        {
            _articles.Add(GetArticleById(id));
        }

        #region Disposing
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _articles.Clear();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
