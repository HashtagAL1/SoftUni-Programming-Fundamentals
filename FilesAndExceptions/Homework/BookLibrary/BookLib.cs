using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace BookLibrary
{
    class BookLib
    {
        static void Main(string[] args)
        {
            File.Delete("output.txt");
            Library lib = new Library();
            var authors = new Dictionary<string, decimal>();
            string[] lines = File.ReadAllLines("input.txt");
            //input of books
            for (int i = 1; i < lines.Length; i++)
            {
                string[] input = lines[i].Split(' ');
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
                File.AppendAllText("output.txt", $"{author.Key} -> {author.Value}" + Environment.NewLine);                
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
