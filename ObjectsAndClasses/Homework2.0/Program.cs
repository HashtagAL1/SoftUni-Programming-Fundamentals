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
            List<User> usersList = new List<User>();//list to hold users
            string input = Console.ReadLine();
            

            while (!(input.Equals("end of dates")))
            {
                string[] userDateInfo = input.Split(' ');
                User user = new User(userDateInfo[0]);
                string[] dates;
                //check if dates are available
                try
                {
                    dates = userDateInfo[1].Split(',');
                }
                catch (IndexOutOfRangeException ioor)
                {
                    usersList.Add(user);
                    input = Console.ReadLine();
                    userDateInfo = input.Split(' ');
                    dates = userDateInfo[1].Split(',');
                    continue;
                }
                //check if user already exists: yes-> set reference to it; no -> add it
                if (ContainsUser(user, usersList) != -1)
                {
                    user = usersList[ContainsUser(user, usersList)];
                }
                else
                    usersList.Add(user);
                //add the dates
                AddDates(user, dates);

                input = Console.ReadLine();
            }
            //sort dates per user
            SortDates(usersList);

            input = Console.ReadLine();
            string[] userCommentsInfo = input.Split('-');

            while (!(input.Equals("end of comments")))
            {
                User user = new User(userCommentsInfo[0]);
                if (userCommentsInfo.Length <= 1)
                {
                    if (ContainsUser(user, usersList) != -1)
                    {
                        user = usersList[ContainsUser(user, usersList)];
                    }
                    input = Console.ReadLine();
                    userCommentsInfo = input.Split('-');
                    continue;
                }

                string comment = userCommentsInfo[1];
                if (ContainsUser(user, usersList) != -1)
                {
                    user = usersList[ContainsUser(user, usersList)];
                }
                user.Comments.Add(comment);

                input = Console.ReadLine();
                userCommentsInfo = input.Split('-');
            }
            RemoveRepeatingCommentsDates(usersList);
            List<User> outputList = SortUsersByName(usersList);
            Output(outputList);

        }

        public static void AddDates(User user, string[] dates)
        {
            for (int i = 0; i < dates.Length; i++)
            {
                DateTime date = DateTime.ParseExact(dates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                user.Dates.Add(date);
            }
        }

        public static void Output(List<User> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                /*if (list[i].Dates.Count < 1)
                {
                    continue;
                }*/
                
                Console.WriteLine(list[i].Name);
                Console.WriteLine("Comments:");
                PrintComments(list[i]);
                Console.WriteLine("Dates attended:");
                PrintDates(list[i]);
            }
        }

        public static void PrintComments(User user)
        {
            for (int i = 0; i < user.Comments.Count; i++)
            {
                Console.WriteLine($"- {user.Comments[i]}");
            }
        }

        public static void PrintDates(User user)
        {
            for (int i = 0; i < user.Dates.Count; i++)
            {
                Console.WriteLine($"-- {user.Dates[i].ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            }
        }



        public static void RemoveRepeatingCommentsDates(List<User> userList)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                userList[i].Comments = userList[i].Comments.Distinct().ToList();
                userList[i].Dates = userList[i].Dates.Distinct().ToList();
            }
        }

        public static void SortDates(List<User> usersList)
        {
            for (int i = 0; i < usersList.Count; i++)
            {
                usersList[i].Dates = usersList[i].Dates.OrderBy(x => x).ToList();
            }
        }

        public static int ContainsUser(User user, List<User> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (user.Name.Equals(list[i].Name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static List<User> SortUsersByName(List<User> list)
        {
            List<User> res = list.OrderBy(x => x.Name).ToList();
            return res;
        }

    }

    public class User
    {
        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            this.Name = name;
            this.Comments = new List<string>();
            this.Dates = new List<DateTime>();
        }
    }
}
