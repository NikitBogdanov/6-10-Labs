using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int[] CountingSort(int[] array)
        {
            int[] Empty = new int[array.Length];
            int[] Ansver = new int[array.Length];
            foreach(int money in array)
            {
                switch (money)
                {
                    case 1:
                        Empty[money] += 1;
                        break;
                    case 2:
                        Empty[money] += 1;
                        break;
                    case 5:
                        Empty[money] += 1;
                        break;
                    case 10:
                        Empty[money] += 1;
                        break;
                    case 20:
                        Empty[money] += 1;
                        break;
                    case 50:
                        Empty[money] += 1;
                        break;
                    case 100:
                        Empty[money - 1] += 1;
                        break;
                }
            }
            int index = 0;
            for(int i = 0; i < Empty.Length; i++)
            {
                for (int j = 0; j < Empty[i]; j++)
                {
                    Ansver[index] = i == 99 ? i + 1 : i;
                    index++;
                }
            }
            return Ansver;
        }
        static void Main(string[] args)
        {
            int[] MoneyArray = new int[100];
            Random random = new Random();
            for(int i = 0; i < MoneyArray.Length; i++)
            {
                int temp = random.Next(0, 7);
                switch (temp)
                {
                    case 0:
                        MoneyArray[i] = 1;
                        break;
                    case 1:
                        MoneyArray[i] = 2;
                        break;
                    case 2:
                        MoneyArray[i] = 5;
                        break;
                    case 3:
                        MoneyArray[i] = 10;
                        break;
                    case 4:
                        MoneyArray[i] = 20;
                        break;
                    case 5:
                        MoneyArray[i] = 50;
                        break;
                    case 6:
                        MoneyArray[i] = 100;
                        break;
                }
            }
            foreach(int f in MoneyArray)
            {
                Console.Write(f + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            foreach (int f in CountingSort(MoneyArray))
            {
                Console.Write(f + " ");
            }
            Console.ReadLine();
        }
    }
}
