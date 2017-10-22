using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxSequenceEqualElements
{
    class MaxSqEqElements
    {
        static void Main(string[] args)
        {
            int[] nums = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();
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
                    File.AppendAllText("output.txt", nums[index].ToString() + " ");
                    //Console.Write(nums[index] + " ");
                }
            }
        }
    }
}
