using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите число k (2 <= k <= 9): ");
            int k = int.Parse(Console.ReadLine());

            if (k < 2 || k > 9)
            {
                Console.WriteLine("число должно быть в диапазоне от 2 до 9");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Таблица умножения на {k}:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{k} * {i} = {k * i}");
                Console.ReadKey();
            }
        }
    }
}