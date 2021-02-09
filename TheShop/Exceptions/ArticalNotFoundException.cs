using System;

namespace TheShop.Exceptions
{
    public class ArticalNotFoundException : Exception
    {
        readonly int _id;

        public ArticalNotFoundException(int id) : base()
        {
            _id = id;
        }

        public override string Message => $"Not found article with id: {_id}";
    }
}
