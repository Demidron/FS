using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace X0G
{
    class X0Game
    {
        int x = 0;
        int y = 0;
        public bool XO = true;
        char sym1 = 'X';
        char sym2 = 'O';
        int steps = 0;


        int Kol = 1;
        int WinX = 0;
        int WinO = 0;
        int NoWiner = 0;

        char[,] Arr = new char[,]
        {
            { ' ',' ',' ' },
            { ' ',' ',' ' },
            { ' ',' ',' ' },

        };
        List<char> Lst = new List<char>();

        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    Console.Write($"{Arr[i, j]}|");
                }
                //Console.WriteLine();
                Console.WriteLine("\n-+-+-");
            }
        }
        public void Move(ConsoleKey key)
        {

            int i = Arr.GetLength(0) - 1;
            int j = Arr.GetLength(1) - 1;
            if (key == ConsoleKey.W)
            {
                if (y > 0)
                    y--;
                else y = j;
            }
            if (key == ConsoleKey.S)
            {
                if (y < j)
                    y++;
                else y = 0;

            }
            if (key == ConsoleKey.D)
            {
                if (x < i)
                    x++;
                else x = 0;
            }
            if (key == ConsoleKey.A)
            {
                if (x > 0)
                    x--;
                else x = i;
            }
            Console.SetCursorPosition(x * 2, y * 2);
        }
        public void SetXO()
        {
            if (Arr[y, x] == ' ')
            {
                Arr[y, x] = XO ? sym1 : sym2;
                steps++;
                XO = !XO;
            }
            EndGame();
        }
        public void EndGame()
        {

            if (steps > 4)
            {

                for (int i = 0; i < Arr.GetLength(1); i++)
                {
                    if (Arr[i, 1] != ' ' && Arr[i, 0] == Arr[i, 1] && Arr[i, 1] == Arr[i, 2])
                    {
                        Arr[i, 0] = '-';
                        Arr[i, 1] = '-';
                        Arr[i, 2] = '-';
                        Draw();
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine($"Game End, win: ");
                        Console.WriteLine(XO ? sym2 : sym1);
                        if (XO == true)
                        {
                            WinO++;
                        }
                        else
                        {
                            WinX++;
                        }
                        Console.ReadKey();
                        Menu(ConsoleKey.D1);
                    }

                }
                for (int i = 0; i < Arr.GetLength(0); i++)
                {
                    if (Arr[1, i] != ' ' && Arr[0, i] == Arr[1, i] && Arr[1, i] == Arr[2, i])
                    {
                        Arr[0, i] = '|';
                        Arr[1, i] = '|';
                        Arr[2, i] = '|';
                        Draw();
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine($"Game End, win: ");
                        Console.WriteLine(XO ? sym2 : sym1);
                        if (XO == true)
                        {
                            WinO++;
                        }
                        else
                        {
                            WinX++;
                        }
                       
                        Console.ReadKey();
                        Menu(ConsoleKey.D1);
                    }
                }
                if (Arr[2, 2] != ' ' && Arr[0, 0] == Arr[1, 1] && Arr[1, 1] == Arr[2, 2])
                {
                    Arr[1, 1] = '\\';
                    Arr[2, 2] = '\\';
                    Arr[0, 0] = '\\';
                    Draw();
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine($"Game End, win: ");
                    Console.WriteLine(XO ? sym2 : sym1);
                    if (XO == true)
                    {
                        WinO++;
                    }
                    else
                    {
                        WinX++;
                    }
                    
                    Console.ReadKey();
                    Menu(ConsoleKey.D1);
                }
                if (Arr[1, 1] != ' ' && Arr[0, 2] == Arr[1, 1] && Arr[1, 1] == Arr[2, 0])
                {
                    Arr[0, 2] = '/';
                    Arr[1, 1] = '/';
                    Arr[2, 0] = '/';
                    Draw();
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine($"Game End, win: ");
                    Console.WriteLine(XO ? sym2 : sym1);
                    if (XO == true)
                    {
                        WinO++;
                    }
                    else
                    {
                        WinX++;
                    }

                 
                    Console.ReadKey();
                    Menu(ConsoleKey.D1);
                }
            }

            if (steps == 9)
            {
                Console.SetCursorPosition(0, 6);
                Console.WriteLine($"Game End, No winer ");

                NoWiner++;
                
                Console.ReadKey();
                Menu(ConsoleKey.D1);
            }


        }
        public void SaveGame()
        {

            MemoryStream ms = new MemoryStream();
            ms.Capacity = 10;

            byte byteValue = 0;
            int h = 0;

            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    if (h==4/*byteValue >= 0b01000000*/)
                    {
                        ms.WriteByte(byteValue);
                        byteValue = 0;
                        h = 0;
                    }
                    byteValue *= 0b100;
                    if (Arr[i, j] == 'X')
                        byteValue += (0b11);
                    else if (Arr[i, j] == 'O')
                        byteValue += (0b10);
                    h++;
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


            FileStream fs = new FileStream("Save.dat", FileMode.Create, FileAccess.Write);
            ms.WriteTo(fs);

            byte[] array = ms.ToArray();

            //foreach (byte b in array)
            //    Console.Write(b);

            fs.Close();
            ms.Close();
        }

        public void LoadGame()
        {

            FileStream fs = new FileStream("Save.dat", FileMode.Open, FileAccess.Read);
            byte divider = 0B1000000;
            XO = true;
            steps = 0;
            int Byte = fs.ReadByte();
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    if (divider == 0)
                    {

                        divider = 0B1000000;
                        Byte = fs.ReadByte();
                    }
                    if (Byte / divider != 0)
                    {
                        steps++;
                        XO = !XO;
                        if (Byte / divider == 0b10)
                        {
                            Arr[i, j] = 'O';

                        }
                        else
                        {
                            Arr[i, j] = 'X';

                        }
                    }
                    else
                    {
                        Arr[i, j] = ' ';

                    }
                    Byte -= Byte / divider * divider;
                    divider /= 0b100;
                }
            }
            fs.Position = 2;
            Kol = fs.ReadByte();
            WinX = fs.ReadByte();
            WinO = fs.ReadByte();
            NoWiner = fs.ReadByte();
            fs.Close();
            
        }
        public void NewGame()
        {
            x = 0;
            y = 0;
            XO = true;
            steps = 0;
            Kol++;
            Arr = new char[,]
            {
                { ' ',' ',' ' },
                { ' ',' ',' ' },
                { ' ',' ',' ' },

            };
        }
        public void Menu(ConsoleKey tmp)
        {
            Console.WriteLine("Меню нажмите 1");
            Console.WriteLine($"Номер игры: {Kol}");
            Console.WriteLine($"Побед Х: {WinX}");
            Console.WriteLine($"Побед О: {WinO}");
            Console.WriteLine($"Ничья: {NoWiner}");
            if (tmp == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine("Сохранить игру 1");
                Console.WriteLine("Загрузить игру 2");
                Console.WriteLine("Новая игра 3");
                Console.WriteLine("Вернутся в игру 4");


                var Key = Console.ReadKey().Key;
                switch (Key)
                {
                    case ConsoleKey.D1:
                        SaveGame();
                        Console.WriteLine("Saved");
                        Menu(ConsoleKey.D1);
                        break;
                    case ConsoleKey.D2:
                        LoadGame();
                        Draw();
                        Menu();
                        break;
                    case ConsoleKey.D3:
                        NewGame();
                        Draw();
                        Menu();
                        break;
                    case ConsoleKey.D4:

                        Draw();
                        Menu();
                        break;


                }
            }
        }
        public void Menu()
        {
            Console.WriteLine("Меню нажмите 1");
            Console.WriteLine($"Номер игры: {Kol}");
            Console.WriteLine($"Побед Х: {WinX}");
            Console.WriteLine($"Побед О: {WinO}");
            Console.WriteLine($"Ничья: {NoWiner}");
        }
    }
}