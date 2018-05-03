using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace BinaryReaderWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание файла и запись двоичных данных...\n");

			FileStream fs = new FileStream("Temp.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

			// Записываем двоичные данные.
			BinaryWriter bw = new BinaryWriter(fs);
           
            bool myBool = true;
			int myInt = 99;
			float myFloat = 9984.82343F;			
			char[] myCharArray = {
                 'H', 'e', 'l', 'l', 'o' 
                // { 'W', 'O', 'R', 'l', 'D' }
            };
            Encoding unicode = Encoding.Unicode;
            byte[] b = unicode.GetBytes(myCharArray);
            //bw.Write(myBool);
            //bw.Write(myInt);
            //bw.Write(myFloat);            
            bw.Write(b);
            //bw.Write("Hello - как двоичная информация...");  


			// Устанавливаем внутренний указатель на начало.
			bw.BaseStream.Position = 0;

			// Считываем двоичную информацию как поток байтов.
			Console.WriteLine("Чтение двоичных данных...");

			BinaryReader br = new BinaryReader(fs);

			int temp = 0;
			while(br.PeekChar() != -1)
			{
				Console.Write(br.ReadByte());
                Console.Write(" ");

				temp = temp + 1;
                // Добавляем "=" через каждые 8 байтов. 
                if (temp == 5)
                {
                    temp = 0;
                    Console.WriteLine("=");
                }
			}

			bw.Close();
			br.Close();
			fs.Close();
            Console.WriteLine((int)'e');
            Console.ReadKey();
        }
    }
}
