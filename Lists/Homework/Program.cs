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

        public static void RemoveRepeatingElements(List<string> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        list.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }
        

        public static string AppendNumber(string init, int number)
        {
            string res = init;
            res += number;
            return res + " ";
        }

        public static void ArrayManipulator()
        {
            List<int> numbers = ReadIntList();
            string[] command = Console.ReadLine().Split(' ');
            if (command[0].Equals("print"))
            {
                Console.WriteLine();
                return;
            }
            while (!(command[0].Equals("print")))
            {
                if (command[0].Equals("add"))
                {
                    int index = int.Parse(command[1]);
                    int element = int.Parse(command[2]);
                    AddElement(index, element, numbers);
                }
                else if (command[0].Equals("contains"))
                {
                    if (numbers.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine(numbers.IndexOf(int.Parse(command[1])));
                    }
                    else
                        Console.WriteLine(-1);
                }
                else if (command[0].Equals("remove"))
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                }
                else if (command[0].Equals("addMany"))
                {
                    int index = int.Parse(command[1]);
                    List<int> listToAdd = ConvertListToInt(command);
                    numbers = AddMany(index, listToAdd, numbers);
                }
                else if (command[0].Equals("shift"))
                {
                    ShiftPositions(numbers, int.Parse(command[1]));
                }
                else if (command[0].Equals("sumPairs"))
                {
                    numbers = SumPairs(numbers);
                }
                command = Console.ReadLine().Split(' ');
            }
            Console.Write('[');
            Console.Write(string.Join(", ", numbers));
            Console.WriteLine(']');
        }

        public static List<int> SumPairs(List<int> list)
        {
            List<int> result = new List<int>();
            if (list.Count % 2 == 0)
            {
                for (int i = 0; i < list.Count - 1; i += 2)
                {
                    result.Add(list[i] + list[i + 1]);
                }
            }
            else
            {
                for (int i = 0; i < list.Count - 2; i += 2)
                {
                    result.Add(list[i] + list[ i + 1]);
                }
                result.Add(list[list.Count - 1]);
            }
            return result;
        }

        public static void ShiftPositions(List<int> list, int positions)
        {
            for (int i = 0; i < positions; i++)
            {
                list.Add(list[i]);
            }
            list.RemoveRange(0, positions);
        }

        public static List<int> ConvertListToInt(string[] input)
        {
            List <int> result = new List<int>();
            for (int i = 2; i < input.Length; i++)
            {
                result.Add(int.Parse(input[i]));
            }
            return result;
        }
        
        public static List<int> AddMany(int index, List<int> list, List<int> numbers)
        {
            if (index > list.Count - 1)
            {
                numbers = numbers.Concat(list).ToList();
                return numbers;
            }
            else if (index == 0)
            {
                numbers = list.Concat(numbers).ToList();
                return numbers;
            }
            else
            {
                List<int> firstPart = new List<int>();
                List<int> lastPart = new List<int>();
                List<int> result = new List<int>();
                for (int i = 0; i < index; i++)
                {
                    firstPart.Add(numbers[i]);
                }
                for (int i = index; i < numbers.Count; i++)
                {
                    lastPart.Add(numbers[i]);
                }
                result = firstPart.Concat(list).ToList();
                result = result.Concat(lastPart).ToList();
                return result;
            }
        }

        public static void AddElement(int index, int element, List<int> list)
        {
            if (index >= list.Count)
            {
                list.Add(element);
                return;
            }
            int temp = list[index];
            list.Add(list[list.Count - 1]);
            for (int i = list.Count - 3; i > index; i--)
            {
                list[i + 1] = list[i];
            }
            list[index] = element;
            list[index + 1] = temp;
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
