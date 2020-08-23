using System;

namespace Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string result;
            do
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Проверка скобочной последовательности");
                Console.WriteLine("2. Перевод из инфиксной записи арифметического выражения в постфиксную");
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
            Console.Write("Введите последовательность символов со скобками ( ): ");
            s = Console.ReadLine();

            if (CheckBracket(s))
            {
                Console.WriteLine("Последовательность корректна");
            }
            else
            {
                Console.WriteLine("Последовательность некорректна");
            }
            Console.ReadKey();
        }

        private static bool CheckBracket(string s)
        {
            Stack stack = new Stack();
            char c;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        stack.Push(s[i]);
                        break;
                    case '[':
                        stack.Push(s[i]);
                        break;
                    case '{':
                        stack.Push(s[i]);
                        break;
                    case ')':
                        if (stack.Empty)
                        {
                            return false;
                        }
                        c = stack.Pop();
                        if (c != '(')
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if (stack.Empty)
                        {
                            return false;
                        }
                        c = stack.Pop();
                        if (c != '[')
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (stack.Empty)
                        {
                            return false;
                        }
                        c = stack.Pop();
                        if (c != '{')
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                } 
            }

            if (stack.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        private static void Task2()
        {
            string expressionInfix;
            Console.Write("Введите арифметическое выражение: ");
            expressionInfix = Console.ReadLine();
            string expressionPostfix = TranslateToPostfix(expressionInfix);
            Console.WriteLine($"Результат преобразования: {expressionPostfix}");
        }

        private static string TranslateToPostfix(string expressionInfix)
        {
            if (!CheckBracket(expressionInfix))
            {
                return "Ошибка расстановки скобок в выражении";
            }

            string outstring = string.Empty;
            Stack stack = new Stack();
            char c;

            for (int i = 0; i < expressionInfix.Length; i++)
            {
                switch (expressionInfix[i])
                {
                    case '(':
                        outstring += ' ';
                        stack.Push(expressionInfix[i]);
                        break;
                    case ')':
                        outstring += ' ';
                        while (!stack.Empty && stack.Top() != '(' )
                        {
                            outstring += stack.Pop();
                        }

                        if (!stack.Empty)
                        {
                            stack.Pop();
                        }
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        outstring += ' ';
                        while (!stack.Empty && Priority(expressionInfix[i], stack.Top()))
                        {
                            outstring += stack.Pop();
                            outstring += ' ';
                        }
                        stack.Push(expressionInfix[i]);
                        break;
                    default:
                        outstring += expressionInfix[i];
                        break;
                }
            }

            outstring += ' ';
            while (!stack.Empty)
            {
                outstring += stack.Pop();
                outstring += ' ';
            }

            outstring = outstring.Replace("  ", " ");

            return outstring;
        }

        private static bool Priority(char sym, char top)
        {
            int prioSym = 0, prioTop = 0;

            if (top == '*' || top == '/')
            {
                prioTop = 3;
            }
            else if (top == '+' || top == '-')
            {
                prioTop = 2;
            }
            else if (top == '(')
            {
                prioTop = 1;
            }

            if (sym == '*' || sym == '/')
            {
                prioSym = 3;
            }
            else if (sym == '+' || sym == '-')
            {
                prioSym = 2;
            }
            else if (sym == '(')
            {
                prioSym = 1;
            }

            return prioTop - prioSym >= 0 ? true : false;
        }
    }
}
