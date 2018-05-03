using System;
using System.IO;
using System.Text;

// Запись в файл с явным указанием кодировок.

namespace StringBasics
{
    class Program
    {
        static void Main()
        {

            // Записываем файл в кодировке UTF7
            var swUtf7 = new StreamWriter("text.txt", true, Encoding.UTF7);
            swUtf7.WriteLine("Hello, world!");
            swUtf7.Close();

            // Записываем файл в кодировке UTF8
            var swUtf8 = new StreamWriter("text.txt", true, Encoding.UTF8);
            swUtf8.WriteLine("Hello, world!");
            swUtf8.Close();
      
            // Записываем файл в кодировке Unicode
            var swUtf16 = new StreamWriter("text.txt", true, Encoding.Unicode);
            swUtf16.WriteLine("Hello, world!");
            swUtf16.Close();
            var builder = new StringBuilder();
            
            // Записываем файл в кодировке UTF32
            var swUtf32 = new StreamWriter("text.txt", true, Encoding.UTF32);
            swUtf32.WriteLine("Hello, world!");
            swUtf32.Close();
 
            Console.ReadKey();
        }
    }
}