using System;
using System.IO;

namespace StreamReaderWork
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
                sw.Write(i + " ");            

            sw.Write(sw.NewLine);

            // Метод Close() автоматически очищает все буферы!
            sw.Close();

            Console.WriteLine("Файл Text.txt создан и в него записан текст.");

            //=====================================================================

            // А теперь выводим информацию из файла на консоль при помощи StreamReader. 
            Console.WriteLine("Содержимое файла Text.txt:\n");

            StreamReader sr = File.OpenText("Text.txt");

            string input = null;
            while ((input = sr.ReadLine()) != null)            
                Console.WriteLine(input);
           
            sr.Close();
            Console.ReadKey();
        }
    }
}
