using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06.1
{
    internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введите текст на русском языке: ");
        var text = Console.ReadLine();
        Console.WriteLine(Translate(text));

        Console.ReadKey();
    }

    static string Translate(string s)
    {
        return s.ToUpper()
       .Replace("А", "A")
       .Replace("Б", "б")
       .Replace("В", "B")
       .Replace("Г", "r")
       .Replace("Д", "D")
       .Replace("E", "E")
       .Replace("Ж", "}|{")
       .Replace("З", "З")
       .Replace("И", "u")
       .Replace("Й", "u*")
       .Replace("K", "K")
       .Replace("Л", "JI")
       .Replace("М", "M")
       .Replace("Н", "H")
       .Replace("О", "O")
       .Replace("П", "n")
       .Replace("Р", "P")
       .Replace("С", "C")
       .Replace("Т", "T")
       .Replace("У", "Y")
       .Replace("Ф", "cp")
       .Replace("Х", "X")
       .Replace("Ц", "L|")
       .Replace("Ч", "4")
       .Replace("Ш", "LLI")
       .Replace("Щ", "LLL")
       .Replace("Ъ", "'b")
       .Replace("Ы", "bI")
       .Replace("Ь", "b")
       .Replace("Э", "-)")
       .Replace("Ю", "IO")
       .Replace("Я", "9I");
    }
}
}
