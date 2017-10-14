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

        public static void NumberAppearances()
        {
            double[] nums = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var result = new SortedDictionary<double, int>();

            foreach (var number in nums)
            {
                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result[number] = 1;
                }
            }
            foreach (var num in result.Keys)
            {
                Console.WriteLine($"{num} -> {result[num]}");
            }
        }

        public static void OddOccurances()
        {
            string[] input = Console.ReadLine().ToLower().Split(' ');
            var result = new Dictionary<string, int>();

            foreach (var str in input)
            {
                if (result.ContainsKey(str))
                {
                    result[str]++;
                }
                else
                {
                    result[str] = 1;
                }
            }
            string output = "";
            foreach (var item in result.Keys)
            {
                if (result[item] % 2 != 0)
                {
                    if (output.Length == 0)
                    {
                        output += item;
                    }
                    else
                    {
                        output += ", " + item;
                    }
                }
            }
            Console.WriteLine(output);
        }

        public static void Lambdas()
        {
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Sum = {arr.Sum()}");
            Console.WriteLine($"Min = {arr.Min()}");
            Console.WriteLine($"Max = {arr.Max()}");
            Console.WriteLine($"Average = {arr.Average()}");
        }

        public static void Largest3Numbers()
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToList()
                .Take(3)));
        }

        public static void WordsSorted()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(new char[] { ' ', ',', '.',
                ':', ';', '[', ']', '(', ')', '\'','"', '\\', '/', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length < 5).Select(s => s.ToLower()).OrderBy(s => s).Distinct().ToList()));
        }

        public static void FoldAndSum()
        {
            var input = Console.ReadLine().Split(' ').ToList();
            if (input.Count == 1)
            {
                Console.WriteLine(input[0]);
                return;
            }
            var left = input.Take(input.Count / 4).ToList();
            var mid = input.Skip(input.Count / 4).Take(input.Count / 2).ToList();
            var right = input.Skip(input.Count / 4 + input.Count / 2).Take(input.Count / 4).ToList();
            left.Reverse();
            right.Reverse();
            left = left.Concat(right).ToList();
            var sum = left.Select((x, index) => int.Parse(x) + int.Parse(mid[index])).ToList();
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
