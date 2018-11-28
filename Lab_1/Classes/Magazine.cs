using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Classes;
using Lab_1.Interfaces;

namespace Lab_1.Classes
{
    public class Magazine: Edition, IRateAndCopy
    { 
        private Data.Frequency periodicity;
        private ArrayList list_of_articles;
        public ArrayList Editors { get; set; }

        public Magazine(string name_of_edition, Data.Frequency periodicity, DateTime publication_date_edition, int printing, ArrayList Articles, ArrayList Editors): base(name_of_edition, publication_date_edition, printing)
        {
            this.list_of_articles = Articles;
            this.Editors = Editors;
        }

        public Magazine():base()
        {
            this.list_of_articles = new ArrayList();
            this.Editors = new ArrayList();
        }

        public Data.Frequency Periodicity
        {
            get => periodicity;
            set => periodicity = value;
        }
        public ArrayList Articles1
        {
            get => list_of_articles;
            set => list_of_articles = value;
        }
        
        public double MediumRating
        {
            get
            {
                if (list_of_articles.Count == 0)
                    return 0;
                var sum = .0;
                foreach(var article in list_of_articles)
                {
                    sum += ((Article)article).rating_of_article;
                }
                return sum / list_of_articles.Count;
            }
        }
        public double rating_of_article => MediumRating;
        public bool this[Data.Frequency frequency] => periodicity == frequency;

        public void AddArticles(params Article[] articles)
        {
            this.list_of_articles.AddRange(articles);
        }
        public void AddEditors(params Person[] editors)
        {
            Editors.AddRange(editors);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var article in list_of_articles)
            {
                sb.Append("Article: " + article + "\n\n");
            }
            return "Name of magazine: " + name_of_edition + "\nPeriodicity: " + periodicity + "\nDate of issue: " + publication_date_edition +
                "\nPrinting of magazine: " + printing + "\nList of article:\n" + sb;
        }

        public virtual string ToShortString()
        {
            return "Name of magazine: " + name_of_edition + "\nPeriodicity: " + periodicity + "\nDate of issue: " + publication_date_edition +
                "\nPrinting of magazine: " + printing + "\nMedium rating: " + MediumRating;
        }

        public override bool Equals(object obj)
        {
            var magazine = obj as Magazine;
            if (ReferenceEquals(magazine, null))
            {
                return false;
            }
            return name_of_edition == magazine.name_of_edition &&
                    periodicity == magazine.periodicity &&
                    printing == magazine.printing &&
                    publication_date_edition == magazine.publication_date_edition;
        }
        public static bool operator ==(Magazine m1, Magazine m2)
        {
            return EqualityComparer<Magazine>.Default.Equals(m1, m2);
        }
        public static bool operator !=(Magazine m1, Magazine m2)
        {
            return !(m1 == m2);
        }
        public override int GetHashCode()
        {
            var hashCode = -703031920;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Data.Frequency>.Default.GetHashCode(periodicity);
            hashCode = hashCode * -1521134295 + EqualityComparer<ArrayList>.Default.GetHashCode(list_of_articles);
            hashCode = hashCode * -1521134295 + EqualityComparer<ArrayList>.Default.GetHashCode(Editors);
            return hashCode;
        }

        public Edition Edition
        {
            get => this;
            set
            {
                Name_of_edition = value.Name_of_edition;
                Printing = value.Printing;
                Publication_date_edition = value.Publication_date_edition;
            }
        }

        public override object DeepCopy()
        {
            var res = new Magazine(name_of_edition, periodicity, publication_date_edition, printing, new ArrayList(list_of_articles.Count), new ArrayList(Editors.Count));
            foreach (var o in list_of_articles)
            {
                var a = o as Article;
                res.list_of_articles.Add(a.DeepCopy());
            }
            var editors = new ArrayList(Editors.Count);
            foreach (var o in Editors)
            {
                var e = o as Person;
                editors.Add(e.DeepCopy());
            }
            res.Editors = editors;
            return res;
        }
        public IEnumerable<Article> GetRatings(double minRating)
        {
            foreach (var o in list_of_articles)
            {
                var article = o as Article;
                if (article == null || article.rating_of_article < minRating)
                {
                    continue;
                }
                yield return article;
            }
        }
        public IEnumerable<Article> GetArticlesByName(string name)
        {
            foreach (var o in list_of_articles)
            {
                var article = o as Article;
                if (article == null || !article.name_of_article.Contains(name))
                {
                    continue;
                }
                yield return article;
            }
        }
    }
}
