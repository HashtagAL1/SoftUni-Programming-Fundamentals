using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void LegendaryFarming()
        {
            var legendaryItems = new Dictionary<string, uint>
            {
                {"shards", 0 },
                { "fragments", 0},
                { "motes", 0}
            };
            var result = new Dictionary<string, string>
            {
                {"shards", "Shadowmourne" },
                {"fragments", "Valanyr" },
                {"motes", "Dragonwrath" }
            };
            var junkItems = new Dictionary<string, uint>();
            int cnt = 0;
            bool IsFound = false;
            string legendaryItem = "";
            string flag = "";

            while (cnt <= 10)
            {
                cnt++;
                string[] input = Console.ReadLine().ToLower().Split(' ');
                for (int i = 1, j = i - 1; i < input.Length; i += 2, j += 2)
                {
                    if (input[i].Equals("shards") || input[i].Equals("motes") || input[i].Equals("fragments"))
                    {
                        legendaryItems[input[i]] += uint.Parse(input[j]);
                        if (legendaryItems[input[i]] >= 250)
                        {
                            legendaryItem = result[input[i]];
                            flag = input[i];
                            IsFound = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!(junkItems.ContainsKey(input[i])))
                        {
                            junkItems[input[i]] = 0;
                        }
                        junkItems[input[i]] += uint.Parse(input[j]);
                    }

                }
                if (IsFound)
                {
                    break;
                }
            }
            legendaryItems[flag] -= 250;
            var sortedLegItems = legendaryItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            var sortedJunk = junkItems.OrderBy(x => x.Key);

            Console.WriteLine($"{legendaryItem} obtained!");

            foreach (var legItem in sortedLegItems)
            {

                Console.WriteLine(legItem.Key + ": " + legItem.Value);
            }
            foreach (var junk in sortedJunk)
            {
                Console.WriteLine(junk.Key + ": " + junk.Value);
            }
        }

        public static void PrintStringList(List<string> list)
        {
            list.Sort();
            list = list.Distinct().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    Console.Write($"{list[i]}");
                }
                else
                {
                    Console.Write($"{list[i]}, ");
                }
            }
        }

        public static long GetSum(List<long> list)
        {
            long sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        public static void PopulationCounter()
        {
            var countries = new Dictionary<string, Dictionary<string, long>>();//country, <city, city population>
            string[] input = Console.ReadLine().Split('|');
            if (input.Length <= 1 || input[0].Equals("report"))
            {
                return;
            }

            while (!(input[0].Equals("report")))
            {
                string cityName = input[0];
                string countryName = input[1];
                long population = long.Parse(input[2]);

                if (!(countries.ContainsKey(countryName)))
                {
                    countries[countryName] = new Dictionary<string, long>();
                }
                if (!(countries[countryName].ContainsKey(cityName)))
                {
                    countries[countryName][cityName] = population;
                }

                input = Console.ReadLine().Split('|');
                if (input.Length <= 1)
                {
                    break;
                }
            }

            var sorted = countries.OrderByDescending(x => GetSum(x.Value.Values.ToList()));
            foreach (var country in sorted)
            {
                var ordered = country.Value.OrderByDescending(x => x.Value);
                Console.WriteLine($"{country.Key} (total population: {GetSum(country.Value.Values.ToList())})");
                foreach (var city in ordered)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }

        public static void UserLogs()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '=', '\'' }, StringSplitOptions.RemoveEmptyEntries);

            var users = new SortedDictionary<string, Dictionary<string, int>>();

            if (input.Length <= 1)
            {
                Console.WriteLine();
                return;
            }
            while (!(input[0].Equals("end")))
            {
                string userIP = input[1];
                string message = input[3];
                string userName = input[5];

                if (!(users.ContainsKey(userName)))
                {
                    users[userName] = new Dictionary<string, int>();
                }

                if (!(users[userName].ContainsKey(userIP)))
                {
                    users[userName][userIP] = 0;
                }

                users[userName][userIP]++;


                input = Console.ReadLine().Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length <= 1 || input[0].Equals("end"))
                {
                    break;
                }
            }
            foreach (var user in users)
            {

                List<string> res = new List<string>();
                Console.WriteLine(user.Key + ": ");

                foreach (var ip in users[user.Key])
                {
                    res.Add(ip.Key + " => " + ip.Value);
                }

                for (int j = 0; j < res.Count; j++)
                {
                    if (j == res.Count - 1)
                    {
                        Console.WriteLine(res[j] + ".");
                    }
                    else
                    {
                        Console.Write(res[j] + ", ");
                    }
                }
            }

        }

        public static void MinerTask()
        {
            string resource = Console.ReadLine();
            if (resource.Equals("") || resource.Equals("stop"))
            {
                Console.WriteLine();
                return;
            }
            int quantity = int.Parse(Console.ReadLine());
            var result = new Dictionary<string, int>();

            while (!(resource.Equals("stop")))
            {

                if (!(result.ContainsKey(resource)))
                {
                    result[resource] = 0;
                }

                result[resource] += quantity;
                resource = Console.ReadLine();
                if (resource.Equals("") || resource.Equals("stop"))
                {
                    break;
                }
                quantity = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\n", result.Select(item => item.Key + " -> " + item.Value)));
        }

        public static int GetType(char input)
        {
            switch (input)
            {
                case 'S':
                    return 4;
                case 'H':
                    return 3;
                case 'D':
                    return 2;
                case 'C':
                    return 1;
                default:
                    return 0;
            }
        }

        public static int GetPowerOfCard(string str)
        {
            string res = "";
            for (int i = 0; i < str.Length - 1; i++)
            {
                res += str[i];
            }
            switch (res)
            {
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return 0;
            }
        }

        public static void Phonebook()
        {
            var phonebook = new SortedDictionary<string, string>();
            string command = Console.ReadLine();
            while (!(command.Equals("END")))
            {
                var input = command.Split(' ');
                if (input[0].Equals("A"))
                {
                    phonebook[input[1]] = input[2];
                }
                else if (input[0].Equals("S"))
                {
                    if (phonebook.ContainsKey(input[1]))
                    {
                        Console.WriteLine(input[1] + " -> " + phonebook[input[1]]);
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input[1]} does not exist.");
                    }
                }
                else if (command.Equals("ListAll"))
                {
                    ListAll(phonebook);
                }
                command = Console.ReadLine();
            }
        }

        public static void ListAll(SortedDictionary<string, string> dict)
        {
            Console.WriteLine(string.Join("\n", dict.Select(item => item.Key + " -> " + item.Value)));            
        }

        public static void PrintDictItems(Dictionary<string, ulong> dict)
        {
            Console.WriteLine(string.Join("\n", dict.Select(element => element.Key  + ": " + element.Value)));
        }        

        public static void FixEmails()
        {
            string name = Console.ReadLine();
            string email = Console.ReadLine();
            var emails = new Dictionary<string, string>();
            while (!(name.Equals("stop")))
            {
                string domain = email[email.Length - 3] + "" + email[email.Length - 2] + "" + email[email.Length - 1];
                if (!(domain.Equals(".us") || domain.Equals(".uk")))
                {
                    emails[name] = email;
                }
                name = Console.ReadLine();
                if (name.Equals("stop"))
                {
                    break;
                }
                email = Console.ReadLine();

            }

            Console.WriteLine(string.Join("\n", emails.Select(element => element.Key + " -> " + element.Value)));
        }        

        public static void HandsOfCards()
        {
            string[] input = Console.ReadLine().Split(':');
            if (input.Length <= 1)
            {
                Console.WriteLine();
                return;
            }
            string[] hand = input[1].Split(new char[] { ',', ':', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var players = new Dictionary<string, int>();
            var takenCards = new Dictionary<string, List<string>>();

            while (!(input[0].Equals("JOKER")))
            {
                var playerName = input[0].Trim();
                if (!(players.ContainsKey(playerName)))
                {
                    players[playerName] = 0;
                    takenCards[playerName] = new List<string>();
                }
                for (int i = 0; i < hand.Length; i++)
                {
                    var takenCard = hand[i];
                    if (takenCards[playerName].Contains(takenCard))
                    {
                        continue;
                    }
                    else
                    {
                        takenCards[playerName].Add(takenCard);
                        int type = GetType(takenCard[takenCard.Length - 1]);
                        int power = GetPowerOfCard(takenCard);
                        players[playerName] += (type * power);
                    }
                }
                input = Console.ReadLine().Split(':');
                if (input.Length > 1)
                {
                    hand = input[1].Split(new char[] { ',', ' ', ':', '.' }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                    break;
            }

            Console.WriteLine(string.Join("\n", players.Select(item => item.Key + ": " + item.Value)));
        }

        public static void LogsAggregator()
        {
            int n = int.Parse(Console.ReadLine());
            var userAndTime = new SortedDictionary<string, uint>();
            var userAndIPs = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string userName = input[1];
                string ip = input[0];
                uint duration = uint.Parse(input[2]);

                if (!(userAndTime.ContainsKey(userName)))
                {
                    userAndTime[userName] = 0;
                }
                if (!(userAndIPs.ContainsKey(userName)))
                {
                    userAndIPs[userName] = new List<string>();
                }

                userAndTime[userName] += duration;
                userAndIPs[userName].Add(ip);
            }

            foreach (var user in userAndTime)
            {
                Console.Write($"{user.Key}: {user.Value} [");
                PrintStringList(userAndIPs[user.Key]);
                Console.WriteLine("]");
            }
        }
    }
}
