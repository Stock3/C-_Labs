using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Classes;

namespace Lab_1.Classes
{
    public class Article
    {
        public Person author { get; set; }
        public string name_of_article { get; set; }
        public double rating_of_article { get; set; }

        public Article(Person author, string name_of_article, double rating_of_article)
        {
            this.author = author;
            this.name_of_article = name_of_article;
            this.rating_of_article = rating_of_article;
        }

        public Article()
        {
            this.author = new Person();
            this.name_of_article = "";
            this.rating_of_article = 0;
        }

        public override string ToString()
        {
            return "\nDate of author: " + author.ToString() + "\nArticle title: " + name_of_article + "\nRating of article: " + rating_of_article;
        }
    }
}
