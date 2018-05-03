using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Drawing; 

namespace BitMapWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // ��������� ���� ����������� � �������� ����������
            Console.WriteLine("��������� bitmap � ������");
            FileStream fs = new FileStream("Picture.bmp", FileMode.Open, FileAccess.ReadWrite);

            // ������� ������ Bitmap �� ������ ��������� ������
            Bitmap bitmap = new Bitmap(fs);

            // ������ ����-������� ����� ������� ����������� (������ ��� �������� ���� � ��� ������, 
            // ���� ������ � ������ ����������� ���������) 
            for (int i = 0; i < bitmap.Width; i++)
            {
                bitmap.SetPixel(i, i, Color.White);
                bitmap.SetPixel((bitmap.Width - i) - 1, i, Color.Red);                
            }

            // ��������� ���������� ����������� � ��������� ����
            bitmap.Save("NewImage.bmp");
            fs.Close();
        }
    }
}
