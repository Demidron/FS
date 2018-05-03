using System;
using System.IO;

namespace BufferedStreamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект MemoryStream точно определенного объема.
            MemoryStream ms = new MemoryStream(256);

            for (int i = 0; i < 256; i++)
                ms.WriteByte((byte)i);

            ms.Position = 0;

            for (int i = 0; i < 256; i++)
                Console.Write(ms.ReadByte());

            Console.WriteLine("\n");

            //=====================================================================================

            // Сбрасываем данные из MemoryStream в файл.
            FileStream fs = new FileStream("Dump.dat", FileMode.Create, FileAccess.ReadWrite);
            ms.WriteTo(fs);

            //=====================================================================================

            // Создаем объект BufferedStream и подключаем FileStream.  
            BufferedStream bs = new BufferedStream(fs);

            // Добавляем в BufferedStream несколько байт.
            byte[] array = { 127, 0x77, 0x4, 0x0, 0x0, 0x16 };
            bs.Write(array, 0, array.Length);

            // При закрытии BufferedStream bs - данные пишутся в файл.
            bs.Close();
            fs.Close();
            ms.Close();

            // Задержка.
            Console.ReadKey();
        }
    }
}
