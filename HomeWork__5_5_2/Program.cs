using System;
using System.Collections.Generic;

namespace HomeWork__5_5_2
{
    class TextToWords
    {
        static readonly string regExpPattern = @"([A-Za-zА-Яа-я0-9-]+)";

        static void Main(string[] args)
        {
            ShowHeader("Работа с текстом");

            //string text = EnterText();
            string text = "!слово1 слова2 сл3 когда-нибудь4 !№когда-нибудь5";

            string minLengthWord = GetMinLengthWord(text);
            List<string> maxLengthWords = GetMaxLengthWords(text);

            Console.WriteLine($"Исходный текст: {text}");

            Console.WriteLine();

            Console.WriteLine($"Слово с минимальной длиной: {minLengthWord}");

            Console.WriteLine();

            Console.WriteLine($"Слова с максимальной длиной: {string.Join(',', maxLengthWords)}");

            Console.ReadKey();
        }

        static string EnterText()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        static string GetMinLengthWord(string text)
        {
            List<string> Words = GetWordsFromText(text);
            Words.Sort(CompareByLength);

            return Words[0];
        }

        static List<string> GetMaxLengthWords(string text)
        {
            List<string> Words = GetWordsFromText(text);
            Words.Sort(CompareByLength);
            Words.Reverse();

            int maxLength = Words[0].Length;
            List<string> filteredWordsList = new List<string>();

            foreach (string word in Words)
            {
                if (word.Length == maxLength) filteredWordsList.Add(word);
            }

            return filteredWordsList;
        }

        static List<string> GetWordsFromText(string text)
        {
            List<string> Words = new List<string>();
            System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(text, regExpPattern);
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                Words.Add(match.Value);
            }

            return Words;
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

        static int CompareByLength(string x, string y)
        {
            if (x.Length > y.Length) return 1;
            if (x.Length < y.Length) return -1;
            return 0;
        }
    }
}
