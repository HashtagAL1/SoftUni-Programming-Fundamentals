using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdvertisementMessage
{
    class AdvMsg
    {
        static void Main(string[] args)
        {
            try
            {
                File.Delete("output.txt");

                string[] lines = File.ReadAllLines("input.txt");
                int n = int.Parse(lines[0]);
                for (int i = 0; i < n; i++)
                {
                    string res = "";
                    for (int j = 1; j < lines.Length; j++)
                    {
                        string[] info = lines[j].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        if (j == lines.Length - 2)
                        {
                            res += info[GetRandomIndex(info)] + " - ";
                        }
                        else
                            res += info[GetRandomIndex(info)] + " ";
                    }
                    File.AppendAllText("output.txt", res + Environment.NewLine);
                }
                

                
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("No such file rxists.");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The input was not in correct format.");
            }
        }

        public static int GetRandomIndex(string[] arr)
        {
            Random rnd = new Random();
            return rnd.Next(0, arr.Length);
        }
    }
}
