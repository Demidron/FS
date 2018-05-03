using System;
using System.IO;

namespace FileInfoWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем новый файл в корневом каталоге диска D:
            FileInfo f = new FileInfo(@"D:\Test.txt");

          FileStream fs = f.Create();
           
            // Выводим основную информацию о созданном нами файле.
            Console.WriteLine("CreationTime {0}", f.CreationTime);
            Console.WriteLine("Full Name: {0}", f.FullName);
            Console.WriteLine("Attributes {0}", f.Attributes.ToString());

            Console.WriteLine("Нажмите любую клавишу для удаления файла.");
            Console.ReadKey();

           fs.Close();
            f.Delete();
            Console.ReadKey();
        }
    }
}
