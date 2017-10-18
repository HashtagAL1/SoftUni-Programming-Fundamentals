using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void SalesReport()
        {
            var result = new SortedDictionary<string, decimal>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Sale sale = ReadSale(input);
                if (!(result.ContainsKey(sale.town)))
                {
                    result[sale.town] = 0;
                }
                result[sale.town] += (sale.price * sale.quantity);
            }
            foreach (var town in result.Keys)
            {
                Console.WriteLine("{0} -> {1:F2}", town, result[town]);
            }
        }

        public static Sale ReadSale(string[] input)
        {
            Sale obj = new Sale
            {
                town = input[0],
                product = input[1],
                price = decimal.Parse(input[2]),
                quantity = decimal.Parse(input[3])
            };
            return obj;
        }

        public static void RectanglePosition()
        {
            Rectangle fR = ReadRectangle();
            Rectangle sR = ReadRectangle();
            if (IsInside(fR, sR))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }

        public static Rectangle ReadRectangle()
        {
            string[] firstRect = Console.ReadLine().Split(' ');
            Point fstart = new Point { X = double.Parse(firstRect[0]), Y = double.Parse(firstRect[1]) };
            Rectangle fR = new Rectangle
            {
                startPoint = fstart,
                width = double.Parse(firstRect[2]),
                height = double.Parse(firstRect[3])
            };
            return fR;
        }

        public static bool IsInside(Rectangle first, Rectangle second)
        {
            if (second.startPoint.X <= first.startPoint.X && second.width >= first.width
                && second.startPoint.Y >= first.startPoint.Y && second.height >= first.height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ClosestPoints()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> input = new List<string>();
            string closestPoints = "";
            double distance = 0;
            double minDist = int.MaxValue;

            for (int i = 0; i < n; i++) //fill the list with points' coordinates
            {
                input.Add(Console.ReadLine());
            }

            for (int i = 0; i < input.Count - 1; i++) //find distances between points
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    string[] fpCoord = input[i].Split(' ');
                    string[] spCoord = input[j].Split(' ');
                    Point fp = new Point { X = double.Parse(fpCoord[0]), Y = double.Parse(fpCoord[1]) };
                    Point sp = new Point { X = double.Parse(spCoord[0]), Y = double.Parse(spCoord[1]) };
                    distance = GetDistanceBetweenPoints(fp, sp);
                    if (distance < minDist) //if a closer distance is found, it becomes the minimum distance
                    {
                        minDist = distance;
                        closestPoints = "(" + fp.X + ", " + fp.Y + ")\n" + "(" + sp.X + ", " + sp.Y + ")";
                    }
                }
            }

            Console.WriteLine("{0:F3}", minDist);
            Console.WriteLine(closestPoints);

        }

        public static void DistanceBetweenPoints()
        {
            Point first = new Point();
            Point second = new Point();
            string[] fPoint = Console.ReadLine().Split(' ');
            string[] sPoint = Console.ReadLine().Split(' ');
            first.X = double.Parse(fPoint[0]);
            first.Y = double.Parse(fPoint[1]);
            second.X = double.Parse(sPoint[0]);
            second.Y = double.Parse(sPoint[1]);
            Console.WriteLine("{0:F3}", GetDistanceBetweenPoints(first, second));
        }

        public static double GetDistanceBetweenPoints(Point a, Point b)
        {
            return Math.Sqrt((Math.Pow(b.X - a.X, 2)) + Math.Pow(b.Y - a.Y, 2));
        }

        public static void GetFactorial()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(number));
        }

        public static BigInteger Factorial(BigInteger num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }            
            return num * (Factorial(num - 1));
            
        }

        public static void GetDayOfWeek()
        {
            string input = Console.ReadLine();
            DateTime paca = DateTime.ParseExact(input, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine(paca.DayOfWeek);
        }

        public static void RandomizeWords()
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            for (int i = 0; i < input.Count; i++)
            {
                int index = GetRandomIndex(input);
                Console.WriteLine(input[index]);
                input.RemoveAt(index);
                i--;
            }
        }

        public static int GetRandomIndex(List<string> list)
        {
            Random rnd = new Random();
            return rnd.Next(0, list.Count);
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }


    }

    public class Rectangle
    {
        public Point startPoint { get; set; }
        public double width { get; set; }
        public double height { get; set; }

    }

    public class Sale
    {
        public string town { get; set; }
        public string product { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
    }
}
