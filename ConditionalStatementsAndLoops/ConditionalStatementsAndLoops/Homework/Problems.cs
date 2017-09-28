using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Problems
    {
        static void Main(string[] args)
        {
            NeighbourWars();
        }
        public static void ChooseDrink()
        {
            string job = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            switch (job)
            {
                case "Athlete":
                    Console.WriteLine("The {0} has to pay {1:F2}.",job, quantity * 0.70);
                    break;
                case "Businessman":
                    Console.WriteLine("The {0} has to pay {1:F2}.", job, quantity * 1.00);
                    break;
                case "Businesswoman":
                    Console.WriteLine("The {0} has to pay {1:F2}.", job, quantity * 1.00);
                    break;
                case "SoftUni Student":
                    Console.WriteLine("The {0} has to pay {1:F2}.", job, quantity * 1.70);
                    break;
                default:
                    Console.WriteLine("The {0} has to pay {1:F2}.", job, quantity * 1.20);
                    break;
            }
        }

        public static void RestaurantDiscount()
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            int price = 0;
            double discount = 0.0;
            int packagePrice = 0;

            if (groupSize <= 50)
            {
                Console.WriteLine("We can offer you the Small Hall");
                price = 2500;
            }
            else if (groupSize > 50 && groupSize <= 100)
            {
                Console.WriteLine("We can offer you the Terrace");
                price = 5000;
            }
            else if (groupSize > 100 && groupSize <= 120)
            {
                Console.WriteLine("We can offer you the Great Hall");
                price = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }
            switch (package.ToLower())
            {
                case "normal":
                    discount = 0.05;
                    packagePrice = 500;
                    break;
                case "gold":
                    discount = 0.1;
                    packagePrice = 750;
                    break;
                case "platinum":
                    discount = 0.15;
                    packagePrice = 1000;
                    break;
                default:
                    break;
            }
            double pricePerPerson = ((price + packagePrice) - ((price + packagePrice) * discount)) / groupSize;
            Console.WriteLine("The price per person is {0:F2}$",pricePerPerson);


        }

        public static void Hotel()
        {
            string month = Console.ReadLine();
            int period = int.Parse(Console.ReadLine());
            double priceStudio = 0;
            double priceSuite = 0;
            double priceDouble = 0;

            if (month.Equals("May"))
            {
                priceStudio = 50;
                priceDouble = 65;
                priceSuite = 75;
                if (period > 7)
                {
                    priceStudio -= (priceStudio * 0.05);
                }
                priceDouble *= period;
                priceStudio *= period;
                priceSuite *= period;
                
            }
            else if (month.Equals("June"))
            {
                priceStudio = 60;
                priceDouble = 72;
                priceSuite = 82;
                if (period > 14)
                {
                    priceDouble -= priceDouble * 0.1;
                }

                priceDouble *= period;
                priceStudio *= period;
                priceSuite *= period;

            }
            else if (month.Equals("July") || month.Equals("August") || month.Equals("December"))
            {
                priceStudio = 68;
                priceDouble = 77;
                priceSuite = 89;
                if (period > 14)
                {
                    priceSuite -= priceSuite * 0.15;
                }
                priceSuite *= period;
                priceStudio *= period;
                priceDouble *= period;
            }
            else if (month.Equals("October"))
            {
                priceStudio = 50;
                priceDouble = 65;
                priceSuite = 75;
                if (period > 7)
                {
                    priceDouble *= (period);
                    priceSuite *= (period);
                    priceStudio *= (period - 1);
                    priceStudio -= (priceStudio * 0.05);
                }
                else
                {
                    priceDouble *= period;
                    priceSuite *= period;
                    priceStudio *= period;
                }

            }
            else if (month.Equals("September"))
            {
                priceStudio = 60;
                priceDouble = 72;
                priceSuite = 82;
                if (period > 7 && period <= 14)
                {
                    priceDouble *= (period);
                    priceSuite *= (period);
                    priceStudio *= (period - 1);

                }
                else if (period > 14)
                {
                    priceStudio *= (period - 1);
                    priceDouble -= (priceDouble * 0.1);
                    priceDouble *= period;
                    priceSuite *= period;
                }
                
            }


            Console.WriteLine("Studio: {0:F2} lv.",priceStudio);
            Console.WriteLine("Double: {0:F2} lv.", priceDouble);
            Console.WriteLine("Suite: {0:F2} lv.",priceSuite);
            
        }
        

        public static void WordInPlural()
        {
            StringBuilder str = new StringBuilder();
            string word = Console.ReadLine();
            if (word[word.Length - 1].Equals('y'))
            {
                for (int i = 0; i < word.Length - 1; i++)
                {
                    str.Append(word[i]);
                }
                str.Append("ies");
            }
            else if (word[word.Length - 1].Equals('o') || word[word.Length - 1].Equals('s') || 
                word[word.Length - 1].Equals('x') || word[word.Length - 1].Equals('z'))
            {
                str.Append(word);
                str.Append("es");
            }
            else if ((word[word.Length - 2].Equals('s') || word[word.Length - 2].Equals('c')) &&
                word[word.Length - 1].Equals('h'))
            {
                str.Append(word);
                str.Append("es");
            }
            else
            {
                str.Append(word);
                str.Append("s");
            }            

            word = str.ToString();
            Console.WriteLine(word);
        }
        
        public static void IntervalOfNumbers()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            if (firstNum > secondNum)
            {
                for (int i = secondNum; i <= firstNum; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else if (firstNum == secondNum)
            {
                Console.WriteLine(firstNum);
            }
            else
            {
                for (int i = firstNum; i <= secondNum; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void CakeIngredients()
        {
            string command = Console.ReadLine();
            int cnt = 0;

            while (!(command.Equals("Bake!")))
            {
                Console.WriteLine("Adding ingredient {0}.", command);
                cnt++;
                command = Console.ReadLine();
            }
            Console.WriteLine("Preparing cake with {0} ingredients.",cnt);
        }

        public static void CaloriesCounter()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                string ingredient = Console.ReadLine();
                if (ingredient.ToLower().Equals("cheese"))
                {
                    sum += 500;
                }
                else if (ingredient.ToLower().Equals("tomato sauce"))
                {
                    sum += 150;
                }
                else if (ingredient.ToLower().Equals("salami"))
                {
                    sum += 600;
                }
                else if (ingredient.ToLower().Equals("pepper"))
                {
                    sum += 50;
                }
            }
            Console.WriteLine("Total calories: {0}",sum);
        }

        public static void CountTheIntegers()
        {
            int cnt = 0;
            while (true)
            {

                string input = Console.ReadLine();
                int parsedNumber = 0;
                bool result = int.TryParse(input, out parsedNumber);
                if (result == false)
                {
                    break;
                }
                else
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
        }

        public static void TriangleOfNumbers()
        {
            int maxRow = int.Parse(Console.ReadLine());
            
            for ( int row = 1; row <= maxRow; row++)
            {
                string output = row + " ";
                Console.WriteLine(string.Concat(Enumerable.Repeat(output,row)));
            }
            
        }

        public static void DifferentNumbers()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            if (Math.Abs(firstNum - secondNum) < 4)
            {
                Console.WriteLine("No");
                return;
            }
            for (int firstElement = firstNum; firstElement <= secondNum - 4; firstElement++)
            {
                for (int secondElement = firstNum + 1; secondElement <= secondNum - 3; secondElement++)
                {
                    for (int thirdElement = secondElement + 1; thirdElement <= secondNum - 2; thirdElement++)
                    {
                        for (int fourthElement = thirdElement + 1; fourthElement <= secondNum - 1; fourthElement++)
                        {
                            for (int fifthElement = fourthElement + 1; fifthElement <= secondNum; fifthElement++)
                            {
                                if (secondElement > firstElement && thirdElement > secondElement && 
                                    fourthElement > thirdElement && fifthElement > fourthElement)
                                {
                                    Console.WriteLine("{0} {1} {2} {3} {4}", firstElement, secondElement, 
                                        thirdElement, fourthElement, fifthElement);
                                }

                            }
                        }
                    }
                }
            }
        }
        

        public static void Combinations()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int sum = 0;
            int combinations = 0;
            

            for (int firstDigit = firstNum; firstDigit >= 1 && sum < max; firstDigit--)
            {
                for (int secondDigit = 1; secondDigit <= secondNum && sum < max; secondDigit++)
                {
                    int temp = 3 * (firstDigit * secondDigit);
                    sum += temp;
                    combinations++;
                }
            }
            Console.WriteLine(combinations + " combinations");
            if (sum >= max)
            {
                Console.WriteLine("Sum: {0} >= {1}",sum,max);
            }
            else
            {
                Console.WriteLine("Sum: {0}",sum);
            }
            
        }

        public static void GameOfNumbers()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combinations = 0;
            int last = 0;
            int firstPart = 0;
            int secondPart = 0;

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int j = firstNumber; j <= secondNumber; j++)
                {
                    combinations++;
                    if (i + j == magicNumber)
                    {
                        last = magicNumber;
                        firstPart = i;
                        secondPart = j;
                    }
                }
            }
            if (last != 0)
            {
                Console.WriteLine("Number found! {0} + {1} = {2}",firstPart,secondPart,magicNumber);
            }
            else
            {
                Console.WriteLine("{0} combinations - neither equals {1}",combinations,magicNumber);
            }
        }

        public static void MagicLetter()
        {
            char first = char.Parse(Console.ReadLine());
            
            char second = char.Parse(Console.ReadLine());
            
            char dont = char.Parse(Console.ReadLine());
            

            for (char fChar = first; fChar <= second; fChar++)
            {
                for (char sChar = first; sChar <= second; sChar++)
                {
                    for (char tChar = first; tChar <= second; tChar++)
                    {
                        if (!(fChar.Equals(dont) || sChar.Equals(dont) || tChar.Equals(dont)))
                        {
                            Console.Write("{0}{1}{2} ", fChar, sChar, tChar);
                        }
                    }
                }
            }
        }

        public static void NeighbourWars()
        {
            int peshoAttack = int.Parse(Console.ReadLine());
            int goshoAttack = int.Parse(Console.ReadLine());

            int goshoHealth = 100;
            int peshoHealth = 100;

            for (int round = 1;  ; round++)
            {
                
                
                if (round % 2 != 0)
                {
                    goshoHealth -= peshoAttack;
                    if (goshoHealth <= 0)
                    {
                        Console.WriteLine("Pesho won in {0}th round.", round);
                        return;
                    }
                    Console.WriteLine("Pesho used Roundhouse kick and " +
                        "reduced Gosho to {0} health.", goshoHealth);
                }
                else
                {
                    peshoHealth -= goshoAttack;
                    if (peshoHealth <= 0)
                    {
                        Console.WriteLine("Gosho won in {0}th round.", round);
                        return;
                    }
                    Console.WriteLine("Gosho used Thunderous fist and " +
                        "reduced Pesho to {0} health.", peshoHealth);
                }
                if (round % 3 == 0)
                {
                    goshoHealth += 10;
                    peshoHealth += 10;
                }
            }
        }
        
    }
}
