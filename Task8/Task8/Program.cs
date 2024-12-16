using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            var x = double.Parse(Console.ReadLine());

            Console.WriteLine($"f({x} = {MyFunction(x)}");

            Console.ReadKey();
        }

        static double MyFunction(double x)
        {
            if (x < -2)
                return Math.Pow(Math.Log(x), 2); 
            else if (x > 1)
                return Math.Cos(x);

            return Math.Exp(x);

        }
    }
}

