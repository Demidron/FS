using System;
using System.IO;

namespace FileStreamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("Test.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            for (int i = 0; i < 256; i++)
                fs.WriteByte((byte)i);

            fs.Position = 0;

            for (int i = 0; i < 256; i++)
                Console.Write(" " + fs.ReadByte());

            fs.Close();

            Console.ReadKey();
        }
    }
}
