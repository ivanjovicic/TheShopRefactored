
namespace TheShop
{
    public class SupplierThree : SupplierBase
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
                ArticleName = "Article from supplier3",
                ArticlePrice = 460
            };
        }
    }
}
