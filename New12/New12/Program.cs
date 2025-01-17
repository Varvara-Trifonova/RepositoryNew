using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  supernew12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("Введите целое число m от 5 до 20");
            int m;

            if (!TryInputNumber(out m))
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите целое число n");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }

            if (m < 5 || m > 20 || n < 5 || n > 20)
            {
                Console.WriteLine("Числа не удовлетворяют неравенству 5 <= m,n <= 20");
                Console.ReadKey();
                return;
            }

            var matrix = new int[m, n];
            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(100);

            Console.WriteLine("\nСгенерированная матрица:");
            PrintMatrix(matrix);

            Console.WriteLine("\nВведите число для проверки:");
            if (!TryInputNumber(out int checkNumber))
            {
                Console.ReadKey();
                return;
            }

            CheckNumberInMatrix(matrix, checkNumber);

            Console.WriteLine("\nСреднее арифметическое для каждого столбца:");
            CalculateColumnAverages(matrix);

            Console.ReadKey();
        }

        static bool TryInputNumber(out int number)
        {
            number = 0;
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }

            number = n;
            return true;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3} ");

                Console.WriteLine();
            }
        }

        static void CheckNumberInMatrix(int[,] matrix, int number)
        {
            bool isFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > number)
                    {

                        Console.WriteLine($"Элемент больше заданного числа найден: строка {i + 1}, столбец {j + 1}");
                        isFound = true;
                        return;
                    }
                }
            }

            if (!isFound)
                Console.WriteLine("Элементов больше заданного числа нет.");
        }

        static void CalculateColumnAverages(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                double sum = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                    sum += matrix[i, j];

                double average = sum / matrix.GetLength(0);

                Console.WriteLine($"Столбец {j + 1}: среднее арифметическое = {average:F2}");
            }
        }
    }
}
