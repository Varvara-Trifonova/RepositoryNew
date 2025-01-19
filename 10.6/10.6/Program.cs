using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите сумму сдачи (n < 100): ");
            int n = int.Parse(Console.ReadLine());

            if (n <= 0 || n >= 100)
            {
                Console.WriteLine("сумма сдачи должна быть положительной и меньше 100");
                Console.ReadKey();
                return;
            }

            int count = 0;

            for (int coins10 = 0; coins10 <= n / 10; coins10++)
            {
                for (int coins5 = 0; coins5 <= (n - coins10 * 10) / 5; coins5++)
                {
                    for (int coins2 = 0; coins2 <= (n - coins10 * 10 - coins5 * 5) / 2; coins2++)
                    {
                        int coins1 = n - coins10 * 10 - coins5 * 5 - coins2 * 2;
                        count++;
                        Console.WriteLine($"{coins10} монет(ы) по 10 руб, {coins5} монет(ы) по 5 руб, {coins2} монет(ы) по 2 руб, {coins1} монет(ы) по 1 руб");

                    }
                }
            }

            Console.WriteLine($"\nОбщее количество способов выдачи сдачи: {count}");
            Console.ReadKey();
        }
    }
}
