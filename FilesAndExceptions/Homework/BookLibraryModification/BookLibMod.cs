using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace BookLibraryModification
{
    class BookLibMod
    {
        static void Main(string[] args)
        {
            File.Delete("output.txt");
            Library lib = new Library();
            var result = new Dictionary<string, DateTime>();
            string[] lines = File.ReadAllLines("input.txt");
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] input = lines[i].Split(' ');
                string title = input[0];
                string author = input[1];
                string publisher = input[2];
                DateTime relDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                string isbn = input[4];
                decimal price = decimal.Parse(input[5]);
                Book book = new Book(title, author, isbn, publisher, price, relDate);
                lib.Books.Add(book);
            }
            DateTime markerDate = DateTime.ParseExact(lines[lines.Length - 1], "dd.MM.yyyy", CultureInfo.InvariantCulture);

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
                File.AppendAllText("output.txt", $"{book.Key} -> {book.Value.ToString("dd.MM.yyyy")}" + Environment.NewLine);
                //Console.WriteLine("{0} -> {1}", book.Key, book.Value.ToString("dd.MM.yyyy"));
            }
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
}
