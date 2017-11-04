using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PE26FEB
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void Output(string outputCommand, List<Legion> legions)
        {
            if (Regex.IsMatch(outputCommand, @"^(\d+)\\([^=->:\s]+)$"))
            {
                var res = GetOutputDataFirstCase(legions, outputCommand);
                res = res.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
                foreach (var leg in res.Keys)
                {
                    Console.WriteLine($"{leg} -> {res[leg]}");
                }
            }
            else if (Regex.IsMatch(outputCommand, @"^[^=->:\s]+$"))
            {
                var res = GetOutputDataSecondCase(legions, outputCommand);
                res = res.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
                foreach (var leg in res.Keys)
                {
                    Console.WriteLine($"{res[leg]} : {leg}");
                }
            }
        }

        public static Dictionary<string, ulong> GetOutputDataFirstCase(List<Legion> legions, string outputCommand)
        {

            Match match = Regex.Match(outputCommand, @"^(\d+)\\([^=->:\s]+)$");
            ulong flagActivity = ulong.Parse(match.Groups[1].Value);
            List<Legion> result = new List<Legion>();
            result = legions.Where(x => x.Activity < flagActivity).ToList();
            var res = new Dictionary<string, ulong>();
            foreach (var leg in result)
            {
                for (int i = 0; i < leg.SoldierTypes.Count; i++)
                {
                    if (leg.SoldierTypes[i].Name.Equals(match.Groups[2].Value))
                    {
                        res[leg.Name] = leg.SoldierTypes[i].Count;
                    }
                }
            }
            return res;
        }
        
        public static Dictionary<string, ulong> GetOutputDataSecondCase(List<Legion> legions, string outputCommand)
        {
            var res = new Dictionary<string, ulong>();

            Match match = Regex.Match(outputCommand, @"^[^=->:\s]+$");

            foreach (var leg in legions)
            {
                for (int i = 0; i < leg.SoldierTypes.Count; i++)
                {
                    if (leg.SoldierTypes[i].Name.Equals(match.Value))
                    {
                        res[leg.Name] = leg.Activity;
                    }
                }
            }
            return res;
        }

        public static int IsExistingType(Legion legion, SoldierType st)
        {
            for (int i = 0; i < legion.SoldierTypes.Count; i++)
            {
                if (legion.SoldierTypes[i].Name.Equals(st.Name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int IsExistingLegion(List<Legion> legions, Legion leg)
        {
            for (int i = 0; i < legions.Count; i++)
            {
                if (legions[i].Name.Equals(leg.Name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static ulong GetHornetsMaxPower(List<ulong> list)
        {
            ulong sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        public static string FixFrequencies(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    sb.Append(str[i].ToString().ToUpper());
                }
                else if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    sb.Append(str[i].ToString().ToLower());
                }
                else
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }

        public static string ReverseString(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

        public static void HornetWings()
        {
            long wingFlaps = long.Parse(Console.ReadLine());
            double distanceForFlaps = double.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());

            double distanceTravelled = (wingFlaps / 1000.0) * distanceForFlaps;
            double time = wingFlaps / 100;
            time += (wingFlaps / endurance) * 5;

            Console.WriteLine("{0:F2} m.", distanceTravelled);
            Console.WriteLine("{0} s.", time);
        }

        public static void HornetComm()
        {
            List<string> privateMessages = new List<string>();
            List<string> recipients = new List<string>();

            List<string> broadcasts = new List<string>();
            List<string> frequencies = new List<string>();

            Regex privateMsg = new Regex(@"(?<recipient>^[0-9]+)( <-> )(?<message>[0-9A-Za-z]+$)");
            Regex brCast = new Regex(@"(?<message>^[^0-9]+)( <-> )(?<frequency>[0-9A-Za-z]+$)");

            string input = Console.ReadLine();

            while (!(input.Equals("Hornet is Green")))
            {
                if (privateMsg.IsMatch(input))
                {
                    string msg = privateMsg.Match(input).Groups[3].Value;
                    string recipient = privateMsg.Match(input).Groups[2].Value;
                    privateMessages.Add(msg);
                    recipients.Add(recipient);
                }
                if (brCast.IsMatch(input))
                {
                    string msg = brCast.Match(input).Groups[2].Value;
                    string frequency = brCast.Match(input).Groups[3].Value;
                    broadcasts.Add(msg);
                    frequencies.Add(frequency);
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < recipients.Count; i++)
            {
                string temp = recipients[i];
                recipients[i] = ReverseString(temp);
            }

            for (int i = 0; i < frequencies.Count; i++)
            {
                string temp = frequencies[i];
                frequencies[i] = FixFrequencies(temp);
            }

            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                for (int i = 0; i < frequencies.Count; i++)
                {
                    Console.WriteLine($"{frequencies[i]} -> {broadcasts[i]}");
                }
            }

            Console.WriteLine("Messages:");
            if (privateMessages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                for (int i = 0; i < recipients.Count; i++)
                {
                    Console.WriteLine($"{recipients[i]} -> {privateMessages[i]}");
                }
            }
        }

        public static void HornetAssault()
        {
            List<ulong> beehives = Console.ReadLine().Split(' ').Select(ulong.Parse).ToList();
            List<ulong> hornets = Console.ReadLine().Split(' ').Select(ulong.Parse).ToList();
            ulong sum = GetHornetsMaxPower(hornets);

            for (int i = 0; i < beehives.Count; i++)
            {
                if (sum > beehives[i])
                {
                    beehives.RemoveAt(i);
                    i--;
                }
                else
                {
                    beehives[i] -= sum;
                    if (beehives[i] == 0)
                    {
                        beehives.RemoveAt(i);
                        i--;
                    }
                    hornets.RemoveAt(0);
                    if (hornets.Count == 0)
                        break;
                    else
                        sum = GetHornetsMaxPower(hornets);
                }
            }

            if (beehives.Count == 0)
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
            else
                Console.WriteLine(string.Join(" ", beehives));
        }

        public static void HornetArmada()
        {
            var legions = new List<Legion>();
            Regex regex = new Regex(@"^(?<activity>\d+)( = )(?<legionName>[^=->:\s]+)( -> )(?<soldierType>[^=->:\s]+)(:)(?<soldierCount>\d+)$");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (!(regex.IsMatch(input)))
                    continue;

                ulong activity = ulong.Parse(regex.Match(input).Groups["activity"].Value);
                string legionName = regex.Match(input).Groups["legionName"].Value;
                string soldierType = regex.Match(input).Groups["soldierType"].Value;
                ulong soldierCount = ulong.Parse(regex.Match(input).Groups["soldierCount"].Value);

                SoldierType st = new SoldierType(soldierCount, soldierType);
                Legion legion = new Legion(legionName, activity);

                if (IsExistingLegion(legions, legion) != -1)
                {
                    legion = legions[IsExistingLegion(legions, legion)];
                    if (activity > legion.Activity)
                    {
                        legion.Activity = activity;
                    }
                    int flag = IsExistingType(legion, st);
                    if (flag != -1)
                    {
                        legion.SoldierTypes[flag].Count += st.Count;
                    }
                    else
                    {
                        legion.SoldierTypes.Add(st);
                    }
                    legion.CountOfSoldiers += soldierCount;
                }
                else
                {
                    legion.SoldierTypes.Add(st);
                    legion.CountOfSoldiers += soldierCount;
                    legions.Add(legion);
                }
            }

            string outputCommand = Console.ReadLine();
            Output(outputCommand, legions);
        }
    }
}

public class Legion
{
    public string Name { get; set; }
    public List<SoldierType> SoldierTypes { get; set; }
    public ulong Activity { get; set; }
    public ulong CountOfSoldiers { get; set; }

    public Legion(string name, ulong activity)
    {
        this.Name = name;
        this.Activity = activity;
        SoldierTypes = new List<SoldierType>();
        CountOfSoldiers = 0;
    }
}

public class SoldierType
{
    public ulong Count { get; set; }
    public string Name { get; set; }

    public SoldierType(ulong count, string name)
    {
        this.Count = count;
        this.Name = name;
    }
}
