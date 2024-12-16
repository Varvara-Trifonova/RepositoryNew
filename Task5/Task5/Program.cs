using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                var x = F(1, 2);

                Console.WriteLine($"x = {x:F3}");
                Console.ReadKey();
            }
            static double F(double a, double b)
            {
                return (a / (a + (a / (b + (a / (a / (a + b) + Math.Sqrt(a + 2 * b)))))));            }
        }
    }
}
  