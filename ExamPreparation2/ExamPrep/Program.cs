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

        public static void CharityMarathon()
        {
            uint marathonLength = uint.Parse(Console.ReadLine());
            uint runners = uint.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            uint lapLength = uint.Parse(Console.ReadLine());
            uint trackCapacity = uint.Parse(Console.ReadLine());
            decimal moneyPerKilo = decimal.Parse(Console.ReadLine());

            uint maximumRunners = marathonLength * trackCapacity;
            if (maximumRunners < runners)
            {
                runners = maximumRunners;
            }

            ulong totalMeters = (ulong)laps * (ulong)lapLength * (ulong)runners;

            decimal money = moneyPerKilo * (totalMeters / 1000);
            Console.WriteLine("Money raised: {0:F2}", money);
        }

        public static void Ladybugs()
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int[] field = new int[sizeOfField];
            for (int i = 0; i < field.Length; i++)
            {
                if (indexes.Contains(i))
                    field[i] = 1;
                else
                    field[i] = 0;
            }

            while (!(command.Equals("end")))
            {
                string[] info = command.Split(' ');
                long startIndex = long.Parse(info[0]);
                long move = long.Parse(info[2]);
                string position = info[1];
                if ((startIndex >= field.Length || startIndex < 0) || field[startIndex] == 0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                field[startIndex] = 0;

                if (position.Equals("right"))
                {
                    long newIndex = move + startIndex;
                    long currentIndex = newIndex;
                    while (currentIndex < field.Length)
                    {
                        if (field[currentIndex] == 1)
                        {
                            currentIndex += currentIndex;
                        }
                        else
                        {
                            field[currentIndex] = 1;
                            break;
                        }
                    }
                }
                else if (position.Equals("left"))
                {
                    long newIndex = startIndex - move;
                    long currentIndex = newIndex;
                    while (currentIndex >= 0)
                    {
                        if (field[currentIndex] == 1)
                        {
                            currentIndex -= currentIndex;
                        }
                        else
                        {
                            field[currentIndex] = 1;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }

        public static void NetherRelms()
        {
            var nameHealth = new SortedDictionary<string, long>();
            var nameDamage = new SortedDictionary<string, double>();
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                nameHealth[input[i]] = 0;
                nameDamage[input[i]] = 0;

                foreach (Match m in Regex.Matches(input[i], @"[^0-9\.\-\*\/\+]"))
                {
                    nameHealth[input[i]] += char.Parse(m.Value);
                }

                foreach (Match m in Regex.Matches(input[i], @"(\-\d+?\.\d+?)|(\+?\d+?\.\d+?)|(\-\d+)|(\+?\d+)"))
                {
                    nameDamage[input[i]] += double.Parse(m.Value);
                }

                int multiplyPower = Regex.Matches(input[i], @"\*").Count;
                int divPower = Regex.Matches(input[i], @"\/").Count;
                if (multiplyPower > 0)
                {
                    nameDamage[input[i]] *= Math.Pow(2, multiplyPower);
                }
                if (divPower > 0)
                {
                    nameDamage[input[i]] /= Math.Pow(2, divPower);
                }
            }

            foreach (var name in nameHealth.Keys)
            {
                Console.WriteLine("{0} - {1} health, {2:F2} damage", name, nameHealth[name], nameDamage[name]);
            }
        }//fix needed

        public static void Roli()
        {
            var idEv = new Dictionary<long, string>();
            var evPart = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (!(input.Equals("Time for Code")))
            {
                if (!(Regex.IsMatch(input, @"^[0-9]+(\s\#\S+)")))
                {
                    input = Console.ReadLine();
                    continue;
                }
                List<string> participants = new List<string>();


                string[] info = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                long id = long.Parse(info[0]);
                string eventt = info[1];

                for (int i = 2; i < info.Length; i++)
                {
                    if (Regex.IsMatch(info[i], @"\@[a-zA-z0-9\'\-]+"))
                    {
                        participants.Add(info[i]);
                    }
                }

                if (idEv.ContainsKey(id))
                {
                    if (evPart.ContainsKey(eventt))
                    {
                        for (int i = 2; i < participants.Count; i++)
                        {
                            evPart[idEv[id]].Add(participants[i]);
                        }
                    }
                }
                else
                {
                    idEv[id] = eventt;
                    evPart[eventt] = new List<string>();
                    for (int i = 2; i < info.Length; i++)
                    {
                        evPart[idEv[id]].Add(info[i]);
                    }
                }

                input = Console.ReadLine();
            }

            var final = evPart.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var ev in final.Keys)
            {
                final[ev].Sort();
                List<string> players = final[ev].Distinct().ToList();
                string even = ev.Remove(0, 1);
                Console.WriteLine(even + " - " + players.Count);
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(players[i]);
                }
            }

        }
    }
}
