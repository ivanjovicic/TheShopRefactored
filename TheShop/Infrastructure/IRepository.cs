
namespace TheShop.Infrastructure
{
    public interface IRepository
    {
        Article GetArticleById(int Id);
        void InsertItem(int id);
    }
}
