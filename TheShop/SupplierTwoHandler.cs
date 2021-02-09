using TheShop.Exceptions;

namespace TheShop
{
    public class SupplierTwoHandler : AbstractHandler
    {
        public override Article HandleRequest(SupplierBase request, int id)
        {
            if (request.ArticleInInventory(id))
            {
                request.GetArticle(id);
            }
            else if (successor != null)
            {
                return successor.HandleRequest(request, id);
            }

            throw new ArticalNotFoundException(id);
        }
    }
}
