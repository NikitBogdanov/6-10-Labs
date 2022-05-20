using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы:");
            int Line = Convert.ToInt32(Console.ReadLine());
            int Column = Convert.ToInt32(Console.ReadLine());
            int[,] MatrixRoad = new int[Line, Column];
            Random random = new Random();
            for(int i = 0; i < Line; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    int temp = random.Next(45, 150);
                    MatrixRoad[i, j] = temp < 50 ? -1 : temp;
                }
            }
            for (int i = 0; i < Line; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Column; j++)
                {
                    Console.Write("\t" + MatrixRoad[i, j]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Введите номер города: ");
            int City = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int CurrentCity = 0;
            int Summ = 0;
            int index = 1;
            Console.WriteLine("Все номера городов, сумарное расстояние между которыми не превышает 200 км:");
            for(int i = 0; i < Column; i++)
            {
                CurrentCity = i;
                if (MatrixRoad[City, CurrentCity] != -1)
                    Summ = MatrixRoad[City, CurrentCity];
                Console.WriteLine();
                if(MatrixRoad[City, CurrentCity] != -1)
                    Console.Write("\t" + CurrentCity);
                for (int j = index; j < Column; j++)
                {
                    if(Summ + MatrixRoad[City, j] <= 200)
                    {
                        if (MatrixRoad[City, j] != -1)
                            Console.Write("\t" + j);
                        Summ += MatrixRoad[City, j];
                    }
                }
                index++;
                if(index < Column - 1)
                {
                    i--;
                }
                else
                {
                    index = CurrentCity + 2;
                }
            }
            Console.ReadLine();
        }
    }
}
