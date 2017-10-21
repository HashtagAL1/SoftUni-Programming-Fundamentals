using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StudentGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            //var towns = new Dictionary<string, uint>();//dd-MMM-yyyy
            List<Town> towns = new List<Town>();

            string input = Console.ReadLine();

            while (!(input.Equals("End")))
            {
                string[] info;
                string townName = "";
                if (input.Contains("=>"))
                {
                    info = input.Split(new char[] { '=', '>', ' '},StringSplitOptions.RemoveEmptyEntries);
                    Town town = new Town(info[0], uint.Parse(info[1]));
                    towns.Add(town);
                    townName = town.Name;
                    input = Console.ReadLine();
                    continue;
                }
                info = input.Split(new char[] { ' ', '|'},StringSplitOptions.RemoveEmptyEntries);
                Student stud = new Student(info[0], info[1], DateTime.ParseExact(info[2], "dd-MMM-yyyy",CultureInfo.InvariantCulture));
                Group gr = new Group(towns[GetIndexOfTown(townName, towns)].Name);
                gr.Students.Add(stud);
            }
        }

        public static int GetIndexOfTown(string name, List<Town> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }
    }

    class Student
    {
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public DateTime RegDate { get; set; }

        public Student(string name, string email, DateTime date)
        {
            this.Name = name;
            this.EmailAddress = email;
            this.RegDate = date;
        }

    }

    class Group
    {
        public string Town { get; set; }
        public List<Student> Students { get; set; }

        public Group(string townName)
        {
            this.Town = townName;
            this.Students = new List<Student>();
        }
    }

    class Town
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; }

        public uint Capacity { get; set; }

        public Town(string name, uint capacity)
        {
            this.Groups = new List<Group>();
            this.Name = name;
            this.Capacity = capacity;
        }
    }
}
