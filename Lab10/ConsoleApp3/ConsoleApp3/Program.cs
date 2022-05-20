using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(8);
            graph.AddTop(1, 2, 3);
            graph.AddTop(2, 1, 6, 7);
            graph.AddTop(3, 1, 4, 6, 8);
            graph.AddTop(4, 3, 5);
            graph.AddTop(5, 4, 6);
            graph.AddTop(6, 2, 3, 5);
            graph.AddTop(7, 2, 8);
            graph.AddTop(8, 3, 7);       
            Console.WriteLine("Выберите способ поиска путей:" +
                "\n1 - BFS" +
                "\n2 - DFS");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введите точки X и Y");
                    graph.FindPathBFS(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Введите точки X и Y");
                    graph.FindPathDFS(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                    break;
            }            
            Console.ReadLine();
        }
    }
}
