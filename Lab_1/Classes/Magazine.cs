using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Classes;

namespace Lab_1.Classes
{
    public class Magazine
    {
        private string name_of_magazine;
        private Data.Frequency periodicity;
        private DateTime date_of_issue;
        private int printing;
        private Article[] list_of_articles;


        public Magazine(string name_of_magazine, Data.Frequency periodicity, DateTime date_of_issue, int printing, Article[] list_of_articles)
        {
            this.name_of_magazine = name_of_magazine;
            this.periodicity = periodicity;
            this.date_of_issue = date_of_issue;
            this.printing = printing;
            this.list_of_articles = list_of_articles;
        }

        public Magazine()
        {
            this.name_of_magazine = "";
            this.periodicity = Data.Frequency.Montly;
            this.date_of_issue = DateTime.Now;
            this.printing = 0;
            this.list_of_articles = new Article[0];
        }

        public string Name_of_magazine
        {
            get => name_of_magazine;
            set => name_of_magazine = value;
        }
        public Data.Frequency Periodicity
        {
            get => periodicity;
            set => periodicity = value;
        }
        public DateTime Date_of_issue
        {
            get => date_of_issue;
            set => date_of_issue = value;
        }
        public int Printing
        {
            get => printing;
            set => printing = value;
        }
        public Article[] List_of_articles
        {
            get => list_of_articles;
            set => list_of_articles = value;
        }

        public double MediumRating
        {
            get
            {
                if (list_of_articles.Length == 0)
                    return 0;
                return list_of_articles.Average(a => a.rating_of_article);
            }
        }

        public bool this[Data.Frequency frequency] => periodicity == frequency;

        public void AddArticles(params Article[] list_of_articles)
        {
            var size = list_of_articles.Length;
            Array.Resize(ref this.list_of_articles, size + list_of_articles.Length);
            Array.Copy(list_of_articles, 0, this.list_of_articles, size, list_of_articles.Length);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var article in list_of_articles)
            {
                sb.Append("Article: " + article + "\n\n");
            }
            return "Name of magazine: " + name_of_magazine + "\nPeriodicity: " + periodicity + "\nDate of issue: " + date_of_issue +
                "\nPrinting of magazine: " + printing + "\nList of article:\n" + sb;
        }

        public virtual string ToShortString()
        {
            return "Name of magazine: " + name_of_magazine + "\nPeriodicity: " + periodicity + "\nDate of issue: " + date_of_issue +
                "\nPrinting of magazine: " + printing + "\nMedium rating: " + MediumRating;
        }
    }
}
