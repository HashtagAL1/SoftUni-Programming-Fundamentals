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

        public static void ConvertToBase10()
        {
            BigInteger[] input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            BigInteger oldBase = input[0];
            BigInteger num = input[1];

            BigInteger sum = 0;
            int pow = 0;
            while (num > 0)
            {
                BigInteger secondPart = BigInteger.Pow(oldBase, pow);//(BigInteger)Math.Pow((double)oldBase, pow);
                BigInteger firstPart = num % 10;
                sum += (firstPart * secondPart);
                pow++;
                num /= 10;
            }
            Console.WriteLine(sum);
        }

        public static string ConvertFromBase10ToAnother()
        {
            StringBuilder sb = new StringBuilder();
            BigInteger[] input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            BigInteger newBase = input[0];
            BigInteger number = input[1];
            BigInteger upper = number;
            BigInteger down = newBase;

            while (upper != 0)
            {
                BigInteger rest = upper % down;
                sb.Append(rest);
                upper = upper / down;
            }

            return ReverseString(sb.ToString());
        }

        public static void MelrahShake()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder str = new StringBuilder();
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();
            sb.Append(input);
            str.Append(pattern);
            while (true)
            {
                if (str.Length == 0)
                {
                    Console.WriteLine("No shake.");
                    input = sb.ToString();
                    break;
                }
                int firstIndex = input.IndexOf(pattern);
                int lastIndex = input.LastIndexOf(pattern);
                if (firstIndex == -1 || lastIndex == -1)
                {
                    Console.WriteLine("No shake.");
                    input = sb.ToString();
                    break;
                }

                Console.WriteLine("Shaked it.");

                sb.Remove(firstIndex, str.Length);
                sb.Remove(lastIndex - str.Length, str.Length);
                str.Remove(str.Length / 2, 1);
                pattern = str.ToString();
                input = sb.ToString();
            }
            Console.WriteLine(input);
        }

        public static void LettersChangeNumbers()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                double tempSum = 0;
                string element = input[i];
                char first = element[0];
                char last = element[element.Length - 1];
                double number = double.Parse(element.Substring(1, element.Length - 2));
                int position = -1;

                if (IsUpper(first))
                {
                    //divide
                    position = (int)first - 64;
                    tempSum = number / position;
                    if (IsUpper(last))
                    {
                        //subtract
                        position = (int)last - 64;
                        tempSum -= position;
                    }
                    else
                    {
                        //add
                        position = (int)last - 96;
                        tempSum += position;
                    }
                }
                else
                {
                    //multiply
                    position = (int)first - 96;
                    tempSum = number * position;
                    if (IsUpper(last))
                    {
                        //subtract
                        position = (int)last - 64;
                        tempSum -= position;
                    }
                    else
                    {
                        //add
                        position = (int)last - 96;
                        tempSum += position;
                    }
                }
                sum += tempSum;
            }
            Console.WriteLine("{0:F2}", sum);
        }

        public static bool IsUpper(char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
                return true;
            return false;
            
        }

        public static string ReverseString(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

        public static void UnicodeChars()
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write("\\u" + ((int)input[i]).ToString("X4").ToLower());
            }
            Console.WriteLine();
        }

        public static long GetMultipliedSumOfStrings(string str1, string str2)
        {
            long sum = 0;
            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += ((int)str1[i] * (int)str2[i]);
                }
            }
            else if (str1.Length < str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += ((int)str1[i] * (int)str2[i]);
                }
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    sum += ((int)str2[i]);
                }
            }
            else
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    sum += ((int)str1[i] * (int)str2[i]);
                }
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    sum += ((int)str1[i]);
                }
            }
            return sum;
            
        }

        public static bool IsExchangeable(string str1, string str2)
        {
            var dict = new Dictionary<char, char>();

            if (str1.Length < str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (!(dict.ContainsKey(str1[i])))
                    {
                        if (!(dict.ContainsValue(str2[i])))
                        {
                            dict[str1[i]] = str2[i];
                        }
                        else
                            return false;
                    }
                }

                for (int i = str1.Length; i < str2.Length; i++)
                {
                    if (!(dict.ContainsValue(str2[i])))
                    {
                        return false;
                    }
                }
            }
            else if (str2.Length < str1.Length)
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    if (!(dict.ContainsKey(str2[i])))
                    {
                        if (!(dict.ContainsValue(str1[i])))
                        {
                            dict[str2[i]] = str1[i];
                        }
                        else
                            return false;
                    }
                }

                for (int i = str2.Length; i < str1.Length; i++)
                {
                    if (!(dict.ContainsValue(str1[i])))
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    if (!(dict.ContainsKey(str1[i])))
                    {
                        if (!(dict.ContainsValue(str2[i])))
                        {
                            dict[str1[i]] = str2[i];
                        }
                        else
                            return false;
                    }
                }

                for (int i = 0; i < str2.Length; i++)
                {
                    if (!(dict.ContainsValue(str2[i])))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static string SumVeryBigNumbers(string str1, string str2)
        {
            List<char> ch1 = str1.ToList();
            List<char> ch2 = str2.ToList();

            

            if (ch1.Count < ch2.Count)
            {
                int diff = ch2.Count - ch1.Count;
                for (int i = 0; i < diff; i++)
                {
                    ch1.Insert(0, '0');
                }
            }
            else if (ch2.Count < ch1.Count)
            {
                int diff = ch1.Count - ch2.Count;
                for (int i = 0; i < diff; i++)
                {
                    ch2.Insert(0, '0');
                }
            }
            return DoStringAddition(ch1,ch2);
        }

        public static string DoStringAddition(List<char> ch1, List<char> ch2)
        {

            StringBuilder sb = new StringBuilder();
            int sum = 0;
            for (int i = ch1.Count - 1; i >= 0; i--)
            {
                sum += int.Parse(ch1[i].ToString()) + int.Parse(ch2[i].ToString());
                if (sum < 10)
                {
                    sb.Append(sum);
                    sum = 0;
                }
                else
                {
                    sb.Append(sum % 10);
                    sum /= 10;
                    if (i == 0)
                    {
                        sb.Append(sum);
                    }
                }
            }
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                if (!(sb[i].Equals('0')))
                {
                    break;
                }
                else
                    sb.Remove(i,1);
            }

            return ReverseString(sb.ToString());
        }

        public static string DoStringMultiplication(string num1, int num2)
        {
            if (num2 == 0)
            {
                return "0";
            }

            string secondNumber = num1;
            for (int i = 0; i < num2 - 1; i++)
            {
                string res = SumVeryBigNumbers(num1, secondNumber);
                num1 = res;
            }
            return num1;
        }
        
    }
}
