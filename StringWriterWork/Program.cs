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
            // �������� ������ StringWriter � � ��� �������  
            // ���������� � ������ ��������� ����� ������. 
            StringWriter sw = new StringWriter();

            // ��������� ������ ������ ����� ������.
            sw.Write(sw.NewLine);

            // ��������� ��������� ����� ������.
            sw.WriteLine("������ ������ ������...");
            sw.WriteLine("������ ������ ������...");
            sw.WriteLine("������ ������ �����:");

            // ���������� ������ � ������.
            for (int i = 0; i < 10; i++)           
                sw.Write(i + " ");

            // ����� Close() ������������� ������� ��� ������!
            sw.Close();

            Console.WriteLine("��������� ������ � StringWriter...\n");

            // �������� ����� ����������� StringWriter (� ���� �������� ���� string) 
            // � ������� �� �� �������. 
            Console.WriteLine("����������: {0}", sw.ToString());

            //====================================================================

            // �������� ������ StringBuilder � ������� ��� ����������. 
            StringBuilder sb = sw.GetStringBuilder();

            string str = sb.ToString();
            Console.WriteLine("\nStringBuilder ���������:{0} ", str);

            // ��������� � ����� ����� �������, ������� ������� 20. 
            sb.Insert(20, "INSERTED STUFF");
            str = sb.ToString();
            Console.WriteLine("\nNew StringBuilder ���������:{0}", str);

            // ������� ����������� �������.
            sb.Remove(20, "INSERTED STUFF".Length);
            str = sb.ToString();
            Console.WriteLine("\n������������ ���������:{0}", str);

            //====================================================================

            // ��������� ���������� ��� ������ StringReader.
            StringReader sr = new StringReader(sw.ToString());
            Console.WriteLine("\nStringReader ���������:");

            string input = null;
            while ((input = sr.ReadLine()) != null)
                Console.WriteLine(input);

            // ��������� ������ StringReader.
            sr.Close();

            // ��������.
            Console.ReadKey();
        }
    }
}
