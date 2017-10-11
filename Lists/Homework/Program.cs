using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public static List<int> ReadIntList()
        {
            string[] input = Console.ReadLine().Split(' ');
            List<int> nums = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                nums.Add(int.Parse(input[i]));
            }
            return nums;

        }

        public static List<int> ReadListFromArray(int[] arr)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
            return list;
        }

        public static bool IsEven(int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public static void PrintMaxSeqEqualNumbers()
        {
            List<int> nums = ReadIntList();
            int bestStart = 0;
            int bestLength = 0;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                int cnt = 1;

                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        cnt++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (cnt > bestLength)
                {
                    bestLength = cnt;
                    bestStart = i;
                }

            }
            for (int i = bestStart; i < bestLength + bestStart; i++)
            {
                Console.Write("{0} ", nums[i]);
            }
            Console.WriteLine();
        }

        public static void PrintEvenElements(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (IsEven(nums[i]))
                {
                    Console.Write(nums[i] + " ");
                }
            }
        }
        

        public static void PrintOddElements(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (!IsEven(nums[i]))
                {
                    Console.Write(nums[i] + " ");
                }
            }
        }

        public static void DeleteElement(List<int> nums, int element)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == element)
                {
                    nums.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void InsertElement(List<int> nums, int element, int index)
        {
            nums.Add(nums[nums.Count - 1]);
            for (int i = nums.Count - 3; i >= index; i--)
            {
                nums[i + 1] = nums[i];
            }
            nums[index] = element;
        }

        public static void ChangeList()
        {
            List<int> nums = ReadIntList();
            string[] input = Console.ReadLine().Split(' ');
            while (!(input[0].Equals("Odd")) && !(input[0].Equals("Even")))
            {
                if (input[0].Equals("Delete"))
                {
                    DeleteElement(nums, int.Parse(input[1]));
                }
                if (input[0].Equals("Insert"))
                {
                    InsertElement(nums, int.Parse(input[1]), int.Parse(input[2]));
                }

                input = Console.ReadLine().Split(' ');
            }
            if (input[0].Equals("Odd"))
            {
                PrintOddElements(nums);
            }
            else
            {
                PrintEvenElements(nums);
            }
            Console.WriteLine();
        }

        public static void SearchForANumber()
        {
            List<int> nums = ReadIntList();
            string[] secondLineInput = Console.ReadLine().Split(' ');
            int[] sInput = new int[3];
            for (int i = 0; i < 3; i++)
            {
                sInput[i] = int.Parse(secondLineInput[i]);
            }

            nums.RemoveRange(sInput[0], nums.Count - sInput[0]);
            nums.RemoveRange(0, sInput[1]);
            if (nums.Contains(sInput[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }

        public static int GetSumOfListElements(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        public static int ReverseNumber(int num)
        {
            int rev = 0;
            while (num > 0)
            {
                rev = rev * 10 + num % 10;
                num /= 10;
            }
            return rev;
        }

        public static void SumReversedNumbers()
        {
            List<int> nums = new List<int>();
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < input.Length; i++)
            {
                nums.Add(int.Parse(input[i]));
            }
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i] = ReverseNumber(nums[i]);
            }
            Console.WriteLine(GetSumOfListElements(nums));
        }

        public static void BombNumbers()
        {
            List<int> nums = ReadIntList();
            string[] specialNumber = Console.ReadLine().Split(' ');
            int power = int.Parse(specialNumber[1]);
            int number = int.Parse(specialNumber[0]);

            while (nums.Contains(number))
            {
                for (int i = nums.IndexOf(number) - power, j = 0; j < power; i++)
                {
                    if (i < 0)
                    {
                        j++;
                        continue;
                    }

                    nums.Remove(nums[i]);
                    i--;
                    j++;
                }
                for (int i = nums.IndexOf(number) + 1, j = 0; j < power; i++)
                {
                    if (i >= nums.Count)
                    {
                        i -= 2;
                        j++;
                        continue;
                    }
                    nums.Remove(nums[i]);
                    i--;
                    j++;
                }
                if (nums.Count > 0)
                {
                    nums.RemoveAt(nums.IndexOf(number));
                }
            }
            if (nums.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine(nums.Sum());
            }
        }

        public static void PrintIntList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        public static int[] ReadIntArray()
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] result = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] = int.Parse(input[i]);
            }
            return result;
        }

        

    }
}
