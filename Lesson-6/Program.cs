using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string result;
            do
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Хеш функция");
                Console.WriteLine("2. Бинарное дерево");
                Console.WriteLine("0. Exit");

                result = Console.ReadLine();

                switch (result)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }
            } while (result != "0");
        }

        private static void Task1()
        {
            string s;
            Console.Write("Введите последовательность символов: ");
            s = Console.ReadLine();
            Console.WriteLine($"Хеш функция - {GetHash(s)}");
        }

        private static string GetHash(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sum += s[i];
            }

            return sum.ToString();
        }

        private static void Task2()
        {

        }
    }
}