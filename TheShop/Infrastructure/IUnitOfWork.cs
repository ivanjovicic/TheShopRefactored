
namespace TheShop.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository ArticleRepository { get; }
        void SaveChanges();
    }
}
