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
            ChooseDrink();
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
            int discPrice = 0;

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
                    discPrice = 500;
                    break;
                case "gold":
                    discount = 0.1;
                    discPrice = 750;
                    break;
                case "platinum":
                    discount = 0.15;
                    discPrice = 1000;
                    break;
                default:
                    break;
            }
            double pricePerPerson = ((price + discPrice) - ((price + discPrice) * discount)) / groupSize;
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
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (a > b)
            {
                for (int i = b; i <= a; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else if (a == b)
            {
                Console.WriteLine(a);
            }
            else
            {
                for (int i = a; i <= b; i++)
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
                string paca = Console.ReadLine();
                if (paca.ToLower().Equals("cheese"))
                {
                    sum += 500;
                }
                else if (paca.ToLower().Equals("tomato sauce"))
                {
                    sum += 150;
                }
                else if (paca.ToLower().Equals("salami"))
                {
                    sum += 600;
                }
                else if (paca.ToLower().Equals("pepper"))
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
                int a = 0;
                bool result = int.TryParse(input, out a);
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
            int n = int.Parse(Console.ReadLine());
            
            for ( int j = 1; j <= n; j++)
            {
                string p = j + " ";
                Console.WriteLine(string.Concat(Enumerable.Repeat(p,j)));
            }
            
        }

        public static void DifferentNumbers()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            if (Math.Abs(a-b) < 4)
            {
                Console.WriteLine("No");
                return;
            }
            for (int i = a; i <= b - 4; i++)
            {
                for (int j = a + 1; j <= b - 3; j++)
                {
                    for (int k = j + 1; k <= b - 2; k++)
                    {
                        for (int p = k + 1; p <= b - 1; p++)
                        {
                            for (int m = p + 1; m <= b; m++)
                            {
                                if (j > i && k > j && p > k && m > p)
                                {
                                    Console.WriteLine("{0} {1} {2} {3} {4}", i, j, k, p, m);
                                }

                            }
                        }
                    }
                }
            }
        }
        

        public static void Combinations()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int sum = 0;
            int cnt = 0;
            

            for (int i = n; i >= 1 && sum < max; i--)
            {
                for (int j = 1; j <= m && sum < max; j++)
                {
                    int temp = 3 * (i * j);
                    sum += temp;
                    cnt++;
                }
            }
            Console.WriteLine(cnt + " combinations");
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
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int cnt = 0;
            int last = 0;
            int a = 0;
            int b = 0;

            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    cnt++;
                    if (i + j == magic)
                    {
                        last = i + j;
                        a = i;
                        b = j;
                    }
                }
            }
            if (last != 0)
            {
                Console.WriteLine("Number found! {0} + {1} = {2}",a,b,magic);
            }
            else
            {
                Console.WriteLine("{0} combinations - neither equals {1}",cnt,magic);
            }
        }

        public static void MagicLetter()
        {
            char first = char.Parse(Console.ReadLine());
            
            char second = char.Parse(Console.ReadLine());
            
            char dont = char.Parse(Console.ReadLine());
            

            for (char ch = first; ch <= second; ch++)
            {
                for (char paca = first; paca <= second; paca++)
                {
                    for (char bok = first; bok <= second; bok++)
                    {
                        if (!(ch.Equals(dont) || paca.Equals(dont) || bok.Equals(dont)))
                        {
                            Console.Write("{0}{1}{2} ",ch,paca,bok);
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

            for (int i = 1;  ; i++)
            {
                
                
                if (i % 2 != 0)
                {
                    goshoHealth -= peshoAttack;
                    if (goshoHealth <= 0)
                    {
                        Console.WriteLine("Pesho won in {0}th round.", i);
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
                        Console.WriteLine("Gosho won in {0}th round.", i);
                        return;
                    }
                    Console.WriteLine("Gosho used Thunderous fist and " +
                        "reduced Pesho to {0} health.", peshoHealth);
                }
                if (i % 3 == 0)
                {
                    goshoHealth += 10;
                    peshoHealth += 10;
                }
            }
        }
        
    }
}
