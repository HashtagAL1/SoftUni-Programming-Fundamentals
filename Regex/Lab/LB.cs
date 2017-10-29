using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab
{
    class LB
    {
        static void Main(string[] args)
        {
        }

        public static void MatchFullName()
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.Write(m.Value + " ");
            }
        }

        public static void MatchPhoneNumber()
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(-|\s)2\1\d{3}\1\d{4}\b";
            List<string> numbers = new List<string>();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                numbers.Add(m.Value.Trim());
            }
            numbers = numbers.ToList();

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static void MatchHexNumbers()
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";
            List<string> res = new List<string>();
            foreach (Match m in Regex.Matches(input, pattern))
            {
                res.Add(m.Value.Trim());
            }
            Console.WriteLine(string.Join(" ", res));
        }

        public static void MatchDates()
        {
            string input = Console.ReadLine();
            string pattern = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            foreach (Match m in Regex.Matches(input, pattern))
            {
                var day = m.Groups["day"].Value;
                var month = m.Groups["month"].Value;
                var year = m.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }

        public static void MatchNumbers()
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.Write(m.Value + " ");
            }
        }
    }
}
