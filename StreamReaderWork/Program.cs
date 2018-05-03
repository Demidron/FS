using System;
using System.IO;

namespace StreamReaderWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // ������� ����.
            FileInfo f = new FileInfo("Text.txt");

            StreamWriter sw = f.CreateText();

            sw.WriteLine("������ ������ ������...");
            sw.WriteLine("������ ������ ������...");
            sw.WriteLine("������ ������ �����:");

            for (int i = 0; i < 10; i++)           
                sw.Write(i + " ");            

            sw.Write(sw.NewLine);

            // ����� Close() ������������� ������� ��� ������!
            sw.Close();

            Console.WriteLine("���� Text.txt ������ � � ���� ������� �����.");

            //=====================================================================

            // � ������ ������� ���������� �� ����� �� ������� ��� ������ StreamReader. 
            Console.WriteLine("���������� ����� Text.txt:\n");

            StreamReader sr = File.OpenText("Text.txt");

            string input = null;
            while ((input = sr.ReadLine()) != null)            
                Console.WriteLine(input);
           
            sr.Close();
            Console.ReadKey();
        }
    }
}
