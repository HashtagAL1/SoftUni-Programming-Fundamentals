using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string GetReversedString(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i > -1; i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }

        public static void NumberOfStringOccurances()
        {
            string text = Console.ReadLine().ToLower();
            string target = Console.ReadLine().ToLower();
            int cnt = 0;
            int index = -1;
            while (true)
            {
                index = text.IndexOf(target, index + 1);
                if (index == -1)
                {
                    break;
                }
                cnt++;

            }
            Console.WriteLine(cnt);
        }

        public static void ReplaceBannedWords()
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }
            Console.WriteLine(text);
        }

        public static void GetPalindromes()
        {
            string[] text = Console.ReadLine().Split(new char[] { '.', ',', '-', '!', '?', ' ', ';', ':', '(', ')', '\'', '"' }
            , StringSplitOptions.RemoveEmptyEntries);
            List<string> palindromes = new List<string>();

            foreach (var word in text)
            {
                if (word.CompareTo(GetReversedString(word)) == 0)
                {
                    palindromes.Add(word);
                }
            }
            palindromes = palindromes.Distinct().OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ", palindromes));
        }
    }
}
