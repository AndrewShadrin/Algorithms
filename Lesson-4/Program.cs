using System;
using System.Drawing;

namespace Lesson_4
{
    class Program
    {
        const int n = 6;
        const int m = 6;

        static Size[] steps = new Size[8] { new Size(-2, -1), new Size(-1, -2), new Size(1, -2), new Size(2, -1), new Size(2, 1), new Size(1, 2), new Size(-1, 2), new Size(-2, 1) };

        static void Main(string[] args)
        {
            int[,] table = new int[n, m];
            ClearTable(ref table);

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    ClearTable(ref table);
                    if (NextStep(1, new Point(i,j), ref table))
                    {
                        PrintTable("Решение найдено", table);
                    }
                }
            }
            Console.WriteLine("Больше решений нет");
            Console.ReadKey();
        }

        private static void PrintTable(string mess, int[,] table)
        {
            Console.WriteLine($"\n{mess}");
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write($"\t{table[i,j]}");
                }
                Console.WriteLine();
            }

        }

        private static bool NextStep(int count, Point point, ref int[,] table)
        {

            table[point.X, point.Y] = count;
            if (count != table.Length)
            {
                foreach (Size step in steps)
                {
                    Point newPoint = point + step;
                    if (CheckPoint(newPoint, table))
                    {
                        if (NextStep(count + 1, newPoint, ref table))
                        {
                            return true;
                        }
                        table[newPoint.X, newPoint.Y] = 0;
                    }
                }
                return false;
            }
            else
            {
                Console.WriteLine("---------------");
                return true;
            }
        }

        private static bool CheckPoint(Point point, int[,] table)
        {
            if ((point.X >= 0) && (point.Y >= 0) && (point.X < table.GetLength(0)) && (point.Y < table.GetLength(1)) && (table[point.X, point.Y] == 0))
            {
                return true;
            }
            return false;
        }

        private static void ClearTable(ref int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = 0;
                }
            }
        }
    }

}
