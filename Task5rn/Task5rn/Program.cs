using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = F(1, 1) + F(1, 2) + F(5, 3);

            Console.WriteLine($"x = {x:F3}");
            Console.ReadKey();
        }
        static double F(double a, double b)
        {
            return (1 /( b + (a / (b + (a / (b + Math.Sqrt(a)))))));
        }
    }
}