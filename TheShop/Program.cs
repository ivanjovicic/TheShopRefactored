using System;
using TheShop.Exceptions;
using TheShop.Infrastructure;

namespace TheShop
{
	internal class Program
	{
        const int articleId1 = 1;
        const int articleId12 = 12;
        const int maxExpectedPrice = 20;
        const int buyerId = 20;

        private static void Main(string[] args)
		{
            var shopService = new ShopService();
            Article article = null;
            IUnitOfWork unitOfWork;
            try
            {
                //order and sell
                article = shopService.OrderArticle(articleId1, maxExpectedPrice);
                shopService.SellArticle(article, buyerId);
            }
            catch(ArticalNotFoundException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(NotSavedArticleException nsae)
            {
                Console.WriteLine(nsae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
			{
                unitOfWork = new UnitOfWork();
                article = unitOfWork.ArticleRepository.GetArticleById(articleId1);
                //print article on console
                Console.WriteLine("Found article with ID: " + article.ID);
			}
            catch (ArticalNotFoundException anfex)
            {
                Console.WriteLine($"Article with id:{articleId1} not found");
            }
            catch (Exception ex)
			{
                Console.WriteLine($"Article with id:{articleId1} not found");
            }

			try
			{
                unitOfWork = new UnitOfWork();
                article = unitOfWork.ArticleRepository.GetArticleById(articleId12);
                //print article on console
                Console.WriteLine("Found article with ID: " + article.ID);
            }
			catch (Exception ex)
			{
				Console.WriteLine($"Article with id:{articleId12} not found");
			}

			Console.ReadKey();
		}
	}
}