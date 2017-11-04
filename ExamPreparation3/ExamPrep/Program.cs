using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static List<char> AddSymbols(string input)
        {
            List<char> res = new List<char>();
            foreach (Match m in Regex.Matches(input, @"([^0-9]+)+"))
            {
                char[] arr = m.Value.ToLower().ToCharArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    res.Add(arr[i]);
                }
            }
            res = res.Distinct().ToList();
            return res;
        }

        public static List<string> Sort(List<string> list, int count, int startIndex)
        {
            if (startIndex == 0)
            {
                List<string> temp = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    temp.Add(list[i]);
                }
                temp.Sort();
                list.RemoveRange(0, count);
                temp = temp.Concat(list).ToList();
                return temp;
            }
            else
            {
                List<string> temp = new List<string>();
                List<string> before = new List<string>();
                List<string> after = new List<string>();
                for (int i = 0; i < startIndex; i++)
                {
                    before.Add(list[i]);
                }
                for (int i = startIndex; i < startIndex + count; i++)
                {
                    temp.Add(list[i]);
                }
                for (int i = startIndex + count; i < list.Count; i++)
                {
                    after.Add(list[i]);
                }
                temp.Sort();
                before = before.Concat(temp).ToList();
                before = before.Concat(after).ToList();
                return before;
            }
        }

        public static List<string> Reverse(List<string> list, int count, int startindex)
        {
            List<string> temp = new List<string>();
            if (startindex == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    temp.Add(list[i]);
                }
                list.RemoveRange(0, count);
                temp.Reverse();
                temp = temp.Concat(list).ToList();
                return temp;
            }
            else
            {
                List<string> before = new List<string>();
                List<string> after = new List<string>();
                for (int i = 0; i < startindex; i++)
                {
                    before.Add(list[i]);
                }
                for (int i = startindex; i < startindex + count; i++)
                {
                    temp.Add(list[i]);
                }
                for (int i = startindex + count; i < list.Count; i++)
                {
                    after.Add(list[i]);
                }
                temp.Reverse();
                before = before.Concat(temp).ToList();
                before = before.Concat(after).ToList();
                return before;
            }
        }

        public static void RollLeft(List<string> list, int count)
        {
            if (count >= list.Count)
            {
                count = count % list.Count;
            }
            for (int i = 0; i < count; i++)
            {
                list.Add(list[i]);
            }
            list.RemoveRange(0, count);
        }

        public static void RollRight(List<string> list, int count)
        {
            if (count >= list.Count)
            {
                count = count % list.Count;
            }
            for (int i = list.Count - count; i < list.Count; i++)
            {
                list.Insert(0, list[i]);
                i++;
            }
            list.RemoveRange(list.Count - count, count);
        }

        public static void CoffeeOrders()
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal totalPrice = 0m;
            for (decimal i = 0; i < n; i++)
            {
                decimal pricePerCaps = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                decimal capsules = decimal.Parse(Console.ReadLine());
                decimal price = (DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * capsules) * pricePerCaps;
                totalPrice += price;
                Console.WriteLine("The price for the coffee is: ${0:F2}", price);
            }
            Console.WriteLine("Total: ${0:F2}", totalPrice);
        }

        public static void CommandInterpreter()
        {
            List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (!(command.Equals("end")))
            {
                string[] info = command.Split(' ');
                if (info[0].Equals("rollLeft"))
                {
                    int count = int.Parse(info[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    RollLeft(input, count);
                }
                else if (info[0].Equals("rollRight"))
                {

                    int count = int.Parse(info[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    RollRight(input, count);
                }
                else if (info[0].Equals("sort"))
                {
                    int startIndex = int.Parse(info[2]);
                    int count = int.Parse(info[4]);
                    if (startIndex < 0 || (startIndex + count > input.Count) || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (startIndex == input.Count - 1)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    input = Sort(input, count, startIndex);

                }
                else if (info[0].Equals("reverse"))
                {
                    int startIndex = int.Parse(info[2]);
                    int count = int.Parse(info[4]);
                    if (startIndex < 0 || (startIndex + count > input.Count) || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (startIndex == input.Count - 1)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    input = Reverse(input, count, startIndex);
                }
                else
                {
                    Console.WriteLine("Invalid input parameters.");
                }


                command = Console.ReadLine();
            }
            Console.Write('[');
            Console.Write(string.Join(", ", input));
            Console.WriteLine(']');
        }

        public static void RageQuit()
        {
            string input = Console.ReadLine();
            List<string> elements = new List<string>();
            List<uint> times = new List<uint>();
            StringBuilder res = new StringBuilder();
            foreach (Match m in Regex.Matches(input, @"[^0-9]+"))
            {
                elements.Add(m.Value.ToUpper());
            }
            foreach (Match m in Regex.Matches(input, @"[0-9]+"))
            {
                times.Add(uint.Parse(m.Value));
            }
            for (int i = 0; i < elements.Count; i++)
            {
                for (int j = 0; j < times[i]; j++)
                {
                    res.Append(elements[i]);
                }
            }
            List<char> symbols = AddSymbols(input);
            Console.WriteLine("Unique symbols used: " + symbols.Count);
            Console.WriteLine(res.ToString());
        }

        public static void Files()
        {
            List<string> inputs = new List<string>();
            var folderFiles = new Dictionary<string, List<string>>();
            var fileSize = new Dictionary<string, long>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                inputs.Add(Console.ReadLine());
            }
            string[] target = Console.ReadLine().Split(' ');
            string folder = target[2];
            string ext = target[0];
            folderFiles[folder] = new List<string>();
            string folderPattern = $@"{folder}(\\.*\\)?";

            for (int i = 0; i < inputs.Count; i++)
            {
                if (Regex.IsMatch(inputs[i], folderPattern))
                {
                    int last = inputs[i].LastIndexOf('\\');
                    string[] fileInfo = inputs[i].Substring(last + 1).Split(';');
                    string file = fileInfo[0];
                    long size = long.Parse(fileInfo[1]);
                    if (file.EndsWith($".{ext}"))
                    {
                        fileSize[file] = size;
                    }

                }
                else
                {
                    continue;
                }
            }
            fileSize = fileSize.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            if (fileSize.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            foreach (var file in fileSize.Keys)
            {
                Console.WriteLine($"{file} - {fileSize[file]} KB");
            }
        }
    }
}
