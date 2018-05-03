using System;
using System.IO;

namespace DirectoryInfoWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // ��� ���������� �����.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("��������� �����:");

            foreach (string s in drives)
                Console.WriteLine("-> {0}", s);


            // ������� ������ DirectoryInfo, ��������������� D:\TESTDIR. 
            DirectoryInfo dir = new DirectoryInfo(@"D:\TESTDIR");
            if(dir.Exists)
                dir.Create();

            dir.CreateSubdirectory("SUBDIR");
            dir.CreateSubdirectory(@"MyDir\MyDir2");

            Console.WriteLine("���������� �������.");   

            // ������� ��������.
            Console.Write("��������� �������:\n->" + dir.FullName +
                          "\\MyDir\\MyDir2\n->" + dir.FullName +
                          "\\SUBDIR\n" + "������� Enter ��� �����������!");
            Console.Read();

            try
            {
                Directory.Delete(@"D:\TESTDIR\SUBDIR");

                // �������������� ������ �������� ����������, ����� �� ������� �����
                // � ��� ��������� �����������. 
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
