using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Graph
    {
        List<GraphElement> GraphsList;
        List<int> Checked = new List<int>();
        public Graph(int count)
        {
            GraphsList = new List<GraphElement>(count);
        }
        public void AddTop(int f, int i, int j)
        {
            var GraphList = new GraphElement(f, false, new GraphElement(i, false, new GraphElement(j, false, null)));
            GraphsList.Add(GraphList);
        }
        public void AddTop(int f, int i, int j, int k)
        {
            var GraphList = new GraphElement(f, false, new GraphElement(i, false, new GraphElement(j, false, new GraphElement(k, false, null))));
            GraphsList.Add(GraphList);
        }
        public void AddTop(int f, int i, int j, int k, int l)
        {
            var GraphList = new GraphElement(f, false, new GraphElement(i, false, new GraphElement(j, false, new GraphElement(k, false, new GraphElement(l, false, null)))));
            GraphsList.Add(GraphList);
        }
        public void MadeMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows + 1, columns + 1];
            for(int i = 0; i < rows + 1; i++)
            {
                for(int j = 0; j < columns + 1; j++)
                {
                    if(i == 0)
                    {
                        matrix[i, j] = j;
                    }
                    else if(j == 0)
                    {
                        matrix[i, j] = i;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            int index = 1;
            bool top = true;
            foreach(GraphElement item in GraphsList)
            {
                int count = 0;
                GraphElement current = item;
                while(current != null)
                {
                    count++;
                    current = current.NextElement;
                }
                current = item;
                while (current != null)
                {
                    if(current != null)
                    {
                        try
                        {
                            matrix[current.Number, index] = 1;
                        }
                        catch { }
                    }
                    if(top == false)
                    {
                        if(index == count && count % 2 != 0)
                        {

                        }
                        else
                        {
                            top = true;
                            index++;
                        }
                    }
                    else
                    {
                        top = false;
                    }
                    current = current.NextElement;
                }
            }
            for (int i = 0; i < rows + 1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns + 1; j++)
                {
                    Console.Write(" " + matrix[i, j]);
                }
            }
        }
        public void FindPathDFS(int x, int y)
        {
            Checked.Add(x);
            _findPathDFS(x, y, GraphsList[x - 1]);
            _ansverDFS();
        }
        private void _findPathDFS(int x, int y, GraphElement element)
        {
            GraphElement current = element;
            bool findY = false;
            while (current != null)
            {
                if (Checked.Contains(current.Number))
                {
                    current.Check = true;
                }
                if (current.Number == y)
                {
                    findY = true;
                }
                current = current.NextElement;
            }
            current = element;
            while (current != null)
            {
                if (current.NextElement.Number == y)
                {
                    Checked.Add(current.NextElement.Number);
                    break;
                }
                else if (current != element && current.NextElement.Check == true && findY == false)
                {
                    Checked.Add(current.Number);
                    _findPathDFS(x, y, GraphsList[current.Number - 1]);
                    break;
                }
                else if (current.NextElement.NextElement == null)
                {
                    Checked.Add(current.Number);
                    current.Check = true;
                    _findPathDFS(x, y, GraphsList[current.Number - 1]);
                    break;
                }
                else
                {
                    current = current.NextElement;
                }
            }
        }
        private void _ansverDFS()
        {
            Console.Write("DFS: ");
            for(int i = 0; i < Checked.Count; i++)
            {
                Console.Write(i == Checked.Count - 1 ? $" {Checked[i]}" : $" {Checked[i]} ->");
            }
        }
        public void FindPathBFS(int x, int y)
        {
            _findPathBFS(x, y, GraphsList[x - 1]);
        }
        private void _findPathBFS(int x, int y, GraphElement element)
        {
            if (Checked.Contains(element.Number))
            {
                return;
            }
            GraphElement current = element;
            Checked.Add(current.Number);
            while(current != null)
            {
                current = current.NextElement;
                if(current != null)
                {
                    _findPathBFS(x, y, GraphsList[current.Number - 1]);
                    if (Checked.Contains(y))
                    {
                        if(Checked[Checked.Count - 1] == y)
                        {
                            _ansverBFS();
                        }
                        break;
                    }
                }
            }
            Checked.Remove(element.Number);
        }
        private void _ansverBFS()
        {
            Console.WriteLine();
            Console.Write("BFS: ");
            for (int i = 0; i < Checked.Count; i++)
            {
                Console.Write(i == Checked.Count - 1 ? $" {Checked[i]}" : $" {Checked[i]} ->");
            }
        }
    }
}
