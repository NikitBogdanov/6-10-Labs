using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\intre\source\repos\ConsoleApp4";
            string filePath = @"C:\Users\intre\source\repos\ConsoleApp4\lab.dat";
            string newFileName = @"C:\Users\intre\source\repos\ConsoleApp4\lab_backup.dat";
            Directory.CreateDirectory(directoryPath);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                File.Copy(@"C:\Users\intre\source\repos\Lab6\ConsoleApp1\lab.dat", filePath);
                Console.WriteLine("Копируем файл lab.dat");
                string text;
                using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default))
                {
                    text = sr.ReadToEnd();
                }
                using (FileStream fs = new FileStream(newFileName, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    fs.Write(array, 0, array.Length);
                    Console.WriteLine("Текст записан в файл");
                }
                Console.WriteLine("Информация о файле lab.dat:");
                Console.WriteLine("Размер файла:\t" + new FileInfo(filePath).Length);
                Console.WriteLine("Время последнего изменения:\t" + File.GetLastWriteTime(filePath));
                Console.WriteLine("Время последнего доступа:\t" + File.GetLastAccessTime(filePath));
            }
        }
    }
}
