using System;
using System.IO;

// ПОЛУЧЕНИЕ ИНФОРМАЦИИ О ДИРЕКТОРИИ.

namespace DirectoryInfoWork
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создаем объект DirectoryInfo, ссылающийся на директорию - C:\Windows\assembly 
                DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\assembly");

                // Выводим информацию о каталоге (Директории).
                Console.WriteLine("===== Directory Info =====");
                Console.WriteLine("FullName: {0}", dir.FullName);                // Полное Имя директории, (включая путь).
                Console.WriteLine("Name: {0}", dir.Name);                        // Имя директории, (НЕ включая путь).
                Console.WriteLine("Parent: {0}", dir.Parent);                    // Родительская директория. 
                Console.WriteLine("CreationTime: {0}", dir.CreationTime);        // Время создания директории.
                Console.WriteLine("Attributes: {0}", dir.Attributes.ToString()); // Аттрибуты.
                Console.WriteLine("Root: {0}", dir.Root);                        // Корневой диск, на котором находится директория.
                Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);    // Время последнего доступа к директории.
                Console.WriteLine("==========================\n");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }		

            // Задержка.
            Console.ReadKey();
        }
    }
}
