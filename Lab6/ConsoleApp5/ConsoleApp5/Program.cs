using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesFiles = Directory.GetFiles(Directory.GetCurrentDirectory()+"\\MyIMG");
            Console.WriteLine("Файлы, содержащиеся в данной директории:");
            int index = 1;
            foreach (string file in namesFiles)
            {
                Console.WriteLine($"({index}) {file}");
                index++;
            }
            Console.WriteLine("Введите имя искомого файла:");
            string name = Console.ReadLine();
            string NameOfFile = "";
            foreach (string str in namesFiles)
            {
                if (str.Contains(name))
                {
                    NameOfFile = str;
                }
            }
            Console.WriteLine(NameOfFile);
            using (BinaryReader br = new BinaryReader(File.OpenRead(NameOfFile)))
            {
                br.BaseStream.Position = 2;
                Console.WriteLine($"Размер файла: {br.ReadInt32()} байт");
                br.BaseStream.Position = 18;
                Console.WriteLine($"Ширина: {br.ReadInt32()} пикселей");
                br.BaseStream.Position = 22;
                Console.WriteLine($"Ширина: {br.ReadInt32()} пикселей");
                br.BaseStream.Position = 28;
                Console.WriteLine($"Количество бит на один пиксель: {br.ReadInt32()}");
                br.BaseStream.Position = 38;
                Console.WriteLine($"Горизонтальное разрешение: {br.ReadInt32()} пикселей на метр");
                br.BaseStream.Position = 42;
                Console.WriteLine($"Вертикальное разрешение: {br.ReadInt32()} пикселей на метр");
                br.BaseStream.Position = 30;
                Console.WriteLine($"Тип сжатия: {br.ReadInt32()}"); 
            }
        }
    }
}
