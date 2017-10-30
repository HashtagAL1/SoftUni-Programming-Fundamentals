using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void WalkingSino()
        {
            DateTime input = DateTime.ParseExact(Console.ReadLine(), "H:m:s", CultureInfo.InvariantCulture);;
            ulong steps = ulong.Parse(Console.ReadLine()) % 86400;
            ulong timeForStep = ulong.Parse(Console.ReadLine()) % 86400;

            TimeSpan timeHome = TimeSpan.FromSeconds(steps * timeForStep);
            DateTime res = input.Add(timeHome);
            Console.WriteLine("Time Arrival: " + res.ToString("HH:mm:ss"));
        }

        public static void SoftuniKaraoke()
        {
            List<string> participants = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> availableSongs = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToList();
            var result = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (!(input.Equals("dawn")))
            {
                string[] info = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string performer = info[0].Trim();
                string song = info[1].Trim();
                string award = info[2].Trim();
                if (!(participants.Contains(performer)) || !(availableSongs.Contains(song)))
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (!(result.ContainsKey(performer)))
                {
                    result[performer] = new List<string>();
                }
                if (result[performer].Contains(award))
                {
                    input = Console.ReadLine();
                    continue;
                }
                result[performer].Add(award);


                input = Console.ReadLine();
            }

            if (result.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            var final = result.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var performer in final.Keys)
            {
                Console.WriteLine($"{performer}: {final[performer].Count} awards");
                final[performer].Sort();
                for (int i = 0; i < final[performer].Count; i++)
                {
                    Console.WriteLine($"--{final[performer][i]}");
                }
            }
        }

        public static void WinningTicket()
        {

            string[] tickets = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                string firstHalf = tickets[i].Substring(0, 10);
                string secondHalf = tickets[i].Substring(10);

                if (Regex.IsMatch(firstHalf, @"(\$+)|(\^+)|(\@+)|(\#+)") && Regex.IsMatch(secondHalf, @"(\$+)|(\^+)|(\@+)|(\#+)"))
                {
                    Match f = Regex.Match(firstHalf, @"(\$+)|(\^+)|(\@+)|(\#+)");
                    Match s = Regex.Match(secondHalf, @"(\$+)|(\^+)|(\@+)|(\#+)");
                    bool found = false;
                    if (f.Value.Length > 5 && s.Value.Length > 5 && (f.Value.Length < 10 && s.Value.Length < 10))
                    {
                        if ((Regex.IsMatch(f.Value, @"\@{6,}") && Regex.IsMatch(s.Value, @"\@{6,}")) ||
                           (Regex.IsMatch(f.Value, @"\${6,}") && Regex.IsMatch(s.Value, @"\${6,}")) ||
                           (Regex.IsMatch(f.Value, @"\^{6,}") && Regex.IsMatch(s.Value, @"\^{6,}")) ||
                           (Regex.IsMatch(f.Value, @"\#{6,}") && Regex.IsMatch(s.Value, @"\#{6,}")))
                        {
                            found = true;
                            Console.WriteLine($"ticket \"{tickets[i]}\" - {Math.Min(f.Value.Length, s.Value.Length)}{f.Value[0]}");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{tickets[i]}\" - no match");

                        }
                    }
                    else if (f.Value.Length == 10 && s.Value.Length == 10)
                    {
                        if ((Regex.IsMatch(f.Value, @"\@{6,}") && Regex.IsMatch(s.Value, @"\@{6,}")) ||
                           (Regex.IsMatch(f.Value, @"\${6,}") && Regex.IsMatch(s.Value, @"\${6,}")) ||
                           (Regex.IsMatch(f.Value, @"\^{6,}") && Regex.IsMatch(s.Value, @"\^{6,}")) ||
                           (Regex.IsMatch(f.Value, @"\#{6,}") && Regex.IsMatch(s.Value, @"\#{6,}")))
                        {
                            found = true;
                            Console.WriteLine($"ticket \"{tickets[i]}\" - {Math.Min(f.Value.Length, s.Value.Length)}{f.Value[0]} Jackpot!");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
                    }
                }
                else
                    Console.WriteLine($"ticket \"{tickets[i]}\" - no match");
            }
        }

        public static void EnduranceRally()
        {
            var racerFuel = new Dictionary<string, decimal>();
            var racerZone = new Dictionary<string, long>();
            string[] participants = Console.ReadLine().Split(' ');
            decimal[] zones = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            long[] checkpoints = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            for (int i = 0; i < participants.Length; i++)
            {
                racerFuel[participants[i]] = (int)participants[i][0];
                racerZone[participants[i]] = 0;
            }

            for (int i = 0; i < participants.Length; i++)
            {
                for (int j = 0; j < zones.Length; j++)
                {
                    if (checkpoints.Contains(j))
                    {
                        racerFuel[participants[i]] += zones[j];
                    }
                    else
                    {
                        racerFuel[participants[i]] -= zones[j];
                        if (racerFuel[participants[i]] <= 0)
                        {
                            racerZone[participants[i]] = j;
                            break;
                        }
                    }
                }
            }

            foreach (var racer in racerFuel.Keys)
            {
                if (racerFuel[racer] <= 0)
                {
                    Console.WriteLine($"{racer} - reached {racerZone[racer]}");
                }
                else
                {
                    Console.WriteLine("{0} - fuel left {1:F2}", racer, racerFuel[racer]);
                }
            }

        }
    }
}
