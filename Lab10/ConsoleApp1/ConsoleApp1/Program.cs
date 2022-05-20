using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class DataSort
        {
            public int Permutations = 0;
            public int Comparisons = 0;
            public DateTime Time1;
            public DateTime Time2;
            public DataSort(int permutations, int comparisons, DateTime t1, DateTime t2)
            {
                Permutations = permutations;
                Comparisons = comparisons;
                Time1 = t1;
                Time2 = t2;
            }
            public void PrintInfo()
            {
                Console.WriteLine($"Количество сравнений: {Comparisons}");
                Console.WriteLine($"Количество перестановок: {Permutations}");
                Console.WriteLine($"Время работы: {Time2 - Time1}");
                comparisons = 0;
                permutations = 0;
                Console.WriteLine();
            }
        }
        public static int comparisons = 0;
        public static int permutations = 0;
        public static int[] MergeSorting(int[] array)
        {
            DateTime t1 = DateTime.Now;
            if (array.Length <= 1)
            {
                return array;
            }
            else
            {
                int[] Left = new int[array.Length / 2];
                int[] Right = new int[array.Length - Left.Length];
                for(int i = 0; i < Left.Length; i++)
                {
                    permutations++;
                    Left[i] = array[i];
                }
                for (int i = 0; i < Left.Length; i++)
                {
                    permutations++;
                    Right[i] = array[Left.Length + i];
                }
                if(Left.Length > 1)
                {
                    comparisons++;
                    Left = MergeSorting(Left);
                }
                if(Right.Length > 1)
                {
                    comparisons++;
                    Right = MergeSorting(Right);
                }
                array = _mergeSotr(Left, Right);
            }
            comparisons++;
            DateTime t2 = DateTime.Now;
            if(array.Length == 100)
            {
                DataSort info = new DataSort(permutations, comparisons, t1, t2);
                info.PrintInfo();
            }
            return array;
        }
        public static int[] _mergeSotr(int[] left, int[] right)
        {
            int[] array = new int[left.Length + right.Length];
            int l = 0, r = 0;
            for (int i = 0; i < array.Length; i++)
            {
                comparisons++;
                permutations++;
                if (r >= right.Length)
                {
                    array[i] = left[l];
                    l++;
                }
                else if (l < left.Length && left[l] < right[r])
                {
                    array[i] = left[l];
                    l++;
                }
                else
                {
                    array[i] = right[r];
                    r++;
                }
            }
            return array;
        }
        public static int[] QuickSorting(int[] array)
        {
            DateTime t1 = DateTime.Now;
            int Pivot = array[array.Length - 1];
            int r = 0, l = 0;
            int index = 2;
            while (r == 0 || l == 0)
            {
                foreach (int f in array)
                {
                    comparisons++;
                    if (Pivot < f)
                        r++;
                    else
                        l++;
                }
                comparisons++;
                if (index >= array.Length)
                {
                    return array;
                }
                comparisons++;
                if (r == 0)
                {
                    Pivot = array[array.Length - index];
                    l = r = 0;
                    index++;
                } 
            }
            int[] left = new int[l];
            int[] right = new int[r];            
            l = r = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > Pivot)
                {
                    right[r] = array[i];
                    r++;
                }
                else
                {
                    left[l] = array[i];
                    l++;
                }
            }
            if (left.Length > 1)
                comparisons++;
                left = QuickSorting(left);
            if (right.Length > 1)
                comparisons++;
                right = QuickSorting(right);
            for(int i = 0; i < left.Length; i++)
            {
                permutations++;
                array[i] = left[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                permutations++;
                array[left.Length + i] = right[i];
            }
            if (array.Length == 100)
            {
                WriteInFile(array);
                DateTime t2 = DateTime.Now;
                DataSort info = new DataSort(permutations, comparisons, t1, t2);
                info.PrintInfo();
            }
            return array;
        }
        public static int[] Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
            return array;
        }
        public static int[] HeapSort(int[] array)
        {
            DateTime t1 = DateTime.Now;
            int length = array.Length;
            for(int i = length / 2 - 1; i >= 0; i--)
            {
                _heapSort(array, length, i);
            }
            for (int i = length - 1; i >= 0; i--)
            {
                Swap(array, 0, i);
                permutations++;
                _heapSort(array, i, 0);
            }            
            if (array.Length == 100)
            {
                WriteInFile(array);
                DateTime t2 = DateTime.Now;
                DataSort info = new DataSort(permutations, comparisons, t1, t2);
                info.PrintInfo();
            }
            return array;
        }
        public static int[] _heapSort(int[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if(left < length && array[left] > array[largest])
            {
                comparisons++;
                largest = left;
            }
            if (right < length && array[right] > array[largest])
            {
                comparisons++;
                largest = right;
            }
            if(largest != i)
            {
                comparisons++;
                permutations++;
                Swap(array, i, largest);
                _heapSort(array, length, largest);
            }
            return array;
        }
        public static int[] ReversSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
        public static int[] JustSorting(int[] array)
        {
            int temp;
            int trans = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        trans++;
                    }
                }
            }
            return array;
        }
        public static void WriteInFile(int[] array)
        {
            string path = @"C:\Users\intre\source\repos\ConsoleApp1\sorted.dat";
            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {
                foreach(int number in array)
                {
                    sw.WriteLine(number);
                }
            }
        }
        static void Main(string[] args)
        {
            List<DataSort> info = new List<DataSort>();
            Random random = new Random();
            int[] Ordinary = new int[100];
            int[] Ascending = new int[100];
            int[] Descending = new int[100];
            Console.WriteLine("Текущий массив:");
            for (int i = 0; i < 100; i++)
            {
                Ordinary[i] = random.Next(0, 100);
                Console.Write(" " + Ordinary[i]);
            }
            Console.WriteLine();
            Ascending = JustSorting(Ordinary);
            Descending = ReversSort(Ordinary);
            int[] NewOrdinary = Ordinary;
            int[] NewAscending = Ascending;
            int[] NewDescending = Descending;
            Console.WriteLine("Выберите массив для сортировки: ");
            Console.WriteLine("\n 1 - Обычный массив" +
                              "\n 2 - Массив, отсортированный по возрастанию" +
                              "\n 3 - Массив, отсортированный по убыванию");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Array.Copy(Ordinary, NewOrdinary, 100);
                    Console.WriteLine("Сортировка слиянием: ");
                    NewOrdinary = MergeSorting(NewOrdinary);
                    Array.Copy(Ordinary, NewOrdinary, 100);
                    Console.WriteLine("Быстрая сортировка: ");
                    NewOrdinary = QuickSorting(NewOrdinary);
                    Array.Copy(Ordinary, NewOrdinary, 100);
                    Console.WriteLine("Пирамидальная сортировка: ");
                    NewOrdinary = HeapSort(NewOrdinary);
                    break;
                case 2:
                    Array.Copy(Ascending, NewAscending, 100);
                    Console.WriteLine("Сортировка слиянием: ");
                    NewOrdinary = MergeSorting(NewAscending);
                    Array.Copy(Ascending, NewAscending, 100);
                    Console.WriteLine("Быстрая сортировка: ");
                    NewOrdinary = QuickSorting(NewAscending);
                    Array.Copy(Ascending, NewAscending, 100);
                    Console.WriteLine("Пирамидальная сортировка: ");
                    NewOrdinary = HeapSort(NewAscending);
                    break;
                case 3:
                    Array.Copy(Descending, NewDescending, 100);
                    Console.WriteLine("Сортировка слиянием: ");
                    NewOrdinary = MergeSorting(NewDescending);
                    Array.Copy(Descending, NewDescending, 100);
                    Console.WriteLine("Быстрая сортировка: ");
                    NewOrdinary = QuickSorting(NewDescending);
                    Array.Copy(Descending, NewDescending, 100);
                    Console.WriteLine("Пирамидальная сортировка: ");
                    NewOrdinary = HeapSort(NewDescending);
                    break;
            }
            Console.ReadLine();
        }
    }
}
