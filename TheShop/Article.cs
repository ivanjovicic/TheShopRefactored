using System;

namespace TheShop
{
    public class Article
    {
        public Article()
        {
        }
        public Article(int id, string articleName, int articlePrice)
        {
            ID = id;
            ArticleName =  articleName;
            ArticlePrice = articlePrice;
        }
        public int ID { get; set; }
        public string ArticleName { get; set; }
        public int ArticlePrice { get; set; }
        public bool IsSold { get; set; }
        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }
    }
}
