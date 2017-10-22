using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            File.Delete("output.txt");
            try
            {
                string[] lines = File.ReadAllLines("input.txt");
                var people = new Dictionary<string, string>();

                for (int i = 0; i < lines.Length; i += 2)
                {
                    if (lines[i].Equals("stop") || lines[i + 1].Equals("stop"))
                    {
                        break;
                    }

                    string name = lines[i];
                    string email = lines[i + 1];
                    if (email.EndsWith(".uk") || email.EndsWith(".us"))
                    {
                        continue;
                    }
                    people[name] = email;
                }

                foreach (var person in people)
                {
                    string output = $"{person.Key} -> {person.Value}" + Environment.NewLine;
                    File.AppendAllText("output.txt", output);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("No such file exists.");
            }
        }
    }
}
