using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace StudentGroupsProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();
            string townInput = "";
            string input = Console.ReadLine();

            while (!(input.Equals("End")))
            {
                Town town = new Town();
                string[] info;
                if (input.Contains("=>"))
                {
                    info = input.Split(new char[] { '>', '='},StringSplitOptions.RemoveEmptyEntries);
                    town.Name = info[0];
                    string[] addInfo = info[1].Trim().Split(' ');
                    town.Capacity = int.Parse(addInfo[0]);
                    towns.Add(town);
                    townInput = info[0];
                    input = Console.ReadLine();
                    continue;
                }
                info = input.Split(new char[] { '|'}, StringSplitOptions.RemoveEmptyEntries);
                Student stud = new Student(info[0].Trim(), info[1].Trim(), DateTime.ParseExact(info[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture));
                towns[GetTownIndex(towns, townInput)].Students.Add(stud);
                input = Console.ReadLine();
            }

            //order students in each town by reg. date, then by name, then by email address
            for (int i = 0; i < towns.Count; i++)
            {
                towns[i].Students = towns[i].Students.OrderBy(x => x.Reg_date).ThenBy(y => y.Name).ThenBy(e => e.Email_address).ToList();
            }
            CreateGroups(towns);
            //sort towns by name in ascending order
            towns = towns.OrderBy(x => x.Name).ToList();

            Output(towns, GetNumberOfGroups(towns));

        }

        public static int GetTownIndex(List<Town> list, string townName)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (townName.Equals(list[i].Name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int GetNumberOfGroups(List<Town> list)
        {
            int res = 0;
            for (int i = 0; i < list.Count; i++)
            {
                res += list[i].Groups.Count;
            }
            return res;
        }

        public static void Output(List<Town> towns, int groups)
        {
            Console.WriteLine($"Created {groups} groups in {towns.Count} towns:");
            for (int i = 0; i < towns.Count; i++)
            {
                for (int j = 0; j < towns[i].Groups.Count; j++)
                {

                    Console.Write(towns[i].Name + "=> ");
                    for (int k = 0; k < towns[i].Groups[j].Students.Count; k++)
                    {
                        if (k == towns[i].Groups[j].Students.Count - 1)
                        {
                            Console.WriteLine(towns[i].Groups[j].Students[k].Email_address);
                        }
                        else
                            Console.Write(towns[i].Groups[j].Students[k].Email_address + ", ");
                    }
                }
            }

        }

        public static void CreateGroups(List<Town> towns)
        {
            int tempNumOfGroups = 0;
            for (int i = 0; i < towns.Count; i++)
            {
                
                int number_of_groups = 0;
                if (towns[i].Students.Count % towns[i].Capacity == 0)
                {
                    number_of_groups = towns[i].Students.Count / towns[i].Capacity;
                }
                else if (towns[i].Students.Count < towns[i].Capacity)
                {
                    number_of_groups = 1;
                }
                else
                    number_of_groups = (towns[i].Students.Count / towns[i].Capacity) + 1;
                for (int j = 0, step = 0; j < number_of_groups; j++, step += towns[i].Capacity)
                {
                    Group group = new Group();
                    tempNumOfGroups++;
                    group.Students.AddRange(towns[i].Students.Skip(step).Take(towns[i].Capacity));
                    towns[i].Groups.Add(group);
                }
            }
        }
    }

    class Town
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Group> Groups { get; set; }
        public List<Student> Students { get; set; }

        public Town(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Groups = new List<Group>();
            this.Students = new List<Student>();
        }

        public Town()
        {
            this.Name = "";
            this.Capacity = 0;
            this.Groups = new List<Group>();
            this.Students = new List<Student>();
        }

    }

    class Group
    {
        public List<Student> Students { get; set; }
        
        public Group()
        {
            this.Students = new List<Student>();
        }
    }
    
    class Student
    {
        public string Name { get; set; }
        public string Email_address { get; set; }
        public DateTime Reg_date { get; set; }

        public Student(string name, string email, DateTime reg)
        {
            this.Name = name;
            this.Email_address = email;
            this.Reg_date = reg;
        }

    }
}
