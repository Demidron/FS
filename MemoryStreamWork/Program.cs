using System;
using System.IO;
 
namespace MemoryStreamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //    // Создаем объект MemoryStream точно определенного объема.
            //    MemoryStream ms = new MemoryStream();
            //    ms.Capacity = 10;

            //    for (int i = 0; i < 10; i++)
            //        ms.WriteByte((byte)i);

            //    ms.Position = 0;

            //    for (int i = 0; i < 10; i++)
            //        Console.Write(ms.ReadByte());

            //    Console.WriteLine("\n");

            //    //=====================================================================================

            //    // Сбрасываем данные из MemoryStream в файл.
            //    FileStream fs = new FileStream("Dump.dat", FileMode.Create, FileAccess.ReadWrite);
            //    ms.WriteTo(fs);

            //    byte[] array = ms.ToArray();

            //    foreach (byte b in array)
            //        Console.Write(b);

            //    fs.Close();
            //    ms.Close();

            //    Console.ReadKey();

            char[,] Arr = new char[,]
            {
                { 'X',' ',' ' },
                { ' ','X','O' },
                { 'X','O','O' },
            };
            int Kol = 1;
            int WinX = 1;
            int WinO = 0;
            int NoWiner = 2;

            MemoryStream ms = new MemoryStream();
            ms.Capacity = 10;



            byte byteValue = 0B00000000;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    if (byteValue >= 0b01000000)
                    {
                        ms.WriteByte(byteValue);
                        byteValue = 0;
                    }
                    byteValue *= 0b100;
                    if (Arr[i, j] == 'X')
                        byteValue += (0b11);
                    else if (Arr[i, j] == 'O')
                        byteValue += (0b10);
                }

            }
            if (byteValue != 0)
            {

                while (byteValue < 0b01000000)
                {
                    byteValue *= 0b100;
                }
                ms.WriteByte(byteValue);
            }
            ms.WriteByte((byte)Kol);
            ms.WriteByte((byte)WinX);
            ms.WriteByte((byte)WinO);
            ms.WriteByte((byte)NoWiner);
            FileStream fs = new FileStream("Save.dat", FileMode.Create, FileAccess.ReadWrite);


            ms.WriteTo(fs);

            //byte[] array = ms.ToArray();

            //foreach (byte b in array)
            //    Console.Write(b);

            fs.Close();
            ms.Close();

            Console.ReadKey();

            FileStream fs2 = new FileStream("Save.dat", FileMode.Open, FileAccess.Read);
            //byte divider = 0B1000000;

            //int Byte = fs2.ReadByte();
            //for (int i = 0; i < Arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < Arr.GetLength(1); j++)
            //    {
            //        if (divider == 0)
            //        {

            //            divider = 0B1000000;
            //            Byte = fs2.ReadByte();
            //        }
            //        if (Byte / divider != 0)
            //        {
                      
            //            if (Byte / divider == 0b10)
            //            {
            //                Arr[i, j] = 'O';

            //            }
            //            else
            //            {
            //                Arr[i, j] = 'X';

            //            }
            //        }
            //        else
            //        {
            //            Arr[i, j] = ' ';

            //        }
            //        Byte -= Byte / divider * divider;
            //        divider /= 0b100;
            //    }
            //}


            //for (int i = 0; i < Arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < Arr.GetLength(1); j++)
            //    {
            //        Console.Write(Arr[i, j]);
            //    }
            //    Console.WriteLine();

            //}
            fs2.ReadByte();
            fs2.ReadByte();
            fs2.ReadByte();
            Kol = fs2.ReadByte();
            WinX = fs2.ReadByte();
            WinO = fs2.ReadByte();
            NoWiner = fs2.ReadByte();
            fs2.Close();
            Console.WriteLine(Kol);
            Console.WriteLine(WinX);
            Console.WriteLine(WinO);
            Console.WriteLine(NoWiner);
        }
    }
}
