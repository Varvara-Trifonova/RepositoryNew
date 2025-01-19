using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите натуральное число: ");
            int number = int.Parse(Console.ReadLine());

            if (number <= 0)
            {
                Console.WriteLine("необходимо ввести натуральное число");
                Console.ReadKey();
                return;
            }

            int firstDigit = number;
            while (firstDigit >= 10)
            {
                firstDigit /= 10;
            }

            int count = 0;
            int temp = number;
            while (temp > 0)
            {
                int currentDigit = temp % 10;
                if (currentDigit == firstDigit)
                {
                    count++;
                }
                temp /= 10;
            }

            Console.WriteLine($"Первая цифра числа: {firstDigit}");
            Console.WriteLine($"Количество раз, когда первая цифра встречается в числе: {count}");
            Console.ReadKey();
        }
    }
}