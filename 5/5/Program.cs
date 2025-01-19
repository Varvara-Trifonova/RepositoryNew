using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите процент увеличения площади посева x (2 <= x <= 10): ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Введите процент увеличения урожайности y (2 <= y <= 10): ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("Введите целевой урожай (в тоннах) n: ");
            double n = double.Parse(Console.ReadLine());

            if (x < 2 || x > 10 || y < 2 || y > 10)
            {
                Console.WriteLine("процент увеличения должен быть в диапазоне от 2 до 10");
                Console.ReadKey();
                return;
            }

            double square = 10.0;
            double productivity = 20.0;
            double total = 0.0;
            int year = 0;

            while (total < n)
            {
                year++;

                double yearlyHarvest = square * productivity / 10.0;
                total += yearlyHarvest;

                Console.WriteLine($"Год {year}: Площадь = {square} га, Урожайность = {productivity} центнеров/га, Урожай за год = {yearlyHarvest} тонн, Общий урожай = {total} тонн");
                Console.ReadKey();

                square *= 1 + x / 100.0;
                productivity *= 1 + y / 100.0;
            }

            Console.WriteLine($"Общий урожай превысит {n} тонн на {year}-й год.");
            Console.ReadKey();
        }
    }
}