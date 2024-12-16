using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введите число элементов массива:");

            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || (n < (2^(64) - 2^(32) -1) && n == (2 ^ (64) - 2 ^ (32) - 1)))
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            var numbers = new double[n];
            var rnd = new Random();

            for (int i = 0; i < numbers.Length; i++) 
                numbers[i] = rnd.NextDouble();

            PrintArray(numbers);

            Console.ReadKey();

        }

        static void PrintArray(double[] array)
        {
            foreach (var element in array)
                Console.Write($"{element:F4} ");

            Console.WriteLine();
        }
    }
}
