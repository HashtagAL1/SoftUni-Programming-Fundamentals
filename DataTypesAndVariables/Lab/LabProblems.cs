using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class LabProblems
    {
        static void Main(string[] args)
        {
            RefactorSpecialNumbers();
        }

        public static void CenturiesToMinutes()
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
            Console.WriteLine("{0} centuries = {1} years = " +
                "{2} days = {3} hours = {4} minutes",centuries,years,days,hours,minutes);
        }

        public static void CircleArea()
        {
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F12}", r * r * Math.PI);
        }
        
        public static void ExactSum()
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal paca = decimal.Parse(Console.ReadLine());
                sum += paca;
            }
            Console.WriteLine(sum);
        }

        public static void Elevolumeator()
        {
            int p = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int all = 0;
            while(p > 0)
            {
                p -= c;
                all++;
            }
            Console.WriteLine(all);
        }

        public static void SpecialNumbers()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int j = i;
                int sum = 0;
                while (j > 0)
                {
                    sum += (j % 10);
                    j /= 10;
                }
                if (sum == 11 || (sum == 7 || sum == 5))
                {
                    Console.WriteLine("{0} -> True",i);
                }
                else
                {
                    Console.WriteLine("{0} -> False",i);
                }
            }
        }

        public static void TripplesOfLetters()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 97; i < 97 + n; i++)
            {
                for (int p = 97; p < 97 + n; p++)
                {
                    for (int j = 97; j < 97 + n; j++)
                    {
                        Console.WriteLine("{0}{1}{2}",(char)i, (char)p, (char)j);
                    }
                }
            }
        }

        public static void Greeting()
        {
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Hello, {0} {1}. You are {2} years old.",name, surname, age);
        }

        public static void RefactorOfPyramid()
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            double volume = (length * width * height) / 3; 
            Console.WriteLine("Pyramid Volume: {0:F2}",volume);
        }

        public static void RefactorSpecialNumbers()
        {
            int n = int.Parse(Console.ReadLine());
            for (int num = 1; num <= n; num++)
            {
                int rest = num;
                int sum = 0;
                while (rest > 0)
                {
                    sum += rest % 10;
                    rest /= 10;
                }
                bool result = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {result}");
                sum = 0;
            }
        }
    }
}
