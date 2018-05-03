using System;
using System.IO;

// ЗАПИСЬ В ТЕКСТОВЫЙ ФАЙЛ

namespace StreamWriterWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем файл.
            FileInfo f = new FileInfo("Text.txt");

            StreamWriter sw = f.CreateText();

            sw.WriteLine("Первая строка текста...");
            sw.WriteLine("Вторая строка текста...");
            sw.WriteLine("Третья строка чисел:");

            for (int i = 0; i < 10; i++) 
            {
                sw.Write(i + " ");
            }

            sw.Write(sw.NewLine);

            sw.Close();

            Console.WriteLine("Файл Text.txt создан и в него записан текст.");

            Console.ReadKey();
        }
    }
}
