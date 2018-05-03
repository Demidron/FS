using System;
using System.IO;

// ��������� ���������� � ����������.

namespace DirectoryInfoWork
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // ������� ������ DirectoryInfo, ����������� �� ���������� - C:\Windows\assembly 
                DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\assembly");

                // ������� ���������� � �������� (����������).
                Console.WriteLine("===== Directory Info =====");
                Console.WriteLine("FullName: {0}", dir.FullName);                // ������ ��� ����������, (������� ����).
                Console.WriteLine("Name: {0}", dir.Name);                        // ��� ����������, (�� ������� ����).
                Console.WriteLine("Parent: {0}", dir.Parent);                    // ������������ ����������. 
                Console.WriteLine("CreationTime: {0}", dir.CreationTime);        // ����� �������� ����������.
                Console.WriteLine("Attributes: {0}", dir.Attributes.ToString()); // ���������.
                Console.WriteLine("Root: {0}", dir.Root);                        // �������� ����, �� ������� ��������� ����������.
                Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);    // ����� ���������� ������� � ����������.
                Console.WriteLine("==========================\n");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }		

            // ��������.
            Console.ReadKey();
        }
    }
}
