
namespace TheShop
{
    public abstract class AbstractHandler 
    {
        protected AbstractHandler successor;

        public void SetSuccessor(AbstractHandler successor)
        {
            this.successor = successor;
        }

        public abstract Article HandleRequest(SupplierBase request, int id);
    }
}
