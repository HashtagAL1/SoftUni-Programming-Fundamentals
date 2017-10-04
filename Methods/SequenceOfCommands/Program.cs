using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceOfCommands
{
    class Program
    {
        private const char ArgumentsDelimiter = ' ';
        static void Main(string[] args)
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();
            

            string command = Console.ReadLine();


            while (!command.Equals("stop"))
            {

                string[] stringParams = command.Split(ArgumentsDelimiter);
                long[] argss = new long[command.Split(ArgumentsDelimiter).Length];
                if (stringParams[0].Equals("add") ||
                    stringParams[0].Equals("subtract") ||
                    stringParams[0].Equals("multiply"))
                {

                    //string line = Console.ReadLine().Trim();
                    
                    argss[0] = long.Parse(stringParams[1]);
                    argss[1] = long.Parse(stringParams[2]);
                    
                }

                PerformAction(array, stringParams[0], argss);

                PrintArray(array);
                Console.WriteLine();

                command = Console.ReadLine();
            }
        }

        static void PerformAction(long[] arr, string action, long[] args)
        {
            long pos = 0;
            long value = 0;

            switch (action)
            {
                case "multiply":
                    pos = args[0] - 1;
                    value = args[1];
                    arr[pos] *= value;
                    break;
                case "add":
                    pos = args[0] - 1;
                    value = args[1];
                    arr[pos] += value;
                    break;
                case "subtract":
                    pos = args[0] - 1;
                    value = args[1];
                    arr[pos] -= value;
                    break;
                default:

                    if (action.Equals("lshift"))
                    {
                        ArrayShiftLeft(arr);
                    }
                    else if (action.Equals("rshift"))
                    {
                        ArrayShiftRight(arr);
                    }
                    break;
            }
        }


        private static void ArrayShiftRight(long[] array)
        {
            long temp = array[array.Length - 1];
            for (long i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = temp;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            long temp = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = temp;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
