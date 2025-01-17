using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введите целое положительное число n:");
            if (!long.TryParse(Console.ReadLine(), out long n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            var digits = GetDigitsReversed(n);
            PrintArray(digits);

            Console.WriteLine("Введите значение k:");
            if (!int.TryParse(Console.ReadLine(), out int k))
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            ModifyArray(ref digits, k);
            PrintArray(digits);

            int sumModule10 = GetSumModule10(digits);
            Console.WriteLine($"Сумма элементов массива по модулю 10: {sumModule10}");

            var swappedArray = SwapAdjacentElements(digits);
            Console.WriteLine("Массив после обмена соседних элементов:");
            PrintArray(swappedArray);

            Console.ReadKey();
        }

        static int[] GetDigitsReversed(long number)
        {
            var digits = new List<int>();
            while (number > 0)
            {
                digits.Add((int)(number % 10));
                number /= 10;
            }
            return digits.ToArray();
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(";", array));
            Console.WriteLine();
        }
        static void ModifyArray(ref int[] array, int k)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (array[i] + k) % 10;
            }
        }

        static int GetSumModule10(int[] array)
        {
            int sum = 0;
            foreach (var element in array)
            {
                sum = (sum + element) % 10;
            }
            return sum;
        }
        static int[] SwapAdjacentElements(int[] array)
        {
            int[] result = (int[])array.Clone();
            for (int i = 0; i < result.Length - 1; i += 2)
            {
                int temp = result[i];
                result[i] = result[i + 1];
                result[i + 1] = temp;
            }
            return result;
        }
    }
}