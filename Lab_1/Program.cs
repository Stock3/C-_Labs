using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1.Classes;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var time = DateTime.Now;
            var ed_1 = new Edition
            {
                Publication_date_edition = time
            };
            var ed_2 = new Edition
            {
                Publication_date_edition = time
            };
            Console.WriteLine("Equals: " + ed_1.Equals(ed_2));
            Console.WriteLine("Reference: " + ReferenceEquals(ed_1, ed_2));
            Console.WriteLine("HashCode ed_1: " + ed_1.GetHashCode() + ", HashCode ed_2: " + ed_2.GetHashCode());

            Console.WriteLine();
            try
            {
                ed_1.Printing = -3;
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }

            Console.WriteLine();
            var mag = new Magazine();
            mag.Name_of_edition = "Gool!";
            var articles = new Article[]
            {
                new Article
                {
                    name_of_article = "Real Madrid!",
                    rating_of_article = 5
                },
                new Article
                {
                    name_of_article = "Liverpool",
                    rating_of_article = 7
                }
            };
            var editors = new Person[]
            {
                new Person(),
                new Person()
            };
            mag.AddArticles(articles);
            mag.AddEditors(editors);
            Console.WriteLine(mag);

            Console.WriteLine(mag.Edition.ToString());

            var copy = mag.DeepCopy() as Magazine;
            mag.Name_of_edition = "Noooo Goool!";
            Console.WriteLine("+ Original: " + mag.Name_of_edition + ", Copy: " + copy.Name_of_edition);

            Console.WriteLine();
            Console.Write("+ Double counter: ");
            foreach (var a in mag.GetRatings(6))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();
            Console.Write("+ String counter: ");
            foreach (var a in mag.GetArticlesByName("Real Madrid!"))
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
        }
    }
}
