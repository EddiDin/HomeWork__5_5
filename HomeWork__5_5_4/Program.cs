using System;

namespace HomeWork__5_5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowHeader("Определение прогрессии");


        }

        static string isProgression(params int[] args) {
            if (args.Length < 3) return "Невозможно определить является ли последовательность прогрессией. Слишком мало чисел";

            return "";
        }

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
