using System;
using System.IO;

// ������ � ��������� ����

namespace StreamWriterWork
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
            {
                sw.Write(i + " ");
            }

            sw.Write(sw.NewLine);

            sw.Close();

            Console.WriteLine("���� Text.txt ������ � � ���� ������� �����.");

            Console.ReadKey();
        }
    }
}
