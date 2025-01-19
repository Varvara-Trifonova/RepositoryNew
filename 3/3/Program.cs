using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите натуральное число n: ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("необходимо ввести натуральное число больше 0");
                Console.ReadKey();
                return;
            }

            int m = 0;
            int result;

            do
            {
                result = m * m * m + m + 1;
                m++;
            } while (result <= n);

            Console.WriteLine($"Наименьшее число вида m^3 + m + 1, которое больше {n}: {result}");
            Console.ReadKey();
        }
    }
}