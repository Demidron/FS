using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace StringWriterWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем объект StringWriter и с его помощью  
            // записываем в память несколько строк текста. 
            StringWriter sw = new StringWriter();

            // Вставляем символ начала новой строки.
            sw.Write(sw.NewLine);

            // Вставляем несколько строк текста.
            sw.WriteLine("Первая строка текста...");
            sw.WriteLine("Вторая строка текста...");
            sw.WriteLine("Третья строка чисел:");

            // Записываем строки в память.
            for (int i = 0; i < 10; i++)           
                sw.Write(i + " ");

            // Метод Close() автоматически очищает все буферы!
            sw.Close();

            Console.WriteLine("Сохранили строки в StringWriter...\n");

            // Получаем копию содержимого StringWriter (в виде значения типа string) 
            // и выводим ее на консоль. 
            Console.WriteLine("Содержимое: {0}", sw.ToString());

            //====================================================================

            // Получаем объект StringBuilder и выводим его содержимое. 
            StringBuilder sb = sw.GetStringBuilder();

            string str = sb.ToString();
            Console.WriteLine("\nStringBuilder сообщение:{0} ", str);

            // Вставляем в буфер новый элемент, позиция вставки 20. 
            sb.Insert(20, "INSERTED STUFF");
            str = sb.ToString();
            Console.WriteLine("\nNew StringBuilder сообщение:{0}", str);

            // Удаляем вставленный элемент.
            sb.Remove(20, "INSERTED STUFF".Length);
            str = sb.ToString();
            Console.WriteLine("\nОригинальное сообщение:{0}", str);

            //====================================================================

            // Считываем информацию при помощи StringReader.
            StringReader sr = new StringReader(sw.ToString());
            Console.WriteLine("\nStringReader сообщение:");

            string input = null;
            while ((input = sr.ReadLine()) != null)
                Console.WriteLine(input);

            // Закрываем объект StringReader.
            sr.Close();

            // Задержка.
            Console.ReadKey();
        }
    }
}
