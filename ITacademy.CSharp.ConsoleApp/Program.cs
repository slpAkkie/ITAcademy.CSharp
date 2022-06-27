using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITacademy.CSharp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;

            // Read user input until it's not null or an empty string
            while ((line = Console.ReadLine()) != null && line.Length != 0)
            {
                line = "x:" + line.Replace(",", " y:");

                Console.WriteLine(line);
            }

            // Doesn't close the console until the user press a key
            Console.WriteLine("\nPress any key to close...");
            Console.Read();
        }
    }
}
