using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double result = ComputeX();
            Console.WriteLine($"Результат: {result:F3}"); Console.ReadKey();
        }
        static double ReciprocalSum(double a, double b)
        {
            return 1 / (a + b);
        }
        static double ComputeX()
        {
            double sqrt5 = Math.Sqrt(5);
            double inner = ReciprocalSum(3, sqrt5);
            double middle = ReciprocalSum(2, inner);
            double result = ReciprocalSum(1, middle);
            return result;
        }
    }
}
