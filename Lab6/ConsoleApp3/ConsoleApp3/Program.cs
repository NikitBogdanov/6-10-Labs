using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string path = @"C:\Users\intre\source\repos\Lab6\ConsoleApp3\text.txt";
            string newPath = @"C:\Users\intre\source\repos\Lab6\ConsoleApp3\newText.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            int k = 0;
            int indexDel = 0;
            for (int i = 0; i < list.Count;)
            {
                string str = list[i];
                if (k < str.Length)
                {
                    if (Char.IsNumber(str[k]))
                    {
                        list.RemoveAt(i);
                        indexDel++;
                        k = 0;
                    }
                    else
                    {
                        k++;
                    }
                }
                else
                {
                    k = 0;
                    i++;
                }
            }
            Console.WriteLine($"Количество удалённых строк {indexDel}");
            using (StreamWriter sw = new StreamWriter(newPath, true, System.Text.Encoding.Default))
            {
                foreach (string f in list)
                {
                    sw.WriteLine(f);
                }
            }
        }
    }
}
