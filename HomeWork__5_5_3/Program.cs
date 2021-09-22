using System;

namespace HomeWork__5_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowHeader("Удаление повторяющихся символов");

            //string text = "ПППОООГГГООООДДДААА";
            string text = "Ххххоооорррооошшшиий деееннннь";
            string clearText = RemoveDuplicates(text);

            Console.WriteLine("Строка до обработки:");
            Console.WriteLine(text);

            Console.WriteLine();

            Console.WriteLine("Строка после обработки:");
            Console.WriteLine(clearText);

            Console.ReadKey();
        }

        /// <summary>
        /// Убирает все повторяющиеся символы в строке
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns>Строка</returns>
        static string RemoveDuplicates(string text)
        {
            string lowerCaseText = text.ToLower();
            string resultString = "";
            char prevChar = '\0';
            for (int i = 0; i < lowerCaseText.Length; i++)
            {
                if (lowerCaseText[i] != prevChar) resultString += lowerCaseText[i];
                prevChar = lowerCaseText[i];
            }

            return resultString;
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
