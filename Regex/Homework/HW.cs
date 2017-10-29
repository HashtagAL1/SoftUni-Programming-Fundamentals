using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Homework
{
    class HW
    {
        static void Main(string[] args)
        {

        }

        public static string DecryptWord(string word)
        {
            StringBuilder sb = new StringBuilder();
            char[] arr = word.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 'a' && arr[i] <= 'm')
                {
                    arr[i] = (char)((int)arr[i] + 13);
                }
                else if (arr[i] >= 'n' && arr[i] <= 'z')
                {
                    arr[i] = (char)((int)arr[i] - 13);
                }
                sb.Append(arr[i]);
            }
            return sb.ToString();
        }
        
        public static void QueryMess()
        {
            string input = Console.ReadLine();

            while (!(input.Equals("END")))
            {
                if (input.Contains('?'))
                {
                    input = input.Substring(input.LastIndexOf('?') + 1);
                }

                string[] fieldValuePairs = input.Split('&');
                var res = new Dictionary<string, List<string>>();

                for (int i = 0; i < fieldValuePairs.Length; i++)
                {
                    fieldValuePairs[i] = Regex.Replace(fieldValuePairs[i], @"(%20|\+)+", " ");
                    string field = Regex.Match(fieldValuePairs[i], @".*(?=\=)").Value.Trim();
                    string value = Regex.Match(fieldValuePairs[i], @"(?<=\=).*").Value.Trim();
                    if (!(res.ContainsKey(field)))
                    {
                        res[field] = new List<string>();
                    }
                    res[field].Add(value.Trim());
                }
                foreach (var field in res.Keys)
                {
                    Console.Write(field + "=[");
                    Console.Write(string.Join(", ", res[field]));
                    Console.Write(']');
                }
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
        
        public static void ExtractEmails()
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=\s)([A-Za-z0-9]+[\-\.\w+]?)+@[A-Za-z0-9]+[\-]?\w+(\.\w+)+";

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine(m.Value);
            }
        }

        public static void ExtractSentencesByKeyword()
        {
            string keyword = Console.ReadLine();
            string input = Console.ReadLine();
            string[] sentences = Regex.Split(input, @"[\.\!\?]");
            Regex regex = new Regex(@"\b" + keyword + @"\b");

            for (int i = 0; i < sentences.Length; i++)
            {
                if (regex.IsMatch(sentences[i]))
                {
                    Console.WriteLine(sentences[i].Trim());
                }
            }
        }

        public static void ValidUsernames()
        {
            var res = new Dictionary<uint, List<string>>();
            List<string> validUsernames = new List<string>();
            string[] usernames = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"(\b[A-Za-z]\w{2,24}\b)";
            Regex regex = new Regex(pattern);
            uint maxSum = 0;

            for (int i = 0; i < usernames.Length; i++)
            {
                if (regex.IsMatch(usernames[i]))
                {
                    validUsernames.Add(regex.Match(usernames[i]).Value);
                }
            }

            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                uint sum = (uint)validUsernames[i].Length + (uint)validUsernames[i + 1].Length;
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
                if (res.ContainsKey(sum))
                {
                    continue;
                }
                res[sum] = new List<string>();
                res[sum].Add(validUsernames[i]);
                res[sum].Add(validUsernames[i + 1]);
            }

            for (int i = 0; i < res[maxSum].Count; i++)
            {
                Console.WriteLine(res[maxSum][i]);
            }
        }

        public static void Weather()
        {
            var cityTemp = new Dictionary<string, double>();
            var cityWeather = new Dictionary<string, string>();
            Regex regex = new Regex(@"(?<city>[A-Z]{2})(?<number>\d+\.\d+)(?<weather>[A-Za-z]+(?=\|))");
            string input = Console.ReadLine();
            while (!(input.Equals("end")))
            {
                if (!(regex.IsMatch(input)))
                {
                    input = Console.ReadLine();
                    continue;
                }

                Match match = regex.Match(input);
                string city = match.Groups["city"].Value;
                double temp = double.Parse(match.Groups["number"].Value);
                string weather = match.Groups["weather"].Value;

                cityTemp[city] = temp;
                cityWeather[city] = weather;

                input = Console.ReadLine();
            }


            var final = cityTemp.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var city in final.Keys)
            {
                Console.WriteLine("{0} => {1:F2} => {2}", city, final[city], cityWeather[city]);
            }
        }

        public static void CameraViews()
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int skip = nums[0];
            int take = nums[1];
            string input = Console.ReadLine();
            List<string> cameras = new List<string>();

            foreach (Match m in Regex.Matches(input, @"\|<\w+"))
            {
                cameras.Add(m.Value);
            }

            for (int i = 0; i < cameras.Count; i++)
            {
                string view = string.Join("", cameras[i].Skip(skip + 2).Take(take).ToList());
                cameras[i] = view;
            }

            Console.WriteLine(string.Join(", ", cameras));
        }

        public static void KeyReplacer()
        {
            string target = Console.ReadLine();
            string input = Console.ReadLine();
            string start = Regex.Match(target, @"^[A-Za-z]+(?=[\|\<\\])").Value;
            string end = Regex.Match(target, @"(?<=[\|\<\\])[A-Za-z]+$").Value;
            string pattern = $@"(?<={start}).*?(?={end})";
            StringBuilder sb = new StringBuilder();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                sb.Append(m.Value);
            }

            if (sb.ToString().Length == 0)
            {
                Console.WriteLine("Empty result");
            }
            else
                Console.WriteLine(sb.ToString());
        }

        public static void UseChains()
        {
            string input = Console.ReadLine();
            List<string> valuableText = new List<string>();

            foreach (Match m in Regex.Matches(input, @"<p>.*?<\/p>"))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 3; i < m.Value.Length - 4; i++)
                {
                    sb.Append(m.Value[i]);
                }
                string actualText = sb.ToString();
                actualText = Regex.Replace(actualText, @"[^a-z0-9]", " ");
                actualText = DecryptWord(actualText);
                actualText = Regex.Replace(actualText, @"\s+", " ");
                valuableText.Add(actualText);
            }

            Console.WriteLine(string.Join("", valuableText));
        }
        
    }
}
