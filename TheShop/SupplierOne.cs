
namespace TheShop
{
    public class SupplierOne : SupplierBase
    {
        public override bool ArticleInInventory(int id)
        {
            return true;
        }

        public override Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                ArticleName = "Article from supplier1",
                ArticlePrice = 458
            };
        }
    }
}
