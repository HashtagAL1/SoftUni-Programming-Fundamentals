using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void MergeFiles()
        {
            string[] firstFile = File.ReadAllLines("FileOneMergeFiles.txt");
            string[] secondFile = File.ReadAllLines("FileTwoMergeFiles.txt");
            for (int i = 0; i < firstFile.Length; i++)
            {
                File.AppendAllText(@"Outputs\MergeFiles.txt", firstFile[i] + "\n");
                File.AppendAllText(@"Outputs\MergeFiles.txt", secondFile[i] + "\n");
            }
        }

        public static void WordCount()
        {
            string[] input = File.ReadAllText("wordsWordCount.txt").ToLower().Split(' ');
            string[] text = File.ReadAllLines("textWordCount.txt");

            var word_ocuurences = new Dictionary<string, int>();

            GetFrequencyOfWords(word_ocuurences, text, input);

            word_ocuurences = word_ocuurences.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            PrintWords(word_ocuurences);
        }

        public static void FolderSize()
        {
            string[] files = Directory.GetFiles("05. Folder Size/TestFolder");
            double sum = 0;
            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                sum += info.Length;
            }
            sum = sum / 1024 / 1024;
            File.WriteAllText(@"Outputs\FolderSize", sum.ToString());
        }

        public static void GetFrequencyOfWords(Dictionary<string, int> word_ocuurrences, string[] text, string[] input)
        {
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (!(word_ocuurrences.ContainsKey(input[j])))
                    {
                        word_ocuurrences[input[j]] = 0;
                    }
                    if (text[i].ToLower().Contains(input[j]))
                    {
                        word_ocuurrences[input[j]]++;
                    }
                }
            }
        }

        public static void PrintWords(Dictionary<string, int> word_ocuurences)
        {
            foreach (var word in word_ocuurences.Keys)
            {
                string output = $"{word} -> {word_ocuurences[word]}\r\n";
                File.AppendAllText(@"Outputs\resultWordCount.txt", output);
            }
        }

        public static void PrintOddLines()
        {
            string[] lines = File.ReadAllLines("InputOddLines.txt");
            string[] oddLines = lines.Where((line, i) => i % 2 == 1).ToArray();
            File.WriteAllLines(@"Outputs\OutputOddLines.txt", oddLines);
        }

        public static void LineNumbers()
        {

            string[] lines = File.ReadAllLines("InputLineNumbers.txt");
            string[] newLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                newLines[i] = (i + 1) + ". " + lines[i];
            }
            File.WriteAllLines(@"Outputs\OutputLineNumbers.txt", newLines);
        }
    }
}
