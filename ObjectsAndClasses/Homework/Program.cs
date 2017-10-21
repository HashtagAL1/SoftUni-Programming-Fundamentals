using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void AndreyBilliard()
        {
            int n = int.Parse(Console.ReadLine());
            var products = new Dictionary<string, decimal>();
            List<Client> all = new List<Client>();//list, holding all clients
            //initialization of dictionary, containing products and their prices
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-');
                products[input[0]] = decimal.Parse(input[1]);
            }
            //first input
            string inputData = Console.ReadLine();
            string[] sale = inputData.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (!(inputData.Equals("end of clients")))
            {
                Client cl = new Client(sale[0]);
                if (products.ContainsKey(sale[1]))//check if product is in allowed products
                {
                    if (ContainsClient(all, cl) != -1)//check if this client already exists (yes, set ref to it; no, add it)
                    {
                        cl = all[ContainsClient(all, cl)];
                    }
                    else
                        all.Add(cl);

                    if (!(cl.ShopList.ContainsKey(sale[1])))//check if that product has been purchased before by this client
                    {
                        cl.ShopList[sale[1]] = 0;//no - add it to shoplist
                    }
                    cl.ShopList[sale[1]] += int.Parse(sale[2]);//yes - increment it
                }
                //next input
                inputData = Console.ReadLine();
                sale = inputData.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

            }

            decimal allBills = 0;
            var sorted = all.OrderBy(x => x.Name).ToList();//clients sorted by name ascending
            //output
            for (int i = 0; i < sorted.Count; i++)
            {
                Console.WriteLine(sorted[i].Name);

                foreach (var product in sorted[i].ShopList.Keys)
                {
                    Console.WriteLine($"-- {product} - {sorted[i].ShopList[product]}");
                    sorted[i].TotalBill += (products[product] * sorted[i].ShopList[product]);//calculate total bill for each client
                }
                Console.WriteLine("Bill: {0:F2}", sorted[i].TotalBill);
                allBills += sorted[i].TotalBill;//calculate the sum of all bills
            }
            Console.WriteLine("Total bill: {0:F2}", allBills);

        }

        

        public static int ContainsClient(List<Client> list, Client cl)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (cl.Name.Equals(list[i].Name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static void BookLibraryModification()
        {
            Library lib = new Library();
            var result = new Dictionary<string, DateTime>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string title = input[0];
                string author = input[1];
                string publisher = input[2];
                DateTime relDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string isbn = input[4];
                decimal price = decimal.Parse(input[5]);
                Book book = new Book(title, author, isbn, publisher, price, relDate);
                lib.Books.Add(book);
            }
            DateTime markerDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            for (int i = 0; i < lib.Books.Count; i++)
            {
                if (lib.Books[i].ReleaseDate.CompareTo(markerDate) == 1)
                {
                    result[lib.Books[i].Title] = lib.Books[i].ReleaseDate;
                }
            }
            var sorted = result.OrderBy(x => x.Value).ThenBy(x => x.Key);

            foreach (var book in sorted)
            {
                Console.WriteLine("{0} -> {1}", book.Key, book.Value.ToString("dd.MM.yyyy"));
            }
        }

        public static void BookLibrary()
        {
            Library lib = new Library();
            var authors = new Dictionary<string, decimal>();
            int n = int.Parse(Console.ReadLine());
            //input of books
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                DateTime relDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Book book = new Book(input[0], input[1], input[4], input[2], decimal.Parse(input[5]), relDate);
                lib.Books.Add(book);
                if (!(authors.ContainsKey(input[1])))
                {
                    authors[input[1]] = 0;
                }
                authors[input[1]] += book.Price;
            }
            //sorting the books
            var sortedAuthors = authors.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            //output
            foreach (var author in sortedAuthors)
            {
                Console.WriteLine("{0} -> {1:F2}", author.Key, author.Value);
            }

        }
        
        public static void StudentAverageGrades()
        {
            var students = new Dictionary<string, double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] studentInput = Console.ReadLine().Split(' ');
                Student stud = new Student(GetGrades(studentInput), studentInput[0]);
                stud.AverageGrade = stud.Grades.Average();
                if (!(students.ContainsKey(stud.Name)))
                {
                    students[stud.Name] = stud.Grades.Average();
                }
            }
            var sortedStudents = students.OrderBy(x => x.Key).ThenByDescending(x => x.Value);
            foreach (var student in sortedStudents)
            {
                if (student.Value >= 5.00)
                {
                    Console.WriteLine("{0} -> {1:F2}", student.Key, student.Value);
                }
            }

        }

        public static void CircleIntersection()
        {
            Circle cr1 = ReadCircle();
            Circle cr2 = ReadCircle();
            if ((cr1.Radius + cr2.Radius) >= GetDistanceBetweenPoints(cr1.Centre, cr2.Centre))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        public static void RandomAvertisement()
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

            string[] events = { "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1} {2} - {3}", phrases[GetRandomIndex(phrases)],
                    events[GetRandomIndex(events)], authors[GetRandomIndex(authors)],
                    cities[GetRandomIndex(cities)]);
            }
        }

        public static void WorkingDays()
        {
            DateTime fDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime sDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int cnt = 0;
            while (fDate <= sDate)
            {
                if ((fDate.DayOfWeek.ToString().Equals("Saturday") || fDate.DayOfWeek.ToString().Equals("Sunday"))
                    || (fDate.Day == 24 && fDate.Month == 12)
                    || (fDate.Day == 25 && fDate.Month == 12) || (fDate.Month == 11 && fDate.Day == 1)
                    || (fDate.Day == 22 && fDate.Month == 9) || (fDate.Day == 6 && fDate.Month == 9)
                    || (fDate.Day == 24 && fDate.Month == 5) || (fDate.Day == 6 && fDate.Month == 5)
                    || (fDate.Day == 1 && fDate.Month == 5) || (fDate.Day == 3 && fDate.Month == 3)
                    || (fDate.Day == 1 && fDate.Month == 1) || (fDate.Day == 26 && fDate.Month == 12))
                {
                    fDate = fDate.AddDays(1);
                    continue;
                }
                else
                {
                    cnt++;
                    fDate = fDate.AddDays(1);
                }

            }
            Console.WriteLine(cnt);

        }

        public static int GetRandomIndex(string[] arr)
        {
            Random rnd = new Random();
            return rnd.Next(0,arr.Length);
        }

        public static Circle ReadCircle()
        {

            string[] input = Console.ReadLine().Split(' ');
            Circle circle = new Circle
            {
                Centre = new Point { X = double.Parse(input[0]), Y = double.Parse(input[1]) },
                Radius = double.Parse(input[2])
            };
            return circle;
        }

        public static double GetDistanceBetweenPoints(Point a, Point b)
        {
            return Math.Sqrt((Math.Pow(b.X - a.X, 2)) + Math.Pow(b.Y - a.Y, 2));
        }

        public static List<double> GetGrades(string[] input)
        {
            List <double> grades = new List<double>();
            for (int i = 1; i < input.Length; i++)
            {
                grades.Add(double.Parse(input[i]));
            }
            return grades;
        }

        public static decimal GetTotalBill(Client cl, Dictionary<string, decimal> products)
        {
            decimal total = 0m;
            foreach (var item in cl.ShopList.Keys)
            {
                total += ((decimal)cl.ShopList[item] * products[item]);
            }
            return total;
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Circle
    {
        public Point Centre { get; set; }
        public double Radius { get; set; }
    }

    public class Student
    {
        public List<double> Grades { get; set; }
        public string Name { get; set; }
        public double AverageGrade { get; set; }

        public Student(List<double> grades, string name)
        {
            this.Name = name;
            this.Grades = grades;
        }

    }

    public class Book
    {
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Book(string title, string author, string isbn, string publisher, decimal price, DateTime date)
        {
            this.Publisher = publisher;
            this.AuthorName = author;
            this.Price = price;
            this.Title = title;
            this.ISBN = isbn;
            this.ReleaseDate = date;
        }
    }

    public class Library
    {
        public List<Book> Books { get; set; }
        public string Name { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Name = "NaskoBooks";
        }

    }

    public class Client
    {
        public Dictionary<string, int> ShopList { get; set; }
        public decimal TotalBill { get; set; }
        public string Name { get; set; }

        public Client(string name)
        {
            this.Name = name;
            ShopList = new Dictionary<string, int>();
            TotalBill = 0;
        }
    }

    
}
