using System;
using System.IO;
using Lab_1.Classes;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.Write("Input name: ");
            var magazine = new Magazine
            {
                Name_of_edition = Console.ReadLine(),
                Printing = 100
            };
            var copy = magazine.DeepCopy();
            copy.Name_of_edition = "Copy";
            Console.WriteLine("Original: " + magazine);
            Console.WriteLine("Copy: " + copy);

            Console.Write("Enter file name: ");
            var filename = Console.ReadLine();
            var directory = "WrongPath";

            try
            {
                directory = Path.GetDirectoryName(filename);
            }
            catch
            {
                Console.WriteLine("Input is not correct path");
            }
            while (directory == "WrongPath" || !Directory.Exists(directory))
            {
                Console.WriteLine("Directory does not exist");
                Console.Write("Enter file name: ");
                filename = Console.ReadLine();
                try
                {
                    directory = Path.GetDirectoryName(filename);
                }
                catch
                {
                    Console.WriteLine("Input is not correct path");
                }
            }
            if (File.Exists(filename))
            {
                magazine.Load(filename);
            }
            else
            {
                Console.WriteLine("New file will be created");
            }

            magazine.AddFromConsole();
            magazine.Save(filename);
            Console.WriteLine(magazine);

            Magazine.Load(filename, magazine);
            magazine.AddFromConsole();
            Magazine.Save(filename, magazine);
            Console.WriteLine(magazine);

            Console.ReadKey();
        }
    }
}
