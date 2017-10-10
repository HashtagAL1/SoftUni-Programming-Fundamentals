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

        public static void ReversedNoNegative()
        {

            string[] input = Console.ReadLine().Split(' ');
            List<int> nums = new List<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(input[i]);
                if (n >= 0)
                {
                    nums.Add(n);
                }
            }
            if (nums.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    Console.Write(nums[i] + " ");
                }
            }
            Console.WriteLine();
        }

        public static void AppendLists()
        {

            string[] input = Console.ReadLine().Split('|');
            List<char> nums = new List<char>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                string line = input[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j].Equals(' '))
                    {
                        continue;
                    }
                    else
                    {
                        nums.Add(line[j]);
                    }
                }

            }

            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }

        public static int SumTwoNumbers(List<decimal> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i + 1] += nums[i];
                    nums.Remove(nums[i]);
                    return 1;
                }
            }
            return 0;
        }

        public static void PrintDecimalList(List<decimal> nums)
        {

            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }

        public static void SumAdhacentEqualNumbers()
        {
            string[] input = Console.ReadLine().Split(' ');
            List<decimal> nums = new List<decimal>();
            for (int i = 0; i < input.Length; i++)
            {
                nums.Add(decimal.Parse(input[i]));
            }
            int res = SumTwoNumbers(nums);
            while (res > 0)
            {
                res = SumTwoNumbers(nums);
            }

            PrintDecimalList(nums);
        }

        public static bool IsLowerCase(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] < 'a' || line[i] > 'z')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsUpperCase(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] < 'A' || line[i] > 'Z')
                {
                    return false;
                }
            }
            return true;
        }

        public static void PrintStringList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    Console.Write($"{list[i]}");
                }
                else
                {
                    Console.Write($"{list[i]}, ");
                }

            }
            Console.WriteLine();
        }

        public static void SplitWordsByCasing()
        {
            string[] input = Console.ReadLine().Split(new char[] { '.', ',', ';', ':', '!', ')', ' ',
                '(', '"', '\'', '\\', '/', '[', ']', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> lowerCase = new List<string>();
            List<string> upperCase = new List<string>();
            List<string> mixedCase = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                if (IsUpperCase(line))
                {
                    upperCase.Add(input[i]);
                }
                else if (IsLowerCase(line))
                {
                    lowerCase.Add(input[i]);
                }
                else
                {
                    mixedCase.Add(input[i]);
                }
            }
            Console.Write("Lower-case: ");
            PrintStringList(lowerCase);
            Console.Write("Mixed-case: ");
            PrintStringList(mixedCase);
            Console.Write("Upper-case: ");
            PrintStringList(upperCase);
        }

        public static List<decimal> ReadDecimalList()
        {
            List<decimal> result = new List<decimal>();
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                result.Add(decimal.Parse(input[i]));
            }
            return result;
        }

        public static void BubbleSort(List<int> list)
        {
            for (int j = 0; j < list.Count; j++)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        int temp = list[i + 1];
                        list[i + 1] = list[i];
                        list[i] = temp;
                    }
                }
            }
        }

        public static void SortNumbers()
        {
            List<decimal> numbers = ReadDecimalList();
            //BubbleSort(numbers);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == numbers.Count - 1)
                {
                    Console.WriteLine(numbers[i]);

                }
                else
                {
                    Console.Write(numbers[i] + " <= ");

                }
            }
        }
        public static List<int> ReadIntList()
        {
            List<int> result = new List<int>();
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                result.Add(int.Parse(input[i]));
            }
            return result;
        }

        public static bool IsSquare(int num)
        {
            if (Math.Sqrt(num) == (int)Math.Sqrt(num))
            {
                return true;
            }
            return false;
        }

        public static void PrintIntList(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }

        public static void SquareNumbers()
        {
            List<int> nums = ReadIntList();
            for (int i = 0; i < nums.Count; i++)
            {
                if (!(IsSquare(nums[i])))
                {
                    nums.Remove(nums[i]);
                    i--;
                }
            }
            BubbleSort(nums);
            for (int i = nums.Count - 1; i >= 0; i--)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }

        public static void GetRepeatingNumbers()
        {
            List<int> numbers = ReadIntList();
            BubbleSort(numbers);
            int cnt = 1;
            for (int i = 0; i < numbers.Count - 1; i++)
            {

                if (numbers[i] == numbers[i + 1])
                {
                    cnt++;
                }
                else
                {
                    Console.WriteLine($"{numbers[i]} -> {cnt}");
                    cnt = 1;
                }
            }

            Console.WriteLine($"{numbers[numbers.Count - 1]} -> {cnt}");
        }

        
        
        



           


    }
}
