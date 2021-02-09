using System;
using System.Collections.Generic;
using TheShop.Exceptions;
using TheShop.Infrastructure;
using TheShop.Log;

namespace TheShop
{
    public class ShopService    
    {
        #region private fields
        private readonly ILogger logger;
        private readonly IList<SupplierBase> _allSuppliers;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region constructor
        public ShopService()
		{
			logger = new Logger();
            SupplierBase _supplierOne = new SupplierOne();
            SupplierBase _supplierTwo = new SupplierTwo();
            SupplierBase _supplierThree = new SupplierThree();
            _allSuppliers = new List<SupplierBase> { _supplierOne, _supplierTwo, _supplierThree };
            _unitOfWork = new UnitOfWork();
        }
        #endregion

        #region selling article
        public void SellArticle(Article article, int buyerId)
		{
			logger.Debug("Trying to sell article with id=" + article.ID);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;
			
			try
			{
                _unitOfWork.ArticleRepository.InsertItem(article.ID);
                _unitOfWork.SaveChanges();
				logger.Info("Article with id=" + article.ID + " is sold.");
			}
			catch (ArgumentNullException anex)
			{
				logger.Error("Could not save article with id=" + article.ID);
				throw new NotSavedArticleException(anex.Message);
			}
			catch (Exception ex)
			{
                logger.Error($"Article with id={article.ID} not saved, exception:{ex.Message} ");
            }
		}
        #endregion

        #region ordering article
        public Article OrderArticle(int articleId, int maxExpectedPrice)
        {
            AbstractHandler supplierOneHandler = new SupplierOneHandler();
            AbstractHandler supplierTwoHandler = new SupplierTwoHandler();
            AbstractHandler supplierThreeHandler = new SupplierThreeHandler();

            supplierOneHandler.SetSuccessor(supplierTwoHandler);
            supplierTwoHandler.SetSuccessor(supplierThreeHandler);

            foreach (var supplier in _allSuppliers)
            {
                var article = supplierOneHandler.HandleRequest(supplier, articleId);
                if (article != null)
                {
                    return article;
                }
            }

            throw new ArticalNotFoundException(articleId);
        }
        #endregion
    }
}
