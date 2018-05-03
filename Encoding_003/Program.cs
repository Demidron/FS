using System;
using System.IO;
using System.Text;

namespace StringBasics
{
	class Program
	{
		static void Main()
		{
			// Создание файла в кодировке UTF7.
			string file = "file.txt";
			StreamWriter writer = new StreamWriter(file, false, Encoding.UTF7);
			writer.WriteLine("Привет Мир!");
			writer.Close();
		   
			StreamReader reader = new StreamReader(file, Encoding.UTF7);
			Console.WriteLine(reader.ReadToEnd());
			reader.Close();

			reader = new StreamReader(file);
			Console.WriteLine(reader.ReadToEnd());
			reader.Close();

			// Задержка.
			Console.ReadKey();
		}
	}
}