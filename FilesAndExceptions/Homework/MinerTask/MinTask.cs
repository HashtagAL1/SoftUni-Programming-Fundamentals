using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinerTask
{
    class MinTask
    {
        static void Main(string[] args)
        {
            try
            {
                File.Delete("output.txt");
                string[] lines = File.ReadAllLines("input.txt");
                var resources = new Dictionary<string, long>();

                for (int i = 0; i < lines.Length; i += 2)
                {
                    if (lines[i].Equals("stop") || lines[i + 1].Equals("stop"))
                    {
                        break;
                    }
                    if (!(resources.ContainsKey(lines[i])))
                    {
                        resources[lines[i]] = 0;
                    }
                    resources[lines[i]] += long.Parse(lines[i + 1]);

                }
                foreach (var res in resources)
                {
                    File.AppendAllText("output.txt", $"{res.Key} -> {res.Value}" + Environment.NewLine);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("No such file exists.");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The input was not in correct format.");
            }
            
        }
    }
}
