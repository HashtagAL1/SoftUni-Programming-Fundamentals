using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Homework2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Learner> result = new List<Learner>();
            string inputData = Console.ReadLine();            
            string[] input = inputData.Split(' ');

            while (!(inputData.Equals("end of dates")))
            {
                string name = input[0];
                Learner noob = new Learner();
                noob.Name = name;

                if (input.Length <= 1)
                {
                    inputData = Console.ReadLine();
                    input = inputData.Split(' ');
                    result.Add(noob);
                    continue;
                }

                string[] datesInfo = input[1].Split(',');
                noob.Name = name;

                for (int i = 0; i < datesInfo.Length; i++)
                {
                    DateTime date = DateTime.ParseExact(datesInfo[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (ContainsLearner(result, noob) != -1)
                    {
                        noob = result[ContainsLearner(result, noob)];
                    }
                    else
                        result.Add(noob);
                    noob.Dates.Add(date);

                }
                inputData = Console.ReadLine();
                input = inputData.Split(' ');
            }

            string comments = Console.ReadLine();
            string[] commentsSection = comments.Split('-');

            while (!(comments.Equals("end of comments")))
            {
                string name = commentsSection[0];
                Learner noob = new Learner();
                if (commentsSection.Length <= 1)
                {
                    comments = Console.ReadLine();
                    commentsSection = comments.Split('-');
                    continue;
                }
                noob.Name = name;
                if (ContainsLearner(result, noob) != -1)
                {
                    noob = result[ContainsLearner(result, noob)];
                }
                noob.Comments.Add(commentsSection[1]);
                comments = Console.ReadLine();
                commentsSection = comments.Split('-');
            }
            result = result.OrderBy(x => x.Name).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                PrintComments(result[i]);
                PrintDates(result[i]);
            }
        }

        public static void PrintComments(Learner learner)
        {
            Console.WriteLine(learner.Name);
            Console.WriteLine("Comments:");
            for (int i = 0; i < learner.Comments.Count; i++)
            {
                Console.WriteLine($"- {learner.Comments[i]}");
            }
        }

        public static void PrintDates(Learner learner)
        {
            learner.Dates = learner.Dates.OrderBy(x => x).ToList();
            Console.WriteLine("Dates attended:");
            for (int i = 0; i < learner.Dates.Count; i++)
            {
                Console.WriteLine($"-- {learner.Dates[i].ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            }
        }

        public static int ContainsLearner(List<Learner> list, Learner learner)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(learner.Name))
                {
                    return i;
                }
            }
            return -1;
        }
    }
    public class Learner
    {
        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }

        public string Name { get; set; }

        public Learner()
        {
            this.Comments = new List<string>();
            this.Dates = new List<DateTime>();
            this.Name = "Learner";
        }
    }
}
