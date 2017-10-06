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
            int[] arr1 = InputStringArray();
            
        }

        public static string DayOfWeek(int num)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            try
            {
                return days[num - 1];
            }
            catch (IndexOutOfRangeException ioor)
            {
                return "Invalid Day!";
            }
        }

        public static int[] InputArray()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        public static int[] ReverseArray(int[] arr)
        {
            int[] res = new int[arr.Length];
            for (int i = arr.Length - 1, j = 0; i >= 0; i--, j++)
            {
                res[j] = arr[i];
            }
            return res;
        }
        
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void LastKNumbersSequence()
        {

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            
            int[] arr = new int[n];
            arr[0] = 1;
            arr[1] = 1;
            for (int i = 2; i < arr.Length; i++)
            {
                if (i < k)
                {
                    for (int j = 0; j < i; j++)
                    {
                        arr[i] += arr[j];
                    }
                }
                else
                {
                    for (int j = k; j > 0; j--)
                    {
                        arr[i] += arr[i - j];
                    }
                }

            }
            PrintArray(arr);
        }

        public static void RoundInt()
        {

            string input = Console.ReadLine();
            string[] arr = input.Split(' ');
            double[] nums = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                nums[i] = double.Parse(arr[i]);
                int check = (int)(nums[i] * 10);
                if (nums[i] >= 0)
                {
                    if (Math.Abs(check % 10) >= 5)
                    {
                        Console.WriteLine("{0} => {1}", nums[i], (int)nums[i] + 1);
                    }
                    else
                    {

                        Console.WriteLine("{0} => {1}", nums[i], (int)nums[i]);
                    }
                }
                else
                {
                    if (Math.Abs(check % 10) >= 5)
                    {
                        Console.WriteLine("{0} => {1}", nums[i], (int)nums[i] - 1);
                    }
                    else
                    {

                        Console.WriteLine("{0} => {1}", nums[i], (int)nums[i]);
                    }
                }

            }
        }

        public static int[] InputStringArray()
        {
            string input = Console.ReadLine();
            string[] res = input.Split(' ');
            int[] intArray = new int[res.Length];
            for (int i = 0; i < res.Length; i++)
            {
                intArray[i] = int.Parse(res[i]);
            }
            return intArray;
        }

        public static void ReverseStringArray(string[] arr)
        {
            for (int i = arr.Length - 1, j = 0; i >= arr.Length / 2; i--, j++)
            {
                string temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;

            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }

        public static int[] SumArrays(int[] arr1, int[] arr2)
        {
            int[] res = new int[Math.Max(arr1.Length, arr2.Length)];
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    res[i] = arr1[i] + arr2[i];
                }
            }
            else if (arr1.Length > arr2.Length)
            {
                for (int i = 0, j = 0; i < arr1.Length; i++, j++)
                {                    
                    res[i] = arr1[i] + arr2[j];
                    if (j == arr2.Length - 1)
                    {
                        j = -1;
                    }
                }
            }
            else if (arr1.Length < arr2.Length)
            {
                for (int i = 0, j = 0; i < arr2.Length; i++, j++)
                {                    
                    res[i] = arr2[i] + arr1[j];
                    if (j == arr1.Length - 1)
                    {
                        j = -1;
                    }
                }
            }
            return res;
        }

        public static int CondenseArrayToANumber(int[] arr)
        {            
            if (arr.Length == 1)
            {
                return arr[0];
            }
            else
            {
                int[] result = new int[arr.Length - 1];
                if (result.Length == 1)
                {
                    return arr[0] + arr[1];
                }
                for (int i = 1, j = 1; i < arr.Length - 1; i++, j++)
                {                    
                    result[j - 1] = arr[i - 1] + arr[i];
                    result[j] = arr[i] + arr[i + 1];
                }
                return CondenseArrayToANumber(result);
            }
        }

        public static int[] MiddleElements(int[] arr)
        {
            int[] result;
            if (arr.Length <= 3)
            {
                return arr;
            }
            else
            {
                if (arr.Length % 2 == 0)
                {
                    result = new int[2];
                    result[0] = arr[(arr.Length / 2) - 1];
                    result[1] = arr[arr.Length / 2];
                }
                else
                {
                    result = new int[3];
                    result[0] = arr[(arr.Length / 2) - 1];
                    result[1] = arr[arr.Length / 2];
                    result[2] = arr[(arr.Length / 2) + 1];
                }
            }
            return result;
        }

        public static void PrintMiddleElements(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    Console.Write("{0}",arr[i]);
                }
                else
                {
                    Console.Write("{0}, ", arr[i]);
                }
            }
            Console.WriteLine(" }");

        }
        
        





    }
}
