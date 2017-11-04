using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {            
        }

        public static string ReverseTeam(string team)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = team.Length - 1; i > -1; i--)
            {
                sb.Append(team[i]);
            }
            return sb.ToString();
        }

        public static string FixKey(string key)
        {
            string pattern = @"[\+\*\-\.\/\=\'\;\:\?\|\^\$]";
            StringBuilder sb = new StringBuilder();
            sb.Append(key);
            for (int i = 0; i < sb.ToString().Length; i++)
            {
                if (Regex.IsMatch(sb.ToString(), pattern))
                {
                    if (i == 0)
                    {
                        sb.Insert(0, '\\');
                        i++;
                    }
                    else
                    {
                        sb.Insert(i, '\\');
                        i++;
                    }
                }
            }

            return sb.ToString();
        }

        public static List<int> LastEven(List<int> list, int count)
        {

            List<int> temp = new List<int>();
            list.Reverse();
            foreach (var num in list)
            {
                if (num % 2 == 0)
                {
                    temp.Add(num);
                }
            }
            list.Reverse();
            if (count >= temp.Count)
            {
                return temp;
            }
            
            temp = temp.Take(count).ToList();

            return temp;
        }

        public static List<int> LastOdd(List<int> list, int count)
        {
            List<int> temp = new List<int>();
            list.Reverse();
            foreach (var num in list)
            {
                if (num % 2 != 0)
                {
                    temp.Add(num);
                }
            }
            list.Reverse();
            if (count >= temp.Count)
            {
                return temp;
            }
            temp = temp.Take(count).ToList();
            
            return temp;
        }

        public static List<int> FirstOdd(List<int> list, int count)
        {

            List<int> temp = new List<int>();
            foreach (var num in list)
            {
                if (num % 2 != 0)
                {
                    temp.Add(num);
                }
            }
            if (count >= temp.Count)
            {
                return temp;
            }

            return temp.Take(count).ToList();
        }

        public static List<int> FirstEven(List<int> list, int count)
        {
            List<int> temp = new List<int>();
            foreach (var num in list)
            {
                if (num % 2 == 0)
                {
                    temp.Add(num);
                }
            }
            if (count >= temp.Count)
            {
                return temp;
            }
            
            return temp.Take(count).ToList();
        }

        public static int MinEven(List<int> list)
        {
            List<int> temp = new List<int>();
            foreach (var num in list)
            {
                if (num % 2 == 0)
                {
                    temp.Add(num);
                }
            }
            if (temp.Count == 0)
            {
                return -1;
            }
            int min = temp.Min();
            return list.LastIndexOf(min);
        }

        public static int MinOdd(List<int> list)
        {
            List<int> temp = new List<int>();
            foreach (var num in list)
            {
                if (num % 2 != 0)
                {
                    temp.Add(num);
                }
            }
            if (temp.Count == 0)
            {
                return -1;
            }
            int min = temp.Min();
            return list.LastIndexOf(min);
        }

        public static int MaxEven(List<int> list)
        {
            List<int> temp = new List<int>();
            foreach (var num in list)
            {
                if (num % 2 == 0)
                {
                    temp.Add(num);
                }
            }
            if (temp.Count == 0)
            {
                return -1;
            }
            int max = temp.Max();
            return list.LastIndexOf(max);

        }

        public static int MaxOdd(List<int> list)
        {
            List<int> temp = new List<int>();
            foreach (var num in list)
            {
                if (num % 2 != 0)
                {
                    temp.Add(num);
                }
            }
            if (temp.Count == 0)
            {
                return -1;
            }
            int max = temp.Max();
            return list.LastIndexOf(max);
        }

        public static List<int> Exchange(List<int> list, int index)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i <= index; i++)
            {
                temp.Add(list[i]);
            }
            list.RemoveRange(0, index + 1);
            list = list.Concat(temp).ToList();
            return list;
        }

        public static void SweetDessert()
        {
            decimal money_Ivancho = decimal.Parse(Console.ReadLine());
            uint guests = uint.Parse(Console.ReadLine());
            decimal price_banana = decimal.Parse(Console.ReadLine());
            decimal price_eggs = decimal.Parse(Console.ReadLine());
            decimal price_kilo_berries = decimal.Parse(Console.ReadLine());
            decimal sets = guests / 6;
            if (guests % 6 != 0)
            {
                sets++;
            }

            decimal cost = sets * (2 * price_banana + 4 * price_eggs + 0.2m * price_kilo_berries);

            if (cost <= money_Ivancho)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", cost);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", Math.Abs(cost - money_Ivancho));
            }
        }

        public static void ArrayManipulator()
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (!(command.Equals("end")))
            {
                string[] info = command.Split(' ');
                if (info[0].Equals("exchange"))
                {
                    int index = int.Parse(info[1]);
                    if (index < 0 || index >= input.Count)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }
                    input = Exchange(input, index);
                }
                else if (info[0].Equals("max"))
                {
                    if (info[1].Equals("odd"))
                    {
                        int max = MaxOdd(input);
                        if (max == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                            Console.WriteLine(max);
                    }
                    else if (info[1].Equals("even"))
                    {
                        int max = MaxEven(input);
                        if (max == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                            Console.WriteLine(max);
                    }
                }
                else if (info[0].Equals("min"))
                {
                    if (info[1].Equals("odd"))
                    {
                        int min = MinOdd(input);
                        if (min == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                            Console.WriteLine(min);
                    }
                    else if (info[1].Equals("even"))
                    {
                        int min = MinEven(input);
                        if (min == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                            Console.WriteLine(min);
                    }
                }
                else if (info[0].Equals("first"))
                {
                    int count = int.Parse(info[1]);
                    if (count > input.Count || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (info[2].Equals("even"))
                    {
                        Console.Write('[');
                        Console.Write(string.Join(", ", FirstEven(input, count)));
                        Console.WriteLine(']');
                    }
                    else if (info[2].Equals("odd"))
                    {
                        Console.Write('[');
                        Console.Write(string.Join(", ", FirstOdd(input, count)));
                        Console.WriteLine(']');
                    }
                }
                else if (info[0].Equals("last"))
                {
                    int count = int.Parse(info[1]);
                    if (count > input.Count || count < 0)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (info[2].Equals("even"))
                    {
                        List<int> temp = LastEven(input, count);
                        temp.Reverse();
                        Console.Write('[');
                        Console.Write(string.Join(", ", temp));
                        Console.WriteLine(']');
                    }
                    else if (info[2].Equals("odd"))
                    {
                        List<int> temp = LastOdd(input, count);
                        temp.Reverse();
                        Console.Write('[');
                        Console.Write(string.Join(", ", temp));
                        Console.WriteLine(']');
                    }
                }


                command = Console.ReadLine();
            }
            Console.Write('[');
            Console.Write(string.Join(", ", input));
            Console.WriteLine(']');
        }

        public static void FootballLeague()
        {
            var standings = new Dictionary<string, uint>();
            var team_goals = new Dictionary<string, uint>();
            string key = FixKey(Console.ReadLine());
            string footbal_match = Console.ReadLine();
            string pattern = $@"(?<={key})\w+(?={key})";


            while (!(footbal_match.Equals("final")))
            {
                string[] res = Regex.Match(footbal_match, @"\d+:\d+").Value.Split(':');
                int i = 0;
                List<string> teams = new List<string>();
                List<uint> goals = new List<uint>();
                foreach (Match m in Regex.Matches(footbal_match, pattern))
                {
                    string team = m.Value;
                    team = ReverseTeam(team).ToUpper();

                    if (!(standings.ContainsKey(team)))
                    {
                        standings[team] = 0;
                    }
                    if (!(team_goals.ContainsKey(team)))
                    {
                        team_goals[team] = 0;
                    }
                    team_goals[team] += uint.Parse(res[i]);
                    teams.Add(team);
                    goals.Add(uint.Parse(res[i]));
                    i++;
                }

                if (goals[0] > goals[1])
                {
                    standings[teams[0]] += 3;
                }
                else if (goals[0] < goals[1])
                {
                    standings[teams[1]] += 3;
                }
                else
                {
                    standings[teams[0]] += 1;
                    standings[teams[1]] += 1;
                }


                footbal_match = Console.ReadLine();
            }
            var result = standings.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            var topScorers = team_goals.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine("League standings:");
            int cnt = 1;
            foreach (var team in result.Keys)
            {
                Console.WriteLine($"{cnt}. {team} {result[team]}");
                cnt++;
            }
            cnt = 0;
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in topScorers.Keys)
            {
                if (cnt > 2)
                {
                    break;
                }
                Console.WriteLine($"- {team} -> {topScorers[team]}");
                cnt++;
            }
        }

        public static void CubicsMessages()
        {

            var messages = new Dictionary<string, string>();
            Regex validMessage = new Regex(@"^(\d+)([A-Za-z]+)([^A-Za-z]*$)");
            string input = Console.ReadLine();

            while (!(input.Equals("Over!")))
            {//
                StringBuilder verificationCode = new StringBuilder();
                int length = int.Parse(Console.ReadLine());
                Regex message = new Regex($@"(?<=[0-9])[A-Za-z]+(?=.*)");
                if (!(validMessage.IsMatch(input)))
                {
                    input = Console.ReadLine();
                    continue;
                }

                string msg = message.Match(input).Value;//key
                if (msg.Length != length)
                {
                    input = Console.ReadLine();
                    continue;
                }
                foreach (Match m in Regex.Matches(input, @"\d"))
                {
                    int index = int.Parse(m.Value);
                    if (index < 0 || index >= msg.Length)
                    {
                        verificationCode.Append(" ");
                    }
                    else
                        verificationCode.Append(msg[index]);
                }

                string ver = verificationCode.ToString();
                Console.WriteLine($"{msg} == {ver}");


                input = Console.ReadLine();
            }//
        }
    }
}
