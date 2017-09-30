﻿using System;
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
            CompareFloats();
        }

        public static void PracticeIntNumbers()
        {
            sbyte num1 = -100;
            byte num2 = 128;
            short num3 = -3540;
            ushort num4 = 64876;
            uint num5 = 2147483648;
            int num6 = -1141583228;
            long num7 = -1223372036854775808;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
            Console.WriteLine(num7);

        }

        public static void PracticeFloatingPoints()
        {
            decimal num1 = 3.141592653589793238m;
            double num2 = 1.60217657;
            decimal num3 = 7.8184261974584555216535342341m;
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
        }

        public static void PracticeCharsAndStrings()
        {
            string str1 = "Software University";
            char ch1 = 'B';
            char ch2 = 'y';
            char ch3 = 'e';
            string str2 = "I love programming";
            Console.WriteLine(str1);
            Console.WriteLine(ch1);
            Console.WriteLine(ch2);
            Console.WriteLine(ch3);
            Console.WriteLine(str2);
        }

        public static void VarInHexFormat()
        {
            string hexVar = Console.ReadLine();
            Console.WriteLine(Convert.ToInt32(hexVar,16));
        }

        public static void BooleanVar()
        {
            string input = Console.ReadLine();
            if (Convert.ToBoolean(input))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static void StringsAndObjects()
        {
            string hello = "Hello";
            string world = "World";
            object obj = hello + " " + world;
            string result = obj.ToString();
            Console.WriteLine(result);
        }

        public static void ExchangeVariableValues()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("Before:\na = {0}\nb = {1}",a,b);
            b -= a;
            a += b;
            Console.WriteLine("After:\na = {0}\nb = {1}",a,b);
        }

        public static void EmployeeData()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            long id = long.Parse(Console.ReadLine());
            int uen = int.Parse(Console.ReadLine());
            Console.WriteLine($"First name: {firstName}");
            Console.WriteLine($"Last name: {lastName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");//8 306 112 507
            Console.WriteLine($"Personal ID: {id}");
            Console.WriteLine($"Unique Employee number: {uen}");
        }

        public static void ReversedChars()
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine($"{c}{b}{a}");
        }

        public static void CenturiesToNanoseconds()
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            uint days = (uint)(years * 365.2422);
            uint hours = days * 24;
            ulong minutes = (ulong)(hours * 60);
            ulong seconds = minutes * 60;
            ulong miliseconds = seconds * 1000;
            ulong microseconds = miliseconds * 1000;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = " +
                $"{minutes} minutes = {seconds} seconds = {miliseconds} milliseconds = " +
                $"{microseconds} microseconds = {microseconds}000 nanoseconds");

        }

        public static void ConvertSpeedUnits()
        {
            float distance = float.Parse(Console.ReadLine());
            float miles = distance / 1609;
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());
            float allSecs = (hours * 60 * 60) + (minutes * 60) + seconds;
            float allHours = allSecs / 3600;
            Console.WriteLine(distance / allSecs);
            Console.WriteLine((distance / 1000) / allHours);
            Console.WriteLine(miles / allHours);
        }

        public static void RectangleProperties()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double perimeter = 2 * width + 2 * height;
            double area = width * height;
            double diagonal = Math.Sqrt(height * height + width * width);
            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);
        }

        public static void VowelOrDigit()
        {
            char input = char.Parse(Console.ReadLine());
            if (input >= '0' && input <= '9')
            {
                Console.WriteLine("digit");
            }
            else if (input.Equals('a') || input.Equals('o') || input.Equals('u') 
                || input.Equals('i') || input.Equals('e') || input.Equals('y'))
            {
                Console.WriteLine("vowel");
            }
            else if (input.Equals('A') || input.Equals('O') || input.Equals('U')
                || input.Equals('I') || input.Equals('E') || input.Equals('Y'))
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }

        public static void IntToHexAndBinary()
        {
            int input = int.Parse(Console.ReadLine());
            string hex = Convert.ToString(input, 16);
            Console.WriteLine(hex.ToUpper());
            Console.WriteLine(Convert.ToString(input,2));
        }

        public static void FastPrimeChecker()
        {
            int max = int.Parse(Console.ReadLine());
            for (int num = 2; num <= max; num++)
            {
                bool res = true;
                for (int divider = 2; divider <= Math.Sqrt(num); divider++)
                {
                    if (num % divider == 0)
                    {
                        res = false;
                        break;
                    }
                }
                Console.WriteLine($"{num} -> {res}");
            }
        }

        public static void CompareFloats()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            int dotA = a.IndexOf('.');
            int dotB = b.IndexOf('.');
            bool result = true;
            if (!(dotA.Equals(dotB)))
            {
                result = false;
                Console.WriteLine(result);
            }
            else
            {
                for (int i = 0; i < dotA; i++)
                {
                    if (!(a[i].Equals(b[i])))
                    {
                        result = false;
                        Console.WriteLine(result);
                        return;
                    }
                }
                for (int i = dotA + 1; i < dotA + 7; i++)//.123456
                {
                    if (!(a[i].Equals(b[i])))
                    {
                        result = false;
                        Console.WriteLine(result);
                        return;
                    }
                }
                Console.WriteLine(result);
            }
        }
        //tazi

        public static void PrintAsciiTable()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            for (int ch = a; ch <= b; ch++)
            {
                Console.Write((char)ch + " ");
            }
            Console.WriteLine();
        }

        public static void DifferentIntegerSizes()
        {
            string input = Console.ReadLine();
            sbyte a = 0;
            byte b = 0;
            short c = 0;
            ushort d = 0;
            int e = 0;
            uint r = 0;
            long v = 0;


            sbyte.TryParse(input, out a);            
            byte.TryParse(input, out b);
            short.TryParse(input, out c);
            ushort.TryParse(input, out d);
            int.TryParse(input, out e);
            uint.TryParse(input, out r);
            long.TryParse(input, out v);
            
            if (a == 0 && b == 0 && c == 0 && d == 0 && e == 0 && r == 0 && v == 0)
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
            else
            {
                Console.WriteLine($"{input} can fit in:");
                if (a != 0)
                {
                    Console.WriteLine("* sbyte");
                }
                if (b != 0)
                {
                    Console.WriteLine("* byte");
                }
                if (c != 0)
                {
                    Console.WriteLine("* short");
                }
                if (d != 0)
                {
                    Console.WriteLine("* ushort");
                }
                if (e != 0)
                {
                    Console.WriteLine("* int");
                }
                if (r != 0)
                {
                    Console.WriteLine("* uint");
                }
                if (v != 0)
                {
                    Console.WriteLine("* long");
                }
            }




        }
        

        public static void Photographer()
        {
            int takenPictures = int.Parse(Console.ReadLine());
            int timeForFilteringAPicture = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            double percentage = filterFactor / 100.0;
            int filteredPics = (int)Math.Ceiling(percentage * takenPictures);
            long filteringTime = takenPictures * (long)timeForFilteringAPicture;
            long upload = (long)uploadTime * filteredPics;
            long alltime = upload + filteringTime;

            long days = alltime / (3600 * 24);
            long hours = alltime / 3600;
            long minutes = (alltime / 60) % 60;
            long seconds = alltime % 60;

            TimeSpan ts = new TimeSpan((int)days,(int)hours, (int)minutes,(int)seconds);
            Console.WriteLine("{0:d\\:hh\\:mm\\:ss}",ts);
        }


    }
}