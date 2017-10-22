using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MostFrequentNumber
{
    class MFN
    {
        static void Main(string[] args)
        {
            try
            {
                int[] numbers = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();
                var numberFrequency = new Dictionary<int, int>();
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!(numberFrequency.ContainsKey(numbers[i])))
                    {
                        numberFrequency[numbers[i]] = 1;
                    }
                    else
                    {
                        numberFrequency[numbers[i]]++;
                    }
                }
                int mfn = numberFrequency.OrderByDescending(x => x.Value).First().Key;
                string output = $"The number {mfn} is the most frequent number(It occurs {numberFrequency[mfn]} times.) <-> " 
                    + string.Join(", ", numbers);
                File.WriteAllText("output.txt", output);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The input wasn't in correct format.");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("No such file exists.");
            }
            
        }
    }
}
