using System;
using System.Collections.Generic;

namespace HomeWork__5_5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowHeader("Определение прогрессии");

            int[] sequence = EnterSequence();

            Console.WriteLine("Введенная последовательность:");
            Console.WriteLine(string.Join(',', sequence));

            string result = isProgression(sequence);
            Console.WriteLine();
            Console.WriteLine(result);

            Console.ReadKey();
        }

        /// <summary>
        /// Ввод последовательности
        /// </summary>
        /// <returns>Массив чисел</returns>
        static int[] EnterSequence()
        {
            Console.WriteLine("Введите последовательность чисел через пробел:");
            string userInput = Console.ReadLine();
            List<int> sequence = GetNumbersFromString(userInput);

            return sequence.ToArray();
        }

        /// <summary>
        /// Получение чисел из строки (разделитель пробел)
        /// </summary>
        /// <param name="text">Произвольная строка</param>
        /// <returns>Коллекция чисел</returns>
        static List<int> GetNumbersFromString(string text)
        {
            List<int> numbers = new List<int>();
            System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(text, @"([0-9-]+)");
            foreach (System.Text.RegularExpressions.Match match in matches) numbers.Add(Int32.Parse(match.Value));

            return numbers;
        }

        /// <summary>
        /// Определяет, является ли последовательность переданных аргументов прогрессией
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Сообщение с результатом</returns>
        static string isProgression(params int[] args)
        {
            if (args.Length < 3) return "Невозможно определить является ли последовательность прогрессией. Слишком мало чисел.";

            int divider = args[1] / args[0];
            bool isGeometry = true;
            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0 || i == 1) continue;
                if (args[i] / divider != args[i - 1])
                {
                    isGeometry = false;
                    break;
                }
            }

            if (isGeometry) return "Введенная последовательноть является геометрической.";

            int difference = args[1] - args[0];
            bool isArithmetic = true;
            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0 || i == 1) continue;
                if (args[i] - difference != args[i - 1])
                {
                    isArithmetic = false;
                    break;
                }
            }

            if (isArithmetic) return "Введенная последовательноть является арифметической.";

            return "Введенная последовательность не является прогрессией";
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
