using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите позицию белого ферзя: ");
            string whitePosition = Console.ReadLine();

            Console.Write("Введите позицию черного коня: ");
            string blackPosition = Console.ReadLine();

            if (!DecodePosition(whitePosition, out int whiteCol, out int whiteRow) ||
                !DecodePosition(blackPosition, out int blackCol, out int blackRow))
            {
                Console.WriteLine("некорректная шахматная нотация");
                Console.ReadKey();
                return;
            }

            if (whiteCol == blackCol && whiteRow == blackRow)
            {
                Console.WriteLine("белый ферзь и черный конь не могут находиться на одной клетке");
                Console.ReadKey();
                return;
            }

            if (IsQueenAttacking(whiteCol, whiteRow, blackCol, blackRow))
            {
                Console.WriteLine("Белый ферзь атакует черного коня. Ход невозможен");
                Console.ReadKey();
                return;
            }

            if (IsKnightAttacking(blackCol, blackRow, whiteCol, whiteRow))
            {
                Console.WriteLine("Черный конь атакует белого ферзя. Ход невозможен");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите позицию предполагаемого хода белого ферзя: ");
            string movePosition = Console.ReadLine();

            if (!DecodePosition(movePosition, out int moveCol, out int moveRow))
            {
                Console.WriteLine("некорректная шахматная нотация для хода");
                Console.ReadKey();
                return;
            }

            bool canMove = CanWhiteQueenMoveSafely(whiteCol, whiteRow, blackCol, blackRow, moveCol, moveRow);

            if (canMove)
            {
                Console.WriteLine("Ход возможен. Белый ферзь может безопасно перейти на указанную клетку");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ход невозможен. Ферзь попадет под удар черного коня.");
                Console.ReadKey();
            }
        }

        static bool DecodePosition(string position, out int col, out int row)
        {
            col = 0;
            row = 0;

            if (position.Length != 2)
            {
                return false;
            }

            char colChar = position[0];
            char rowChar = position[1];

            if (colChar < 'a' || colChar > 'h' || rowChar < '1' || rowChar > '8')
            {
                return false;
            }

            col = colChar - 'a' + 1;
            row = rowChar - '1' + 1;

            return true;
        }

        static bool IsQueenAttacking(int qCol, int qRow, int targetCol, int targetRow)
        {
            return (qCol == targetCol || qRow == targetRow || Math.Abs(qCol - targetCol) == Math.Abs(qRow - targetRow));
        }

        static bool IsKnightAttacking(int kCol, int kRow, int targetCol, int targetRow)
        {
            int colDiff = Math.Abs(kCol - targetCol);
            int rowDiff = Math.Abs(kRow - targetRow);
            return (colDiff == 2 && rowDiff == 1) || (colDiff == 1 && rowDiff == 2);
        }

        static bool CanWhiteQueenMoveSafely(int qCol, int qRow, int kCol, int kRow, int moveCol, int moveRow)
        {
            if (!IsQueenAttacking(qCol, qRow, moveCol, moveRow))
            {
                return false;
            }

            if (IsKnightAttacking(kCol, kRow, moveCol, moveRow))
            {
                return false;
            }

            return true;
        }
    }
}