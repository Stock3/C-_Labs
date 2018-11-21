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
            var magazine = new Magazine();
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine();

            Console.WriteLine("Weekly: " + magazine[Data.Frequency.Weekly]);
            Console.WriteLine("Monthly: " + magazine[Data.Frequency.Montly]);
            Console.WriteLine("Yearly: " + magazine[Data.Frequency.Yearly]);
            Console.WriteLine();

            var articles = new[]
            {
                new Article(new Person("Nastya", "Pihur", DateTime.Now), "goalkeeper", 7),
                new Article()
            };
            magazine.Name_of_magazine = "Gool!";
            magazine.Periodicity = Data.Frequency.Weekly;
            magazine.Date_of_issue = DateTime.Now;
            magazine.Printing = 100;
            magazine.List_of_articles = articles;
            Console.WriteLine(magazine.ToString());
            Console.WriteLine();

            magazine.AddArticles(new Article(new Person("Alex", "Stock", DateTime.Now), "forward", 9), new Article());
            Console.WriteLine(magazine.ToString());     

            int row, col;
            Console.Write("Enter a value through a space: ");
            var input = Console.ReadLine().Split();
            row = int.Parse(input[0]);
            col = int.Parse(input[1]);
            var one = new Article[row * col];
            var two = new Article[row, col];
            var jagged = new Article[row][];
            for (var i = 0; i < row; i++)
            {
                jagged[i] = new Article[col];
                for (var j = 0; j < col; j++)
                {
                    one[i * row + j] = new Article();
                    two[i, j] = new Article();
                    jagged[i][j] = new Article();
                }
            }

            var start = Environment.TickCount;
            for(var i = 0; i < row * col; i++)
            {
                one[i].name_of_article = "Real Madrid";
            }
            var ticks = Environment.TickCount - start;
            Console.WriteLine("One-dimensional array: " + ticks);

            start = Environment.TickCount;
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    two[i, j].name_of_article = "Real Madrid";
                }
            }
            ticks = Environment.TickCount - start;
            Console.WriteLine("Two-dimensional rectangular array: " + ticks);

            start = Environment.TickCount;
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    jagged[i][j].name_of_article = "Real Madrid";
                }
            }
            ticks = Environment.TickCount - start;
            Console.WriteLine("Two-dimensional jagged array: " + ticks);
            Console.ReadKey();
        }
    }
}
