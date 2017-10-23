using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    class PM
    {
        static void Main(string[] args)
        {
            long power = long.Parse(Console.ReadLine());
            long distance = long.Parse(Console.ReadLine());
            long exhFactor = long.Parse(Console.ReadLine());
            long cnt = 0;
            long temp = power / 2;

            while (power >= distance)
            {
                power -= distance;
                cnt++;
                if (power == temp)
                {
                    if (exhFactor != 0)
                    {
                        power /= exhFactor;
                    }
                }
            }
            Console.WriteLine(power);
            Console.WriteLine(cnt);
        }
    }
}
