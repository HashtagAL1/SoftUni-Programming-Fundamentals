using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            HolidaysBetweenDates();
        }

        public static void BlankReceipt()
        {
            Header();
            Body();
            Footer();
        }

        public static void Header()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        public static void Body()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        public static void Footer()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("© SoftUni");
        }

        public static void SignOfInteger(int num)
        {
            if (num > 0)
            {
                Console.WriteLine($"The number {num} is positive.");
            }
            else if (num < 0)
            {
                Console.WriteLine($"The number {num} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {num} is zero.");
            }
        }

        public static void PrintLine(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                Console.Write( i + " ");
            }
            Console.WriteLine();
        }

        public static void PrintTriangle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintLine(i);
            }
            for (int i = number - 1; i > 0; i--)
            {
                PrintLine(i);
            }
        }

        public static void StaticLine(int num)
        {
            Console.WriteLine(new string('-', 2 * num));
        }

        public static void DynamicLine(int num)
        {
            Console.Write('-');
            for (int i = 1; i < num; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine('-');
        }

        public static void SquareDrawing(int num)
        {
            StaticLine(num);
            for (int i = 0; i < num / 2; i++)
            {
                DynamicLine(num);
            }
            StaticLine(num);
        }

        public static double FarenheitToCelsius(double grads)
        {
            double celsius = (grads - 32) * 5 / 9;
            return celsius;
        }

        public static double TriangleArea(double width, double height)
        {
            return width * height / 2;
        }

        public static double RaiseToPower(double number, int power)
        {
            return Math.Pow(number, power);
        }
        
        
        public static int GetMax(int a, int b)
        {
            return Math.Max(a,b);
        }

        public static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public static string GetMax(string a, string b)
        {
            int res = a.CompareTo(b);
            switch (res)
            {
                case 1:
                    return a;
                case 0:
                    return a;
                case -1:
                    return b;
                default:
                    return "Error";
                    
            }
        }

        public static void Comparing(string input)
        {
            if (input.Equals("int"))
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second));
            }
            else if (input.Equals("char"))
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(first, second));
            }
            else
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                Console.WriteLine(GetMax(first, second));
            }
        }

        public static int MultiplyEvensByOdds(int number)
        {
            return SumOfEvens(number) * SumOfOdds(number);
        }

        public static int SumOfEvens(int number)
        {
            int sum = 0;
            number = Math.Abs(number);
            while (number > 0)
            {
                int temp = number % 10;
                if (temp % 2 == 0)
                {
                    sum += temp;
                }
                number /= 10;
            }
            return sum;
        }

        public static int SumOfOdds(int number)
        {
            int sum = 0;
            number = Math.Abs(number);
            while (number > 0)
            {
                int temp = number % 10;
                if (temp % 2 != 0)
                {
                    sum += temp;
                }
                number /= 10;
            }
            return sum;
        }

        public static void HolidaysBetweenDates()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
            Console.WriteLine(holidaysCount);

        }


    }
}
