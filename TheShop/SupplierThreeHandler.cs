
using TheShop.Exceptions;

namespace TheShop
{
    public class SupplierThreeHandler : AbstractHandler
    {
        public override Article HandleRequest(SupplierBase request, int id)
        {
            if (request.ArticleInInventory(id))
            {
               return request.GetArticle(id);
            }
            else if (successor != null)
            {
                return successor.HandleRequest(request, id);
            }
            throw new ArticalNotFoundException(id);
        }
    }
}
