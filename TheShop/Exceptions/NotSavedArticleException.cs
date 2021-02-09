using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Exceptions
{
    public class NotSavedArticleException : Exception
    {
        public NotSavedArticleException(string message): base(message)
        {
        }
    }
}
