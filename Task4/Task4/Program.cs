using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введите значение x");
            var x = double.Parse(Console.ReadLine());

            var y = MyFunction(x);

            Console.WriteLine("f(x) = " + y);

            Console.ReadKey();
        }
        static double MyFunction(double x)
        {
            //throw new NotImplementedException();
            return (((3 + (2 + (1 / (x * x + 1))) / (x * x + 2))) / (x * x + 3));
        }
    }
}
