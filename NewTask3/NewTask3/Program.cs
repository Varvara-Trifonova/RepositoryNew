using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите натуральное число m: "); 
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введите натуральное число n: ");
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен 0."); Console.ReadKey();
                return;
            }
            int десятые = (m * 10 / n) % 10;
            int сотые = (m * 100 / n) % 10; int тысячные = (m * 1000 / n) % 10;
            Console.WriteLine($"Десятые: {десятые}");
            Console.WriteLine($"Сотые: {сотые}"); Console.WriteLine($"Тысячные: {тысячные}");
            Console.ReadKey();
        }
    }
}
