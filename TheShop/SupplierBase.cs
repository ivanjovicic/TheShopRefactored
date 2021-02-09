namespace TheShop
{
    public abstract class SupplierBase
    {
      public abstract bool ArticleInInventory(int id);
      public abstract Article GetArticle(int id);
    }
}