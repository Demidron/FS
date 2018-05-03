using System;
using System.IO;

namespace DirectoryInfoWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // все логические диски.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Имеющиеся диски:");

            foreach (string s in drives)
                Console.WriteLine("-> {0}", s);


            // Создаем объект DirectoryInfo, соответствующий D:\TESTDIR. 
            DirectoryInfo dir = new DirectoryInfo(@"D:\TESTDIR");
            if(dir.Exists)
                dir.Create();

            dir.CreateSubdirectory("SUBDIR");
            dir.CreateSubdirectory(@"MyDir\MyDir2");

            Console.WriteLine("Директории созданы.");   

            // Удаляем каталоги.
            Console.Write("Готовимся удалять:\n->" + dir.FullName +
                          "\\MyDir\\MyDir2\n->" + dir.FullName +
                          "\\SUBDIR\n" + "Нажмите Enter для продолжения!");
            Console.Read();

            try
            {
                Directory.Delete(@"D:\TESTDIR\SUBDIR");

                // Необязательный второй параметр определяет, будут ли удалены также
                // и все вложенные подкаталоги. 
                Directory.Delete(@"D:\TESTDIR\MyDir", true);
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
