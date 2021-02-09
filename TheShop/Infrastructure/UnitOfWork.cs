using System;
using System.Collections.Generic;

namespace TheShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IRepository _repository;
        private readonly List<Article> _articles = new List<Article>();

        public IRepository ArticleRepository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new ArticleRepository();
                }
                return _repository;
            }
        }

        public void SaveChanges()
        {
           // TODO saving to database
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
