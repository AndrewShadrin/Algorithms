// 1.Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и не оптимизированной программы. 
//   Написать функции сортировки, которые возвращают количество операций.
// 2. *Реализовать шейкерную сортировку.
// 3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив. Функция возвращает индекс найденного элемента или -1, если элемент не найден.
// 4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.
using System;

namespace Lesson_4
{
    class Program
    {
        const int min = 0;
        const int max = 100;
        const int length = 20;

        static void Main(string[] args)
        {
            string result;
            do
            {
                Console.WriteLine("\n1. Пузырьковая сортировка");
                Console.WriteLine("2. Шейкерная сортировка");
                Console.WriteLine("3. Бинарный поиск");
                Console.WriteLine("0. Exit");

                result = Console.ReadLine();

                switch (result)
                {
                    case "1":
                        BubleSort();
                        break;
                    case "2":
                        ShakerSort();
                        break;
                    case "3":
                        Console.Write("Введите число для поиска: ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        int[] arr = GetArray(50);
                        ShakerSortArray(ref arr);
                        PrintArray("Массив", arr);
                        int res = BinarySearch(arr, number);
                        Console.WriteLine($"\nРезультат поиска: {(res == -1 ? "Не найдено" : $"Элемент с номером {res}")}");
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }
            } while (result != "0");
        }

        private static int[] GetArray(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException("Неправильный размер массива");
            }

            int[] arr = new int[size];

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = random.Next(min, max);
            }

            return arr;
        }

        private static int BinarySearch(int[] arr, int x)
        {
            int l = 0, r = arr.Length-1, m = 0;
            while (l <= r && arr[m] != x)
            {
                m = (l + r) / 2;
                if (arr[m] < x)
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }

            if (arr[m] == x)
            {
                return m;
            }

            return -1;
        }

        private static void ShakerSort()
        {
            int[] arr = GetArray(length);
            PrintArray("Исходный массив", arr);
            int res = ShakerSortArray(ref arr);
            PrintArray($"Сортированный массив за {res} ходов", arr);
        }

        private static int ShakerSortArray(ref int[] arr)
        {
            int count = 0;
            int l = 0, r = 1;
            while (l < arr.Length - r)
            {
                count++;
                count += BubbleUp(ref arr, l, r);
                r++;
                count += BubbleDown(ref arr, l, r);
                l++;
            }

            return count;
        }

        private static void BubleSort()
        {
            int[] arr = GetArray(length);
            PrintArray("Исходный массив", arr);
            int res = BubbleSortArray(ref arr);
            PrintArray($"Сортированный массив за {res} ходов", arr);

        }
        
        private static int BubbleSortArray(ref int[] arr)
        {
            int count = 0;
            for (int j = 1; j < arr.Length; j++)
            {
                count += BubbleUp(ref arr, 0, j);
            }

            return count;
        }

        private static int BubbleUp(ref int[] arr, int left, int right)
        {
            int count = 0;
            
            for (int i = left; i < arr.Length - right; i++)
            {
                count++;
                if (arr[i] > arr[i + 1])
                {
                    count++;
                    SwapInt(ref arr[i], ref arr[i + 1]);
                }
            }

            return count;
        }

        private static int BubbleDown(ref int[] arr, int left, int right)
        {
            int count = 0;

            for (int i = arr.Length - right; i > left; i--)
            {
                count++;
                if (arr[i] < arr[i - 1])
                {
                    count++;
                    SwapInt(ref arr[i], ref arr[i - 1]);
                }
            }

            return count;
        }

        private static int SwapInt(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;

            return 3;
        }

        private static void PrintArray(string mess, int[] arr)
        {
            Console.WriteLine($"\n{mess}");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"\t{arr[i]}");
            }
        }

    }

}
