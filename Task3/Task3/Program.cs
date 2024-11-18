using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите натуральное число m: ");
            if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
            {
                Console.WriteLine("Ошибка: введите натуральное число для m.");
                return;
            }

            Console.Write("Введите натуральное число n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Ошибка: введите натуральное число для n.");
                return;
            }

            if (n == 0)
            {
                Console.WriteLine("Деление на ноль невозможно.");
                return;
            }

            double fraction = (double)m / n;

            string fractionString = fraction.ToString("0.000");

            int tenths = 0, hundredths = 0, thousandths = 0;

            if (fractionString.Contains('.'))
            {
                string[] parts = fractionString.Split('.');
                string decimalPart = parts[1];

                tenths = decimalPart.Length >= 1 && decimalPart[0] != '0' ? 1 : 0;
                hundredths = decimalPart.Length >= 2 && decimalPart[1] != '0' ? 1 : 0;
                thousandths = decimalPart.Length >= 3 && decimalPart[2] != '0' ? 1 : 0;
            }

            Console.WriteLine($"Количество десятых: {(fractionString[2] != '0' ? 1 : 0)}");
            Console.WriteLine($"Количество сотых: {(fractionString[3] != '0' ? 1 : 0)}");
            Console.WriteLine($"Количество тысячных: {(fractionString[4] != '0' ? 1 : 0)}");

            Console.ReadKey();
        }
    }
}
