using NUnit.Framework;
using TheShop;

namespace UnitTestProject
{
    [TestFixture]
    public class ShopServiceTests
    {
        [Test]
        public void OrderArticleThrowsNotSavedException()
        {
            var shopService = new ShopService();
            Assert.DoesNotThrow(() => shopService.OrderArticle(12, 24));
        }

        [Test]
        public void OrderArticleReturnsObject()
        {
           var shopService = new ShopService();
           Assert.IsNotNull(shopService.OrderArticle(12, 24));
        }
    }
}
