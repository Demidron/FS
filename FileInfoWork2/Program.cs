using System;
using System.IO;

namespace FileInfoWork
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo f = new FileInfo(@"D:\Test.txt");

            // FileMode.OpenOrCreate - ЕСЛИ: существует ТО: открыть ИНАЧЕ: создать новый
            // FileAccess.Read - только для чтения,
            // FileShare.None - Совместный доступ - Нет.
            FileStream fs = f.Open(FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
           
            Console.WriteLine("CreationTime {0}", f.CreationTime);
            Console.WriteLine("Full Name: {0}", f.FullName);
            Console.WriteLine("Attributes {0}", f.Attributes.ToString());

            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();

            fs.Close();
            f.Delete();
            Console.ReadKey(); 
        }
    }
}
