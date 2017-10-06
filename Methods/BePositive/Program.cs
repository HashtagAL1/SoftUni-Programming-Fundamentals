using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BePositive
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < countSequences; i++)
            {
                string input = Console.ReadLine();
                var numbers = new List<int>();
                string[] arr = input.Split(' ');

                for (int j = 0; j < arr.Length; j++)
                {
                    if (!(arr[j].Equals("")))
                    {
                        int num = int.Parse(arr[j].ToString());
                        numbers.Add(num);
                    }
                }

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNum = numbers[j];

                    if (currentNum > 0)
                    {
                        Console.Write(currentNum + " ");

                        found = true;
                    }
                    else
                    {
                        currentNum += numbers[j + 1];

                        if (currentNum > 0)
                        {
                            found = true;
                            Console.Write(currentNum + " ");
                            j++;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("(empty)");
                }
                Console.WriteLine();
            }
        }
    }
}
