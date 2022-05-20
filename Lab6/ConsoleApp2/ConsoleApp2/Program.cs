using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        public static void Mass(string path, int N, bool exist)
        {
            List<int> list = new List<int>();
            string path_New = @"C:\Users\intre\source\repos\Lab6\ConsoleApp2\arrey2.dat";
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs, System.Text.Encoding.Default))
                {
                    for (int i = 0; i <= N; i++)
                    {
                        list.Add(br.ReadInt32());
                    }
                }
            }
            using (FileStream fs = new FileStream(path_New, FileMode.OpenOrCreate))
            {
                using (BinaryWriter bw = new BinaryWriter(fs, System.Text.Encoding.Default))
                {
                    bw.Write(list[5]);
                    bw.Write(list[6]);
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                bool exist = true;
                List<int> list = new List<int>();
                Console.WriteLine("Введите максимальное количество шагов арифметической прогрессии:");
                int N = Convert.ToInt32(Console.ReadLine());
                string path = @"C:\Users\intre\source\repos\Lab6\ConsoleApp2\arrey1.dat";
                int progress = 4;
                list.Add(progress);
                for (int i = 0; i < N; i++)
                {
                    progress += 7;
                    list.Add(progress);
                }
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs, System.Text.Encoding.Default))
                    {
                        foreach (int f in list)
                        {
                            bw.Write(f);
                        }
                    }
                }
                Mass(path, N, exist);
                Console.WriteLine("5-й и 6-й элементы прогресии были записаны в файл 'arrey2.dat'");
            }
            catch
            {
                Console.WriteLine("В данной прогрессии не существует 5-го и 6-го членов!");
            }
        }
    }
}
