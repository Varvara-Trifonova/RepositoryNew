using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Life");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Rapidly, merrily,");
            Console.WriteLine("Life’s sunny hours flit by,");
            Console.WriteLine("Gratefully, cheerily, ha");
            Console.WriteLine("Enjoy them as they fly!");

            Console.ResetColor();


            Console.ReadKey();
        }
    }
}