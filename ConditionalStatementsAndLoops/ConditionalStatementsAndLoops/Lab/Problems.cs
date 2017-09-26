using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Problems
    {
        static void Main(string[] args)
        {
            int a = 0;

            bool res = int.TryParse(Console.ReadLine(), out a);
            if (res)
            {
                Console.WriteLine("It is a number.");
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
