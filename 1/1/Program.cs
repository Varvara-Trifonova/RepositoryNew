using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите натуральное число n: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("число n должно быть больше или равно 1");
                Console.ReadKey();
                return;
            }

            double[] a = new double[n + 1];

            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Введите a{i}: ");
                a[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Последовательность сумм соседних элементов:");
            for (int i = 0; i < n; i++)
            {
                double sum = a[i] + a[i + 1];
                Console.WriteLine($"a{i} + a{i + 1} = {sum}");
                Console.ReadKey();
            }
        }
    }
}