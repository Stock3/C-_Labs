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
            var coll_1 = new MagazineCollection
            {
                name_of_collection = "PSG"
            };
            var coll_2 = new MagazineCollection
            {
                name_of_collection = "Liverpool"
            };

            var lis_1 = new Listener();
            var lis_2 = new Listener();
            coll_1.AddDefaults();
            coll_2.AddDefaults();

            coll_1.MagazineAdded += lis_1.Handler;
            coll_1.MagazineReplaced += lis_1.Handler;

            coll_2.MagazineAdded += lis_2.Handler;
            coll_2.MagazineReplaced += lis_2.Handler;

            coll_1.AddMagazines(new Magazine());
            coll_1[3] = new Magazine();
            coll_1.Replace(4, new Magazine());
            coll_1.AddMagazines(new Magazine());

            coll_2[1] = new Magazine();
            coll_2.Replace(0, new Magazine());
            coll_2.AddMagazines(new Magazine());
            coll_2[2] = new Magazine();

            Console.WriteLine(lis_1);
            Console.WriteLine();
            Console.WriteLine(lis_2);

            Console.ReadKey();
        }
    }
}
