using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class PMDG
    {
        static void Main(string[] args)
        {
            List<long> input = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            List<long> removedElements = new List<long>();

            while (input.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    long num = input[0];
                    removedElements.Add(num);
                    input.RemoveAt(0);

                    OperateOnList(input, num);

                    input.Insert(0, input[input.Count - 1]);
                }
                else if (index >= input.Count)
                {
                    long num = input[input.Count - 1];
                    removedElements.Add(num);
                    input.RemoveAt(input.Count - 1);

                    OperateOnList(input, num);

                    long addon = input[0];
                    input.Add(addon);
                }
                else
                {
                    long num = input[index];
                    removedElements.Add(num);
                    input.RemoveAt(index);

                    OperateOnList(input, num);
                }
            }

            long sum = removedElements.Sum();
            Console.WriteLine(sum);
        }

        public static void OperateOnList(List<long> input, long num)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > num)
                {
                    input[i] -= num;
                }
                else
                    input[i] += num;
            }
        }
    }
}
