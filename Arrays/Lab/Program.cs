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

        public static string[] InputStringArray()
        {
            string input = Console.ReadLine();
            string[] res = input.Split(' ');
            return res;
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



    }
}
