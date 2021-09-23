using System;
using System.Collections.Generic;

namespace HomeWork__5_5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowHeader("Функция Аккермана");

            Console.WriteLine("Введите первое число для функции:");
            int firstNumber = EnterNumber();

            Console.WriteLine("Введите второе число для функции:");
            int secondNumber = EnterNumber();

            Console.WriteLine();
            Console.WriteLine($"Попытка расчета функции Аккермана для чисел {firstNumber}, {secondNumber} с помощью стека ...");

            int result = AckermanStack(firstNumber, secondNumber);
            Console.WriteLine($"Результат = {result}");

            Console.WriteLine();
            Console.WriteLine($"Попытка расчета функции Аккермана для чисел {firstNumber}, {secondNumber} рекурсивно ...");

            result = AckermannRecursion(firstNumber, secondNumber);
            Console.WriteLine($"Результат = {result}");

            Console.ReadKey();
        }

        /// <summary>
        /// Функция Аккермана (рекурсия)
        /// </summary>
        /// <param name="m">Число</param>
        /// <param name="n">Число</param>
        /// <returns>Число</returns>
        static int AckermannRecursion(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if (m != 0 && n == 0)
            {
                return AckermannRecursion(m - 1, 1);
            }
            else
            {
                return AckermannRecursion(m - 1, AckermannRecursion(m, n - 1));
            }
        }

        static int AckermanStack(int m, int n) {
            Stack<int> stack = new Stack<int>();
            stack.Push(m);
            while (stack.Count != 0)
            {
                m = stack.Pop();
                if (m == 0 || n == 0)
                    n += m + 1;
                else
                {
                    stack.Push(--m);
                    stack.Push(++m);
                    n--;
                }
            }

            return n;
        }

        /// <summary>
        /// Ввод неотрицательного числа с клавиатуры
        /// </summary>
        /// <returns>Неотрицательное число</returns>
        static int EnterNumber()
        {
            bool successEnter = false;

            while (!successEnter)
            {
                string userInput = Console.ReadLine();
                bool successParse = SByte.TryParse(userInput, out sbyte number);
                if (!successParse)
                {
                    Console.WriteLine("Необходимо ввести число.");
                    continue;
                }

                if (number < 0)
                {
                    Console.WriteLine("Число должно быть не отрицательным.");
                    continue;
                }

                return number;
            }

            return 0;
        }

        /// <summary>
        /// Вывод заголовка в консоль
        /// </summary>
        /// <param name="message">Заголовок</param>
        static void ShowHeader(string message)
        {
            string divider = "----------------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
            Console.WriteLine(message);
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine();
        }
    }
}
