using System;

namespace ConsoleApp2
{
    class Program
    {
        public static int[] Prefix(string str)
        {
            int index = 0;
            int[] array = new int[str.Length];
            array[0] = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if(str[index] != str[i] && index >= 0)
                {
                    index--;
                }
                index++;
                array[i] = index;
            }
            return array;
        }
        public static int Find_Substring_In_Text(string SubStr, string text)
        {
            int[] array = Prefix(SubStr);
            int index = 0;                                                                           //_
            for(int i = 0; i < text.Length;)                                  // A B C A B E A B C A B C A B D
            {                                                                 // A B C A B D *
                for(int j = 0; j < SubStr.Length;)
                {
                    if(text[i] == SubStr[j])
                    {
                        j++;
                        i++;
                        if(j == SubStr.Length - 1)
                        {
                            index = i - SubStr.Length + 1;
                            return index;
                        }
                    }
                    else if(text[i] != SubStr[j] && j > 0)
                    {
                        j = array[j - 1];
                    }
                    else
                    {
                        j = 0;
                        i++;
                        if(i >= text.Length - 1)
                        {
                            index = -1;
                            return index;
                        }
                    }
                }
            }
            return index;
        }
        public static int[] Table(string SubStr)
        {
            SubStr += "*";
            int[] array = new int[SubStr.Length];
            array[SubStr.Length - 1] = SubStr.Length - 1;
            int left = SubStr.Length - 3;
            for (int i = SubStr.Length - 3, index = 1, j = 0; i > -1; i--, index++)
            {
                while(j < left)
                {                    
                    if (array[i] == 0)
                    {
                        array[i] = index;
                    }
                    else if (SubStr[i] == SubStr[j])
                    {
                        array[j] = array[i];
                        j++;
                    }
                    else
                    {
                        j++;
                    }
                }
                left--;
                j = 0;
            }
            if(array[0] == 0)
            {
                array[0] = SubStr.Length - 2;
            }
            for(int i = 0; i < SubStr.Length - 3;)
            {
                if(SubStr[i] == SubStr[SubStr.Length - 2])
                {
                    array[SubStr.Length - 2] = array[i];
                    i = SubStr.Length - 3;
                }
                i++;
                if (i == SubStr.Length - 3)
                {
                    array[SubStr.Length - 2] = SubStr.Length - 1;
                }
            }
            return array;
        }
        public static int Find_SubString(string SubStr, string text)
        {
            int[] array = Table(SubStr);
            int lengh = SubStr.Length - 1;                          //ПЕРСОНАЛЬНЫЕ ДАННЫЕ
            int index = 0;
            for(int i = lengh; i < text.Length; i++)
            {
                if (text[i] == SubStr[lengh])
                {
                    for (int j = i - 1, k = lengh - 1; k > -1;)
                    {
                        if (SubStr[k] == text[j])
                        {
                            k--;
                            j--;
                            if (k == -1)
                            {
                                index = i - lengh;
                            }
                        }
                        else
                        {
                            for (int l = 0; l < SubStr.Length;)
                            {
                                if (text[i] == SubStr[l])
                                {
                                    i += array[l];
                                    i--;
                                    l = SubStr.Length;
                                }
                                else
                                {
                                    l++;
                                    if (l == SubStr.Length)
                                    {
                                        i += array[SubStr.Length - 1];
                                        i--;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < SubStr.Length;)
                    {
                        if (text[i] == SubStr[j])
                        {
                            i += array[j];
                            i--;
                            j = SubStr.Length;
                        }
                        else
                        {
                            j++;
                            if (j == SubStr.Length)
                            {
                                i += array[SubStr.Length - 1];
                                i--;
                            }
                        }
                    }
                }
            }
            return index;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();
            Console.WriteLine("Введите искомую строку: ");
            string str = Console.ReadLine();
            Console.WriteLine(Find_Substring_In_Text(str, text));
            Console.WriteLine(Find_SubString(str, text));
        }
    }
}
