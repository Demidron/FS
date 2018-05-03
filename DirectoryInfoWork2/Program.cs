using System;
using System.IO;

namespace DirectoryInfoWork
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создаем объект DirectoryInfo, ссылающийся на D:\TESTDIR.
                DirectoryInfo dir = new DirectoryInfo(@"D:\Demi");

                // Выводим информацию о каталоге.
                Console.WriteLine("===== Directory Info =====");
                Console.WriteLine("FullName: {0}", dir.FullName);
                Console.WriteLine("Name: {0}", dir.Name);
                Console.WriteLine("Parent: {0}", dir.Parent);
                Console.WriteLine("CreationTime: {0}", dir.CreationTime);
                Console.WriteLine("Attributes: {0}", dir.Attributes.ToString());
                Console.WriteLine("Root: {0}", dir.Root);
                Console.WriteLine("==========================\n");



               FileInfo[] bitmapFiles = dir.GetFiles("*.txt*");
                DirectoryInfo[] bitmapDir = dir.GetDirectories();
                Console.WriteLine("Found {0} *.bmp files\n", bitmapFiles.Length);

                //foreach (FileInfo f in bitmapFiles)
                //{
                //    Console.WriteLine("==========================\n");
                //    Console.WriteLine("File name: {0}", f.Name);
                //    Console.WriteLine("File size: {0}", f.Length);
                //    Console.WriteLine("Creation: {0}", f.CreationTime);
                //    Console.WriteLine("Attributes: {0}", f.Attributes.ToString());
                //    Console.WriteLine("==========================\n");
                //}
                foreach (DirectoryInfo f in bitmapDir)
                {
                    Console.WriteLine("==========================\n");
                    Console.WriteLine("File name: {0}", f.Name);
         
                    Console.WriteLine("Creation: {0}", f.CreationTime);
                    Console.WriteLine("Attributes: {0}", f.Attributes.ToString());
                  
                   Console.WriteLine("==========================\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }		

            Console.ReadKey();
        }
    }
}
