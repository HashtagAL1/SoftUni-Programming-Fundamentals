using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndexOfLetters
{
    class IndexLetters
    {
        static void Main(string[] args)
        {
            try
            {
                string word = File.ReadAllText("input.txt");
                string output = "";
                for (int i = 0; i < word.Length; i++)
                {
                    output += (word[i] + " -> " + (word[i] - 'a') + Environment.NewLine);
                }
                File.WriteAllText("output.txt", output);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No such file exists.");
            }
        }
        

        
    }
}
