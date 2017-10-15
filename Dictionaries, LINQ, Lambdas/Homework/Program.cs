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
            MinerTask();


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
                //if domain == us || uk don't add them - add the rest
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
    }
}
