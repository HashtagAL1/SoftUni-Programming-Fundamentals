using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChange
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double threshHold = double.Parse(Console.ReadLine());
            double prevPrice = double.Parse(Console.ReadLine());


            for (int i = 0; i < n - 1; i++)
            {
                double currentPrice = double.Parse(Console.ReadLine());
                double percentagePriceChange = GetPercentage(prevPrice, currentPrice);
                bool isSignificantDifference = SignDiff(percentagePriceChange, threshHold);
                string message = GetMessage(currentPrice, prevPrice, percentagePriceChange, isSignificantDifference);
                Console.WriteLine(message);
                prevPrice = currentPrice;
            }
        }

        private static string GetMessage(double currentPrice, double prevPrice, double difference, bool significantDif)
        {
            string to = "";
            if (difference == 0)
            {
                to = string.Format("NO CHANGE: {0}", currentPrice);
            }
            else if (!significantDif)
            {
                to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", prevPrice, currentPrice, difference * 100);
            }
            else if (significantDif && (difference > 0))
            {
                to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", prevPrice, currentPrice, difference * 100);
            }
            else if (significantDif && (difference < 0))
                to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", prevPrice, currentPrice, difference * 100);

            return to;
        }
        private static bool SignDiff(double threshHold, double changePercentage)
        {
            if (Math.Abs(threshHold) >= changePercentage)
            {
                return true;
            }

            return false;
        }

        private static double GetPercentage(double prevPrice, double currentPrice)
        {
            double percentage = (currentPrice - prevPrice) / prevPrice;
            return percentage;
        }
    }
}
