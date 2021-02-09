
namespace TheShop
{
    public class SupplierTwo : SupplierBase
    {
        public override bool ArticleInInventory(int id)
        {
            return false;
        }

        public override Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                ArticleName = "Article from supplier2",
                ArticlePrice = 459
            };
        }
    }
}
