using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EqualSums
{
    class EqSums
    {
        static void Main(string[] args)
        {

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

            int[] nums = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();
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
                File.WriteAllText("output.txt", index.ToString());
                //Console.WriteLine(index);
            }
            else
            {
                File.WriteAllText("output.txt", "No such number!");
                //Console.WriteLine("no");
            }
        }
    }
}
