using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            DragonArmy();
        }

        public static void DragonArmy()
        {
            var dragons = new Dictionary<string, SortedDictionary<string, List<long>>>();
            var typeStats = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                long damage = 45;
                long health = 250;
                long armor = 10;
                string type = input[0];
                string dragonName = input[1];

                if (!(input[2].Equals("null")))
                {
                    damage = long.Parse(input[2]);
                }
                if (!(input[3].Equals("null")))
                {
                    health = long.Parse(input[3]);
                }
                if (!(input[4].Equals("null")))
                {
                    armor = long.Parse(input[4]);
                }

                if (!(dragons.ContainsKey(type)))
                {
                    dragons[type] = new SortedDictionary<string, List<long>>();

                    typeStats[type] = new List<double> { 0, 0, 0 };
                }
                dragons[type][dragonName] = new List<long> { damage, health, armor };
            }

            GetAverageDamage(dragons, typeStats);
            GetAverageHealth(dragons, typeStats);
            GetAverageArmor(dragons, typeStats);

            foreach (var item in typeStats.Keys)
            {
                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", item, typeStats[item].ElementAt(0),
                    typeStats[item].ElementAt(1), typeStats[item].ElementAt(2));
                Output(dragons[item]);
            }
        }

        public static void Output(SortedDictionary<string, List<long>> dict)
        {
            foreach (var dragonName in dict.Keys)
            {

                Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", dragonName,
                    dict[dragonName].ElementAt(0), dict[dragonName].ElementAt(1),
                    dict[dragonName].ElementAt(2));
            }
        }        

        public static void GetAverageDamage(Dictionary<string, SortedDictionary<string, List<long>>> dict,
            Dictionary<string, List<double>> stats)
        {
            foreach (var dragonType in dict.Keys)
            {
                int cnt = 0;
                foreach (var name in dict[dragonType].Keys)
                {
                    stats[dragonType][0] += double.Parse(dict[dragonType][name][0].ToString());
                    cnt++;
                }
                stats[dragonType][0] /= cnt;
            }
            
        }

        public static void GetAverageHealth(Dictionary<string, SortedDictionary<string, List<long>>> dict,
            Dictionary<string, List<double>> stats)
        {
            foreach (var dragonType in dict.Keys)
            {
                int cnt = 0;
                foreach (var name in dict[dragonType].Keys)
                {
                    stats[dragonType][1] += double.Parse(dict[dragonType][name][1].ToString());
                    cnt++;
                }
                stats[dragonType][1] /= cnt;
            }

        }

        public static void GetAverageArmor(Dictionary<string, SortedDictionary<string, List<long>>> dict,
            Dictionary<string, List<double>> stats)
        {
            foreach (var dragonType in dict.Keys)
            {
                int cnt = 0;
                foreach (var name in dict[dragonType].Keys)
                {
                    stats[dragonType][2] += double.Parse(dict[dragonType][name][2].ToString());
                    cnt++;
                }
                stats[dragonType][2] /= cnt;
            }

        }
    }
}
