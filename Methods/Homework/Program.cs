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
            ulong num = ulong.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(num));
        }

        public static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        public static int GetMax(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        public static string GetLastDigitInEnglish(int number)
        {
            switch (number)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "zero";
            }
        }

        public static int GetLastDigit(int number)
        {
            return number % 10;
        }

        public static decimal ReversedDigits(decimal num)
        {
            string number = ReverseString(num.ToString());
            decimal result = decimal.Parse(number);
            return result;
        }

        public static string ReverseString(string str)
        {
            string res = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                res += str[i];
            }
            return res;
        }

        public static ulong Fib(ulong n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fib(n - 1) + Fib(n - 2);
        }

        public static bool IsPrime(ulong num)
        {
            if (num == 0 || num == 1)
            {
                return false;
            }
            for (ulong i = 2; i <= (ulong)Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
