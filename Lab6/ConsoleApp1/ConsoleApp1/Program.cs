using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5
{
    enum Functions
    {
        See = 1,
        Add = 2,
        Del = 3,
        Update = 4,
        Find = 5,
        Log = 6,
        Exit = 7
    }
    enum System
    {
        Ф = 1,
        УГ = 2
    }
    struct Geograf
    {
        public string state;
        public string capital;
        public string people;
        public System system;
        public void Print(List<Geograf> list)
        {
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________");
            Console.WriteLine("|География                                                   |");
            Console.WriteLine("|____________________________________________________________|");
            Console.WriteLine("|Государство       |Столица      |Население      |Строй      |");
            Console.WriteLine("|__________________|_____________|_______________|___________|");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("|____________________________________________________________|");
                Console.WriteLine($"|{list[i].state,-18}|{list[i].capital,-13}|{list[i].people,-15}|{list[i].system,-11}|");
                Console.WriteLine("|__________________|_____________|_______________|___________|");
            }
            Console.WriteLine("|Перечисляемый тип: Ф - федерация, УГ - унитарное государство|");
            Console.WriteLine("|____________________________________________________________|");
            Console.WriteLine();
        }
    }
    struct Log
    {
        public string choice_Functions;
        public string time;
        public static void SeeLog(List<Log> time)
        {
            if (time.Count > 1)
            {
                for (int i = 0; i < time.Count; i++)
                {
                    Console.WriteLine($"{Convert.ToDateTime(time[i].time).TimeOfDay}{time[i].choice_Functions}");
                }
                TimeSpan ansver = Convert.ToDateTime(time[1].time).TimeOfDay - Convert.ToDateTime(time[0].time).TimeOfDay;
                for (int i = 0, j = 1; i < time.Count - 1; i++)
                {
                    if (j < time.Count)
                    {
                        TimeSpan dif = Convert.ToDateTime(time[j].time).TimeOfDay - Convert.ToDateTime(time[i].time).TimeOfDay;
                        if (dif > ansver)
                        {
                            ansver = dif;
                        }
                        j++;
                    }
                }
                Console.WriteLine();
                Console.WriteLine(ansver + " - Самый долгий период бездействия пользователя");
            }
            else if (time.Count == 1)
            {
                for (int i = 0; i < time.Count; i++)
                {
                    Console.WriteLine($"{Convert.ToDateTime(time[i].time).TimeOfDay}{time[i].choice_Functions}");
                }
            }
            else
            {
                Console.WriteLine("Лог пуст...");
            }
        }
    }
    class Program
    {
        static void WriteToFile(string path, List<Geograf> list)
        {
            File.WriteAllText(path, string.Empty);
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Geograf g in list)
                {
                    bw.Write($"{g.state} {g.capital} {g.people} {g.system}");
                }
            }
        }
        static void ReadFromFile(string path, List<Geograf> list)
        {
            Geograf geo;
            if (File.Exists(path))
            {
                list.Clear();
                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (br.PeekChar() > -1)
                    {
                        string[] geografi = br.ReadString().Split();
                        geo.state = geografi[0];
                        geo.capital = geografi[1];
                        geo.people = geografi[2];
                        if (geografi[3].Equals("Ф"))
                        {
                            geo.system = System.Ф;
                        }
                        else
                        {
                            geo.system = System.УГ;
                        }
                        list.Add(geo);
                    }
                }
            }
            else
            {
                File.Create(path).Close();
            }
        }
        static void Main(string[] args)
        {
            List<Geograf> list = new List<Geograf>();
            List<Log> time_List = new List<Log>(50);
            List<Geograf> newList = new List<Geograf>();
            string path = @"C:\Users\intre\source\repos\Lab6\ConsoleApp1\lab.dat";
            bool exit = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Выберите пункт меню: ");
                Console.WriteLine($"1 – Просмотр таблицы" +
                                  $"\n2 – Добавить запись" +
                                  $"\n3 – Удалить запись" +
                                  $"\n4 – Обновить запись" +
                                  $"\n5 – Поиск записей" +
                                  $"\n6 – Просмотреть лог" +
                                  $"\n7 - Выход");
                Console.WriteLine();
                try
                {
                    Functions choice = (Functions)int.Parse(Console.ReadLine().Trim());
                    Geograf geo;
                    geo.state = null;
                    geo.capital = null;
                    geo.people = null;
                    geo.system = System.Ф;
                    Log log;
                    log.choice_Functions = null;
                    log.time = null;
                    if (choice is Functions.See)
                    {
                        ReadFromFile(path, list);
                        geo.Print(list);
                    }
                    else if (choice is Functions.Add)
                    {
                        Console.WriteLine("Государство:");
                        geo.state = Console.ReadLine().Trim();
                        Console.WriteLine("Столица:");
                        geo.capital = Console.ReadLine().Trim();
                        Console.WriteLine("Население:");
                        geo.people = Console.ReadLine().Trim();
                        Console.WriteLine("Госудврственный строй (Ф - федерация, УГ - унитарное государство):");
                        bool error = true;
                        do
                        {
                            string sys = Console.ReadLine().Trim();
                            if (sys == "Ф")
                            {
                                geo.system = System.Ф;
                                error = false;
                            }
                            else if (sys == "УГ")
                            {
                                geo.system = System.УГ;
                                error = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите либо Ф, либо УГ!");
                            }
                        } while (error);
                        list.Add(geo);
                        WriteToFile(path, list);
                        log.time = Convert.ToString(DateTime.Now);
                        log.choice_Functions = $" - Добавлена запись: '{geo.state}'";
                        time_List.Add(log);
                    }
                    else if (choice is Functions.Del)
                    {
                        Console.WriteLine("Введите номер удаляемой записи:");
                        int number;
                        if (!int.TryParse(Console.ReadLine(), out number))
                        {
                            Console.WriteLine("Введите число!");
                        }
                        else
                        {
                            if (list.Count >= number)
                            {
                                log.time = Convert.ToString(DateTime.Now);
                                log.choice_Functions = $" - Удалена запись: '{list[number - 1].state}'";
                                time_List.Add(log);
                                list.RemoveAt(number - 1);
                                WriteToFile(path, list);
                            }
                            else if (number < 0)
                            {
                                Console.WriteLine("Записи с таким номером не существует!");
                            }
                            else
                            {
                                Console.WriteLine("Записи с таким номером не существует!");
                            }
                        }
                    }
                    else if (choice is Functions.Update)
                    {

                        Console.WriteLine("Введине номер обновляемой записи:");
                        int number;
                        if (!int.TryParse(Console.ReadLine(), out number))
                        {
                            Console.WriteLine("Вы ввели не число!");
                        }
                        else
                        {
                            if (list.Count >= number)
                            {
                                list.RemoveAt(number - 1);
                                Console.WriteLine("Государство:");
                                geo.state = Console.ReadLine().Trim();
                                Console.WriteLine("Столица:");
                                geo.capital = Console.ReadLine().Trim();
                                Console.WriteLine("Население:");
                                geo.people = Console.ReadLine().Trim();
                                Console.WriteLine("Строй:");
                                bool error = true;
                                do
                                {
                                    string sys = Console.ReadLine().Trim();
                                    if (sys == "Ф")
                                    {
                                        geo.system = System.Ф;
                                        error = false;
                                    }
                                    else if (sys == "УГ")
                                    {
                                        geo.system = System.УГ;
                                        error = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введите либо Ф, либо УГ!");
                                    }
                                } while (error);
                                log.time = Convert.ToString(DateTime.Now);
                                log.choice_Functions = $" - Обновлена запись: '{list[number - 1].state}'";
                                time_List.Add(log);
                                list.Insert(number - 1, geo);
                                WriteToFile(path, list);
                            }
                            else if (list.Count < number)
                            {
                                Console.WriteLine("Записи с таким номером не существует!");
                            }
                        }
                    }
                    else if (choice is Functions.Find)
                    {
                        List<Geograf> list_Find = new List<Geograf>();
                        Console.WriteLine("Выберите фильтр:");
                        string filter = Console.ReadLine().Trim();
                        switch (filter)
                        {
                            case "Государство":
                                Console.WriteLine("Введите название государства:");
                                string state = Console.ReadLine().Trim();
                                string find_state = null;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    find_state = $"{list[i].state}";
                                    if (find_state.Contains(state))
                                    {
                                        list_Find.Add(list[i]);
                                        geo.Print(list_Find);
                                    }
                                    else if (i >= list.Count) { list_Find.Clear(); }
                                }
                                break;
                            case "Столица":
                                Console.WriteLine("Введите название столицы:");
                                string capital = Console.ReadLine().Trim();
                                string find_capital = null;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    find_capital = $"{list[i].capital}";
                                    if (find_capital.Contains(capital))
                                    {
                                        list_Find.Add(list[i]);
                                        geo.Print(list_Find);
                                    }
                                    else if (i >= list.Count) { list_Find.Clear(); }
                                }
                                break;
                            case "Население":
                                Console.WriteLine("Введите численность населения:");
                                string people = Console.ReadLine().Trim();
                                string find_people = null;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    find_people = $"{list[i].people}";
                                    if (find_people.Contains(people))
                                    {
                                        list_Find.Add(list[i]);
                                        geo.Print(list_Find);
                                    }
                                    else if (i >= list.Count) { list_Find.Clear(); }
                                }
                                break;
                            case "Строй":
                                Console.WriteLine("Введите форму государственного устройства:");
                                string system = Console.ReadLine().Trim();
                                string find_system = null;
                                for (int i = 0; i < list.Count; i++)
                                {
                                    find_system = $"{list[i].system}";
                                    if (find_system.Contains(system))
                                    {
                                        list_Find.Add(list[i]);
                                        geo.Print(list_Find);
                                    }
                                    if (i >= list.Count) { list_Find.Clear(); }
                                }
                                break;
                            default:
                                Console.WriteLine("Вы ввели несуществующий фильтр!");
                                break;
                        }
                    }
                    else if (choice is Functions.Log)
                    {
                        Log.SeeLog(time_List);
                    }
                    else if (choice is Functions.Exit)
                    {
                        exit = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Такого пункта меню не существует!");
                }
            } while (exit == true);
        }
    }
}