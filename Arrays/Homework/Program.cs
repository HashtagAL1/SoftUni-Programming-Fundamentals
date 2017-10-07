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

        public static List<string> GetEqualElementsLeft(string[] arr1, string[] arr2)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i].Equals(arr2[i]))
                {
                    result.Add(arr1[i]);
                }
            }
            return result;
        }

        public static List<string> GetEqualElementsRight(string[] arr1, string[] arr2)
        {
            List<string> result = new List<string>();
            if (arr1.Length <= arr2.Length)
            {
                for (int i = arr1.Length - 1, j = arr2.Length - 1; i > -1; i--, j--)
                {
                    if (arr1[i].Equals(arr2[j]))
                    {
                        result.Add(arr1[i]);
                    }
                }
            }
            else
            {
                for (int i = arr2.Length - 1, j = arr1.Length - 1; i > -1; i--, j--)
                {
                    if (arr2[i].Equals(arr1[j]))
                    {
                        result.Add(arr2[i]);
                    }
                }
            }
            return result;


        }

        public static int[] ParseArrayToInt(string[] arr)
        {
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = int.Parse(arr[i]);
            }
            return res;
        }

        public static void RotateArray(int[] arr)
        {
            int temp = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[0] = temp;
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void RotateAndSum(int rotation, int[] input)
        {
            int[] res = new int[input.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = 0;
            }
            for (int i = 0; i < rotation; i++)
            {
                RotateArray(input);
                for (int j = 0; j < res.Length; j++)
                {
                    res[j] += input[j];
                }
            }
            PrintArray(res);
        }

        public static void FoldAndSum(int[] arr)
        {
            int[] left = new int[arr.Length / 4];
            int[] right = new int[arr.Length / 4];
            int[] mid = new int[arr.Length / 2];
            for (int i = (arr.Length / 4) - 1, j = 0; i >= 0; i--, j++)
            {
                left[j] = arr[i];
            }
            for (int i = arr.Length - 1, j = 0; j < right.Length; i--, j++)
            {
                right[j] = arr[i];
            }
            for (int i = 0, j = arr.Length / 4; i < mid.Length; i++, j++)
            {
                mid[i] = arr[j];
            }
            for (int i = 0; i < left.Length; i++)
            {
                mid[i] += left[i];
            }
            for (int i = (mid.Length / 2), j = 0; j < right.Length; i++, j++)
            {
                mid[i] += right[j];
            }

            PrintArray(mid);
        }

        public static void PrintArrayNoZeroes(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            Console.WriteLine();
        }

        public static void SieveOfErathostens(int[] numbers)
        {
            for (int i = 0, j = 2; i < numbers.Length; i++, j++)
            {
                numbers[i] = j;
            }
            for (int i = 2; i <= numbers.Length + 1; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == i)
                    {
                        continue;
                    }
                    else if (numbers[j] % i == 0)
                    {
                        numbers[j] = 0;
                    }

                }
            }
        }

        public static int CharComparison(char ch1, char ch2)
        {
            if (ch1 > ch2)
            {
                return 1;
            }
            else if (ch1 < ch2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static char[] InputCharArray()
        {
            string input = Console.ReadLine().Trim();
            return input.ToArray();
        }

        public static int CharArrayComparison(char[] arr1, char[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (CharComparison(arr1[i], arr2[i]) == 1)
                    {
                        return 1;
                    }
                    else if (CharComparison(arr1[i], arr2[i]) == -1)
                    {
                        return -1;
                    }
                }
                return 0;
            }
            else if (arr1.Length > arr2.Length)
            {
                return CompArrayToIndex(arr1, arr2);
            }
            else
            {
                return CompArrayToIndex(arr2, arr1);
            }
        }

        public static string PrintCharArray(char[] arr)
        {
            string res = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(' '))
                {
                    continue;
                }
                else
                {
                    res += arr[i];

                }
            }
            return res;
        }

        public static int CompArrayToIndex(char[] arr1, char[] arr2)
        {
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr1[i] > arr2[i])
                {
                    return 3;
                }
                else if (arr1[i] < arr2[i])
                {
                    return -3;
                }
            }
            return 0;
        }

        public static void CompareCharArrays(char[] arr1, char[] arr2)
        {
            if (CharArrayComparison(arr1, arr2) == 1 || CharArrayComparison(arr1, arr2) == 3)
            {
                Console.WriteLine(PrintCharArray(arr2));
                Console.WriteLine(PrintCharArray(arr1));
            }
            else if (CharArrayComparison(arr1, arr2) == -1 || CharArrayComparison(arr1, arr2) == -3)
            {
                Console.WriteLine(PrintCharArray(arr1));
                Console.WriteLine(PrintCharArray(arr2));
            }
            else if (CharArrayComparison(arr1, arr2) == 0)
            {
                if (arr1.Length == arr2.Length)
                {
                    Console.WriteLine(PrintCharArray(arr1));
                    Console.WriteLine(PrintCharArray(arr1));
                }
                else if (arr1.Length < arr2.Length)
                {
                    Console.WriteLine(PrintCharArray(arr1));
                    Console.WriteLine(PrintCharArray(arr2));
                }
                else
                {
                    Console.WriteLine(PrintCharArray(arr2));
                    Console.WriteLine(PrintCharArray(arr1));
                }
            }
        }

        public static void MaxSeqOfEqualElements()
        {

            int[] nums = ParseArrayToInt(Console.ReadLine().Split(' '));
            int max = 0;
            int cnt = 0;
            int index = -1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    cnt++;
                    if (cnt > max)
                    {
                        index = i;
                        max = cnt;
                    }
                }
                else
                {
                    cnt = 0;
                }
            }
            if (max > 0)
            {
                for (int i = 0; i <= max; i++)
                {
                    Console.Write(nums[index] + " ");
                }
            }
            Console.WriteLine();
        }

        public static void MaxSeqOfIncreasingElements()
        {

            int[] numbers = ParseArrayToInt(Console.ReadLine().Split(' '));
            int[] maxSeq = new int[numbers.Length];
            int cnt = 0;
            int max = 0;
            int endIndex = -1;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] < numbers[i + 1])
                {
                    cnt++;

                    if (cnt > max)
                    {
                        max = cnt;
                        endIndex = i;
                    }

                }
                else
                {
                    cnt = 0;
                }
            }
            for (int i = endIndex - max + 1; i <= endIndex + 1; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }

        public static void MostFrequentNumber()
        {
            int[] nums = ParseArrayToInt(Console.ReadLine().Split(' '));
            int max = 0;
            int num = -1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int cnt = 0;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        cnt++;
                        if (cnt > max)
                        {
                            max = cnt;
                            num = nums[i];
                        }
                    }
                }
            }
            Console.WriteLine(num);
        }

        public static int GetIndexOfLetter(char[] alphabet, char element)
        {
            return Array.IndexOf(alphabet, element);
        }

        public static void IndexOfALetter()
        {
            char[] romanAlphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
               'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', };
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"{input[i]} -> {GetIndexOfLetter(romanAlphabet, input[i])}");
            }
        }

        public static void PairsByDifference()
        {

            int[] nums = ParseArrayToInt(Console.ReadLine().Split(' '));
            int difference = int.Parse(Console.ReadLine());
            int countOfPairs = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) == difference)
                    {
                        countOfPairs++;
                    }
                }
            }
            Console.WriteLine(countOfPairs);
        }

        public static int SumLeft(int[] arr, int index)
        {
            if (index == 0)
            {
                return 0;
            }
            else
            {
                int sum = 0;
                for (int i = 0; i < index; i++)
                {
                    sum += arr[i];
                }
                return sum;
            }
           
        }

        public static int SumRight(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return 0;
            }
            else
            {
                int sum = 0;
                for (int i = index + 1; i < arr.Length; i++)
                {
                    sum += arr[i];
                }
                return sum;
            }
        }

        public static void EqualSums()
        {

            int[] nums = ParseArrayToInt(Console.ReadLine().Split(' '));
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (SumLeft(nums, i) == SumRight(nums, i))
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }

    }
}
