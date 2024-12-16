using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string word = "саксофон";


            string word1 = word.Substring(7, 1) + word.Substring(6, 1) + word.Substring(3, 2) + word.Substring(2, 1);


            string word2 = word.Substring(5, 1) + word.Substring(1, 1) + word.Substring(3, 2) + word.Substring(7, 1);

            Console.WriteLine("Первое слово: " + word1);
            Console.WriteLine("Второе слово: " + word2);
        }
    }
}
