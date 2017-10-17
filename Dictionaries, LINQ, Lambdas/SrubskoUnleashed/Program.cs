using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrubskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        

        public static void SrubskoUnleashed()
        {

            var result = new Dictionary<string, Dictionary<string, ulong>>();
            string[] input;
            do
            {
                input = Console.ReadLine().Split(' ');
                if (input[0].Equals("End"))
                {
                    break;
                }
            } while (!(IsAccepted(input)));

            if (input[0].Equals("End"))
            {
                Console.WriteLine();
                return;
            }

            while (!(input[0].Equals("End")))
            {
                string singer = "";
                string venueName = "";
                int marker = 0;
                if (!(IsAccepted(input)))
                {
                    input = Console.ReadLine().Split(' ');
                    continue;
                }

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].Contains('@'))
                    {
                        marker = i;
                        break;
                    }
                    else
                        singer += (input[i] + " ");
                }

                if (!(IsSingerAccepted(singer)))
                {
                    input = Console.ReadLine().Split(' ');
                    continue;
                }

                for (int i = marker; i < input.Length; i++)
                {
                    try
                    {
                        int flag = int.Parse(input[i]);
                        marker = i;
                        break;
                    }
                    catch (System.FormatException sfe)
                    {
                        venueName += input[i] + " ";
                    }
                }                

                if (!(result.ContainsKey(venueName)))
                {
                    result[venueName] = new Dictionary<string, ulong>();
                }

                ulong ticketPrice = ulong.Parse(input[marker]);
                ulong ticketCount = ulong.Parse(input[marker + 1]);

                if (!(result[venueName].ContainsKey(singer)))
                {
                    result[venueName][singer] = 0;
                }

                result[venueName][singer] += (ticketCount * ticketPrice);

                input = Console.ReadLine().Split(' ');
            }

            foreach (var res in result)
            {
                string resKey = res.Key.Remove(0, 1);
                Console.WriteLine(resKey);
                var sorted = res.Value.OrderByDescending(x => x.Value);
                foreach (var item in sorted)
                {
                    Console.WriteLine($"#  {item.Key}-> {item.Value}");
                }
            }
        }

        public static bool IsAccepted(string[] input)
        {
            if (input.Length < 4 || input[0].Contains("@"))
            {
                return false;
            }
            string at = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains('@'))
                {
                    at = input[i];
                    break;
                }
            }
            if (!(at[0].Equals('@')))
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals("@"))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSingerAccepted(string singer)
        {
            if (singer.Contains("@"))
            {
                return false;
            }            
            return true;
        }
    }
}
