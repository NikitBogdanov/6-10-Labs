using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    struct Information
    {
        public TimeSpan WorkTime;
        public int Comparison;
        public int Transposition;
        public void PrintInfo(List<Information> list, List<string> NewList)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{NewList[i]}: {list[i].WorkTime} | {list[i].Comparison} | {list[i].Transposition}");
            }
            list.Clear();
            NewList.Clear();
        }
    }
    class Program
    {
        public static void SortByShell(int[] array, List<Information> list, List<string> NewList)
        {
            int comparison = 0;
            int transpositions = 0;
            Information info;
            DateTime start = DateTime.Now;
            int distance = array.Length / 2;
            while(distance >= 1)
            {
                for(int i = distance; i < array.Length; i++)
                {
                    int j = i;
                    while((j >= distance) && (array[j - distance] > array[j]))
                    {
                        comparison++;
                        int temp = array[j];
                        array[j] = array[j - distance];
                        array[j - distance] = temp;
                        j = j - distance;
                        transpositions++;
                    }
                    comparison++;
                }
                distance = distance / 2;
            }
            DateTime end = DateTime.Now;
            info.WorkTime = end - start;
            info.Comparison = comparison;
            info.Transposition = transpositions;
            list.Add(info);
            NewList.Add("Сортировка Шелла");
            info.PrintInfo(list, NewList);
        }
        public static void SortingByShaker(int[] array, List<Information> list, List<string> NewList)
        {
            int comparison = 0;
            int transpositions = 0;
            Information info;
            DateTime start = DateTime.Now;
            int left = 0;
            int right = array.Length - 1;
            while(left < right)
            {
                for(int i = left; i < right; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        transpositions++;
                    }
                    comparison++;
                }
                right--;
                for(int i = right; i > left; i--)
                {
                    if(array[i - 1] > array[i])
                    {
                        int temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        transpositions++;
                    }
                    comparison++;
                }
                left++;
            }
            DateTime end = DateTime.Now;
            info.WorkTime = end - start;
            info.Comparison = comparison;
            info.Transposition = transpositions;
            list.Add(info);
            NewList.Add("Сортировка шейкером");
            info.PrintInfo(list, NewList);
        }
        public static void BubbleSorting(int[] array, List<Information> list, List<string> NewList)
        {
            int comparison = 0;
            int transpositions = 0;
            Information info;
            DateTime start = DateTime.Now;
            int temp;
            for(int i = 0; i < array.Length - 1; i++)
            {
                for(int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        transpositions++;
                    }
                    comparison++;
                }
            }
            DateTime end = DateTime.Now;
            info.WorkTime = end - start;
            info.Comparison = comparison;
            info.Transposition = transpositions;
            list.Add(info);
            NewList.Add("Сортировка пузырьком");
            info.PrintInfo(list, NewList);
        }
        public static void SortingByChoice(int[] array, List<Information> list, List<string> NewList)
        {
            int comparison = 0;
            int transpositions = 0;
            Information info;
            DateTime start = DateTime.Now;
            int index;
            for(int i = 0; i < array.Length; i++)
            {
                index = i;
                for(int j = i; j < array.Length; j++)
                {
                    if(array[j] < array[index])
                    {
                        index = j;
                    }
                    comparison++;
                }
                if(array[index] == array[i])
                {
                    continue;
                }
                else
                {
                    int temp = array[i];
                    array[i] = array[index];
                    array[index] = temp;
                    transpositions++;
                }
            }
            DateTime end = DateTime.Now;
            info.WorkTime = end - start;
            info.Transposition = transpositions;
            info.Comparison = comparison;
            list.Add(info);
            NewList.Add("Сортировка выбором");
            info.PrintInfo(list, NewList);
        }
        public static void InsertionSort(int[] array, List<Information> list, List<string> NewList)
        {
            int comparison = 0;
            int transpositions = 0;
            Information info;
            DateTime start = DateTime.Now;
            int index;
            int currentNumber;
            for (int i = 1; i < array.Length; i++)
            {
                currentNumber = array[i];
                index = i;
                while (index > 0 && array[index - 1] > currentNumber)
                {
                    comparison++;
                    array[index] = array[index - 1];
                    index--;
                    transpositions++;
                }
                comparison++;
                array[index] = currentNumber;
                transpositions++;
            }
            DateTime end = DateTime.Now;
            info.WorkTime = end - start;
            info.Transposition = transpositions;
            info.Comparison = comparison;
            list.Add(info);
            NewList.Add("Сортировка вставками");
            info.PrintInfo(list, NewList);
        }
        public static int[] JustSorting(int[] array, List<int> testList)
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
            testList.Add(trans);
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
        static void Main(string[] args)
        {
            List<Information> list = new List<Information>();
            List<string> NewList = new List<string>();
            List<int> testList = new List<int>();
            string path = @"C:\Users\intre\source\repos\Lab7\ConsoleApp2\sorted.dat";
            int[] ArrayForReader = new int[100];
            string Empty = null;
            int[] test = new int[100];
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < ArrayForReader.Length; i++)
                {
                    ArrayForReader[i] = int.Parse(sr.ReadLine());
                }
                Empty = sr.ReadToEnd();
            }
            Array.Copy(ArrayForReader, test, 100);
            JustSorting(test, testList);
            if(testList[0] != 0)
            {
                testList.Clear();
                Console.WriteLine("Массив не остортирован!");
                int[] JustArray = ArrayForReader;
                int[] NewJustArray = new int[100];
                int[] ArrayInAscendingOrder = JustSorting(JustArray, testList);
                int[] ArrayInDescendingOrder = ReversSort(JustArray);
                int[] NewArrayInAscendingOrder = new int[100];
                int[] NewArrayInDescendingOrder = new int[100];
                for (int i = 0; i < ArrayForReader.Length; i++)
                {
                    NewJustArray[i] = JustArray[i];
                    NewArrayInAscendingOrder[i] = ArrayInAscendingOrder[i];
                    NewArrayInDescendingOrder[i] = ArrayInDescendingOrder[i];
                }
                Console.WriteLine("Выберите массив: \n1 - случайный массив\n2 - упорядоченный по возрастанию массив\n3 - упорядоченный по убыванию массив\n4 - выход\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":                        
                        InsertionSort(NewJustArray, list, NewList);
                        Array.Copy(JustArray, NewJustArray, 100);
                        SortingByChoice(NewJustArray, list, NewList);
                        Array.Copy(JustArray, NewJustArray, 100);
                        BubbleSorting(NewJustArray, list, NewList);
                        using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
                        {
                            foreach (int number in NewJustArray)
                            {
                                sw.WriteLine(number);
                            }
                        }
                        Array.Copy(JustArray, NewJustArray, 100);
                        SortingByShaker(NewJustArray, list, NewList);
                        Array.Copy(JustArray, NewJustArray, 100);
                        SortByShell(NewJustArray, list, NewList);
                        Array.Copy(JustArray, NewJustArray, 100);
                        break;
                    case "2":
                        InsertionSort(NewArrayInAscendingOrder, list, NewList);
                        Array.Copy(ArrayInAscendingOrder, NewArrayInAscendingOrder, 100);
                        SortingByChoice(NewArrayInAscendingOrder, list, NewList);
                        Array.Copy(ArrayInAscendingOrder, NewArrayInAscendingOrder, 100);
                        BubbleSorting(NewArrayInAscendingOrder, list, NewList);
                        using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
                        {
                            foreach (int number in NewArrayInAscendingOrder)
                            {
                                sw.WriteLine(number);
                            }
                        }
                        Array.Copy(ArrayInAscendingOrder, NewArrayInAscendingOrder, 100);
                        SortingByShaker(NewArrayInAscendingOrder, list, NewList);
                        Array.Copy(ArrayInAscendingOrder, NewArrayInAscendingOrder, 100);
                        SortByShell(NewArrayInAscendingOrder, list, NewList);
                        Array.Copy(ArrayInAscendingOrder, NewArrayInAscendingOrder, 100);
                        break;
                    case "3":
                        InsertionSort(NewArrayInDescendingOrder, list, NewList);
                        Array.Copy(ArrayInDescendingOrder, NewArrayInDescendingOrder, 100);
                        SortingByChoice(NewArrayInDescendingOrder, list, NewList);
                        Array.Copy(ArrayInDescendingOrder, NewArrayInDescendingOrder, 100);
                        BubbleSorting(NewArrayInDescendingOrder, list, NewList);
                        using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
                        {
                            foreach (int number in NewArrayInDescendingOrder)
                            {
                                sw.WriteLine(number);
                            }
                        }
                        Array.Copy(ArrayInDescendingOrder, NewArrayInDescendingOrder, 100);
                        SortingByShaker(NewArrayInDescendingOrder, list, NewList);
                        Array.Copy(ArrayInDescendingOrder, NewArrayInDescendingOrder, 100);
                        SortByShell(NewArrayInDescendingOrder, list, NewList);
                        Array.Copy(ArrayInDescendingOrder, NewArrayInDescendingOrder, 100);
                        break;
                }
            }
            else
            {
                testList.Clear();
                Random random = new Random();
                int[] ArrayForWriter = new int[100];
                for (int i = 0; i < ArrayForWriter.Length; i++)
                {
                    ArrayForWriter[i] = random.Next(0, 100);
                }
                using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate)))
                {
                    foreach (int number in ArrayForWriter)
                    {
                        sw.WriteLine(number);
                    }
                }
            }
        }
    }
}
