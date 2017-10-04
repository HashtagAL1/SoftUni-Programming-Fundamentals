using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        public static int GetMax(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        public static string GetLastDigitInEnglish(string number)
        {
            switch (number[number.Length - 1])
            {
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                case '0':
                    return "zero";
                default:
                    return "";
            }
        }        

        public static int ReversedDigits(int num)
        {
            string rev = "";
            while (num > 0)
            {
                rev += num % 10;
                num /= 10;
            }
            return int.Parse(rev);
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

        public static bool IsPrime(int num)
        {
            if (num == 0 || num == 1)
            {
                return false;
            }
            for (int i = 2; i <= (int)Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> PrimesInRange(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int num = start; num <= end; num++)
            {
                if (IsPrime(num))
                {
                    primes.Add(num);
                }
            }
            return primes;
        }

        public static double DistanceToCentre(double a, double b)
        {
            double distance = Math.Sqrt(a * a + b * b);
            return distance;
        }

        public static void CloserDistance(double first, double second, double x1, double y1, double x2, double y2)
        {
            if (second > first)
            {
                Console.Write($"({x1}, {y1})");
            }
            else
            {
                Console.Write($"({x2}, {y2})");
            }
        }

        public static void LongerDistance(double first, double second, double x1, double y1, double x2, double y2)
        {
            if (second > first)
            {
                Console.Write($"({x2}, {y2})");
            }
            else
            {
                Console.Write($"({x1}, {y1})");
            }
        }

        public static double LineLength(double x1, double y1, double x2, double y2)
        {
            double length = Math.Sqrt(Math.Pow(Math.Abs(x2 - x1), 2) + Math.Pow(Math.Abs(y2 - y1),2));
            return length;
        }

        public static void PrintLongerLine(double firstLen, double secondLen, double x1,double y1, 
            double x2,double y2,double x3, double y3, double x4, double y4)
        {
            if (secondLen > firstLen)
            {
                CloserDistance(DistanceToCentre(x3,y3), DistanceToCentre(x4,y4), x3, y3, x4, y4);
                LongerDistance(DistanceToCentre(x3,y3), DistanceToCentre(x4,y4), x3,y3,x4,y4);
            }
            else if (secondLen < firstLen)
            {
                CloserDistance(DistanceToCentre(x1,y1), DistanceToCentre(x2,y2), x1,y1,x2,y2);
                LongerDistance(DistanceToCentre(x1, y1), DistanceToCentre(x2, y2), x1, y1, x2, y2);
            }
            else
            {
                CloserDistance(DistanceToCentre(x1,y1),DistanceToCentre(x2,y2),x1,y1,x2,y2);
            }
            Console.WriteLine();
        }

        public static double GetResult(string input, double side)
        {
            input = input.ToLower();
            switch (input)
            {
                case "face":
                    return GetFaceDiagonal(side);
                case "space":
                    return GetSpaceDiagonal(side);
                case "volume":
                    return GetVolume(side);
                case "area":
                    return GetArea(side);
                default:
                    return 0;
            }
        }

        public static double GetFaceDiagonal(double side)
        {
            double diagonal = Math.Sqrt(side * side + side * side);
            return diagonal;
        }
        
        public static double GetSpaceDiagonal(double side)
        {
            double diagonal = Math.Sqrt(3 * Math.Pow(side,2));
            return diagonal;
        }

        public static double GetVolume(double side)
        {
            return Math.Pow(side,3);
        }

        public static double GetArea(double side)
        {
            double area = 6 * Math.Pow(side,2);
            return area;
        }

        public static double TriangleArea()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            return (side * height) / 2;
        }

        public static double RectangleArea()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            return a * b;
        }

        public static double SquareArea()
        {
            double a = double.Parse(Console.ReadLine());
            return a * a;
        }

        public static double CircleArea()
        {
            double r = double.Parse(Console.ReadLine());
            return Math.Pow(r, 2) * Math.PI;
        }

        public static double FigureArea(string input)
        {
            input = input.ToLower();
            switch (input)
            {
                case "triangle":
                    return TriangleArea();
                case "rectangle":
                    return RectangleArea();
                case "circle":
                    return CircleArea();
                case "square":
                    return SquareArea();
                default:
                    return 0;                    
            }
        }

        public static bool IsPalindrome(int num)
        {
            int temp = num;
            int rev = 0;
            while (num > 0)
            {
                rev = rev * 10 + num % 10;
                num /= 10;
            }
            if (rev == temp)
            {
                return true;
            }

            return false;
        }

        public static bool IsSumDivBySeven(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            if (sum % 7 == 0)
            {
                return true;
            }
            return false;
        }

        public static bool HoldsEvenDigit(int num)
        {
            while (num > 0)
            {
                if ((num % 10) % 2 == 0)
                {
                    return true;
                }
                num /= 10;
            }
            return false;
        }

        public static void MasterNumber(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (IsPalindrome(i) && HoldsEvenDigit(i) && IsSumDivBySeven(i))
                {
                    Console.WriteLine(i);
                }
            }
        }


        public static BigInteger Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            if (number == 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }

        public static int TrailingZeroes(BigInteger number)
        {
            int cnt = 0;
            while (true)
            {
                if (number % 10 == 0)
                {
                    cnt++;
                }
                else
                {
                    break;
                }
                number /= 10;
            }
            return cnt;
        }
        
    }
}
