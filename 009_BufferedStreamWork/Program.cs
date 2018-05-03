using System;
using System.IO;

namespace BufferedStreamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // ������� ������ MemoryStream ����� ������������� ������.
            MemoryStream ms = new MemoryStream(256);

            for (int i = 0; i < 256; i++)
                ms.WriteByte((byte)i);

            ms.Position = 0;

            for (int i = 0; i < 256; i++)
                Console.Write(ms.ReadByte());

            Console.WriteLine("\n");

            //=====================================================================================

            // ���������� ������ �� MemoryStream � ����.
            FileStream fs = new FileStream("Dump.dat", FileMode.Create, FileAccess.ReadWrite);
            ms.WriteTo(fs);

            //=====================================================================================

            // ������� ������ BufferedStream � ���������� FileStream.  
            BufferedStream bs = new BufferedStream(fs);

            // ��������� � BufferedStream ��������� ����.
            byte[] array = { 127, 0x77, 0x4, 0x0, 0x0, 0x16 };
            bs.Write(array, 0, array.Length);

            // ��� �������� BufferedStream bs - ������ ������� � ����.
            bs.Close();
            fs.Close();
            ms.Close();

            // ��������.
            Console.ReadKey();
        }
    }
}
