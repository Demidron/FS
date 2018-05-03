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
            // Открываем файл изображения в каталоге приложения
            Console.WriteLine("Изменение bitmap в памяти");
            FileStream fs = new FileStream("Picture.bmp", FileMode.Open, FileAccess.ReadWrite);

            // Создаем объект Bitmap на основе открытого потока
            Bitmap bitmap = new Bitmap(fs);

            // Рисуем бело-красный крест поперек изображения (данный код применим лишь в том случае, 
            // если высота и ширина изображения одинаковы) 
            for (int i = 0; i < bitmap.Width; i++)
            {
                bitmap.SetPixel(i, i, Color.White);
                bitmap.SetPixel((bitmap.Width - i) - 1, i, Color.Red);                
            }

            // Сохраняем измененное изображение в отдельный файл
            bitmap.Save("NewImage.bmp");
            fs.Close();
        }
    }
}
