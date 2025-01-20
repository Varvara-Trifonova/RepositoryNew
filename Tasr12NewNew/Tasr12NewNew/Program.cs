using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12NewNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rand = new Random();

            Console.Write("Введите число m (5 <= m <= 20): ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введите число n (5 <= n <= 20): ");
            int n = int.Parse(Console.ReadLine());

            if (m < 5 || m > 20 || n < 5 || n > 20)
            {
                Console.WriteLine("Одно или оба значения не соответствуют условиям 5 <= m, n <= 20");
                Console.ReadKey();
                return;
            }

            int[,] array = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rand.Next(0, 100);
                }
            }

            Console.WriteLine("Массив:");
            PrintArray(array);

            Console.Write("Введите число для проверки: ");
            int checkNumber = int.Parse(Console.ReadLine());

            if (HasElementGreaterThan(array, checkNumber, out int row, out int col))
            {
                Console.WriteLine($"Найден элемент больше {checkNumber} на позиции: строка {row}, столбец {col}");
            }
            else
            {
                Console.WriteLine($"Элементов больше {checkNumber} в массиве нет");
            }

            double[] averages = ColumnAverages(array);
            Console.WriteLine("Среднее арифметическое для каждого столбца:");
            for (int i = 0; i < averages.Length; i++)
            {
                Console.WriteLine($"Столбец {i}: {averages[i]:F2}");
            }
            Console.ReadKey();
        }
        static void PrintArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{array[i, j],4} ");
                }
                Console.WriteLine();
            }
        }

        static bool HasElementGreaterThan(int[,] array, int number, out int row, out int col)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (row = 0; row < rows; row++)
            {
                for (col = 0; col < cols; col++)
                {
                    if (array[row, col] > number)
                    {
                        return true;
                    }
                }
            }

            row = -1;
            col = -1;
            return false;
        }

        static double[] ColumnAverages(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            double[] averages = new double[cols];

            for (int col = 0; col < cols; col++)
            {
                double sum = 0;
                for (int row = 0; row < rows; row++)
                {
                    sum += array[row, col];
                }
                averages[col] = sum / rows;
            }

            return averages;
        }
    }
}
