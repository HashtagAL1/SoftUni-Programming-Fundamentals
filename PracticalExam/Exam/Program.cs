using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static BigInteger GetMaxSizeDataset(List<DataSet> list)
        {
            BigInteger maxSize = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].DataSetSize >= maxSize)
                {
                    maxSize = list[i].DataSetSize;
                }
            }
            return maxSize;
        }

        public static int GetIndexOfDataset(List<DataSet> list, string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static void Divide(List<string> list, int start, int parts)
        {
            string target = list[start];
            StringBuilder sb = new StringBuilder();
            
            if (target.Length % parts == 0)
            {
                int len = target.Length / parts;
                int j = 0;
                for (int i = 0, k = 1; i < parts; i++, k++)
                {
                    for (int m = j; m < len * k; m++)
                    {
                        sb.Append(target[m]);
                    }
                    j += len;
                    string res = sb.ToString();
                    sb.Clear();
                    if (i == 0)
                    {
                        list[start] = res;
                    }
                    else if (start == list.Count - 1)
                    {
                        list.Add(res);
                    }
                    else
                    {
                        list.Insert(start + i, res);
                    }
                }
            }
            else
            {
                int len = target.Length / parts;
                int rest = target.Length % parts;
                if (len == 1)
                {
                    rest++;
                }
                else
                {
                    rest = target.Length - ((len - 1) * parts);
                    len--;
                }
                int j = 0;
                int flag = 0;
                for (int i = 0, k = 1; i < parts - 1; i++, k++)
                {
                    for (int m = j; m < len * k; m++)
                    {
                        sb.Append(target[m]);
                    }
                    j += len;
                    string res = sb.ToString();
                    sb.Clear();
                    if (i == 0)
                    {
                        list[start] = res;
                    }
                    else if (start == list.Count - 1)
                    {
                        list.Add(res);
                    }
                    else
                    {
                        list.Insert(start + i, res);
                    }
                    flag = i;
                }
                for (int l = j; l < target.Length; l++)
                {
                    sb.Append(target[l]);
                }
                string resu = sb.ToString();
                if (start + flag >= list.Count)
                {
                    list.Add(resu);
                }
                else
                {
                    list.Insert(start + flag + 1, resu);
                }
            }
        }        

        public static void Merge(List<string> list, int start, int end)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                sb.Append(list[i]);
                
            }
            for (int i = start + 1, cnt = 0; cnt < end - start; cnt++)
            {
                list.RemoveAt(i);
            }
            list[start] = sb.ToString();
        }

        public static void AnonymousDownsites()
        {
            decimal loss = 0.0m;
            List<string> websites = new List<string>();
            int numberOfWebsites = int.Parse(Console.ReadLine());
            int key = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"^([^ ]+) (\d+) (\d+(\.\d+)?)$");

            for (int i = 0; i < numberOfWebsites; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                string website = match.Groups[1].Value;
                uint siteVisits = uint.Parse(match.Groups[2].Value);
                decimal pricePerVisit = decimal.Parse(match.Groups[3].Value);


                websites.Add(website);
                loss += (siteVisits * pricePerVisit);
            }
            BigInteger securityToken = BigInteger.Pow(key, numberOfWebsites);
            for (int i = 0; i < websites.Count; i++)
            {
                Console.WriteLine(websites[i]);
            }
            Console.WriteLine("Total Loss: {0:F20}", loss);
            Console.WriteLine($"Security Token: {securityToken}");

        }

        public static void AnonynmousThreat()
        {
            List<string> list = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (!(input.Equals("3:1")))
            {
                string[] info = input.Split(' ');
                int startIndex = int.Parse(info[1]);                

                if (info[0].Equals("merge"))
                {
                    int endIndex = int.Parse(info[2]);
                    if (startIndex < 0 || startIndex >= list.Count)
                    {
                        startIndex = 0;
                    }
                    if (endIndex >= list.Count || endIndex < 0)
                    {
                        endIndex = list.Count - 1;
                    }
                    Merge(list, startIndex, endIndex);
                }
                else if (info[0].Equals("divide"))
                {
                    int partitions = int.Parse(info[2]);
                    
                    Divide(list, startIndex, partitions);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        public static void AnonymousVox()
        {
            string input = Console.ReadLine();
            string placeholders = Console.ReadLine();
            Regex text = new Regex(@"(?<startEnd>[A-Za-z]+)(?<toBeReplaced>.*)\1");
            Regex placeholderRegex = new Regex(@"((?<=\{).*?(?=\}))");
            List<string> realPlaceholders = new List<string>();
            foreach (Match m in placeholderRegex.Matches(placeholders))
            {
                realPlaceholders.Add(m.Value);
            }
            int i = 0;
            foreach (Match m in text.Matches(input))
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder res = new StringBuilder();
                res.Append(input);
                sb.Append(m.Groups[1].Value);
                sb.Append(realPlaceholders[i]);
                sb.Append(m.Groups[1].Value);
                res.Replace(m.Value, sb.ToString());
                input = res.ToString();
                i++;
            }
            Console.WriteLine(input);
        }

        public static void AnonymousCache()
        {
            List<DataSet> cache = new List<DataSet>();
            List<DataSet> result = new List<DataSet>();
            Regex datasetOnly = new Regex(@"^[^ \-\+\>\|]+$");
            Regex fullInfo = new Regex(@"^(?<datakey>[^ \-\+\>\|]+)( -> )(?<size>\d+)( \| )(?<dataset>[^ \-\+\>\|]+)$");
            string input = Console.ReadLine();

            while (!(input.Equals("thetinggoesskrra")))
            {
                if (datasetOnly.IsMatch(input))
                {
                    int index = GetIndexOfDataset(result, input);
                    if (index == -1)
                    {
                        int flag = GetIndexOfDataset(cache, input);
                        if (flag == -1)
                        {
                            DataSet data = new DataSet(input);
                            result.Add(data);
                        }
                        else
                        {
                            result.Add(cache[flag]);
                        }
                    }

                }
                else if (fullInfo.IsMatch(input))
                {
                    string name = fullInfo.Match(input).Groups["dataset"].Value;
                    string key = fullInfo.Match(input).Groups["datakey"].Value;
                    BigInteger size = BigInteger.Parse(fullInfo.Match(input).Groups["size"].Value);
                    int index = GetIndexOfDataset(result, name);
                    if (index == -1)
                    {
                        int flag = GetIndexOfDataset(cache, name);
                        if (flag == -1)
                        {
                            DataSet data = new DataSet(name);
                            data.KeySize[key] = size;
                            data.DataSetSize = size;
                            cache.Add(data);
                        }
                        else
                        {
                            cache[flag].DataSetSize += size;
                            if (cache[flag].KeySize.ContainsKey(key))
                            {
                                cache[flag].KeySize[key] += size;
                            }
                            else
                            {
                                cache[flag].KeySize[key] = size;
                            }
                            result.Add(cache[flag]);
                            cache.RemoveAt(flag);
                        }
                    }
                    else
                    {
                        result[index].DataSetSize += size;
                        if (result[index].KeySize.ContainsKey(key))
                        {
                            result[index].KeySize[key] += size;
                        }
                        else
                            result[index].KeySize[key] = size;
                    }
                }

                input = Console.ReadLine();
            }

            BigInteger maxsize = GetMaxSizeDataset(result);

            for (int i = 0; i < result.Count; i++)
            {
                if (maxsize == result[i].DataSetSize)
                {
                    Console.WriteLine($"Data Set: {result[i].Name}, Total Size: {result[i].DataSetSize}");
                    foreach (var key in result[i].KeySize.Keys)
                    {
                        Console.WriteLine($"$.{key}");
                    }
                }
            }
        }
    }
}


public class DataSet
{
    public string Name { get; set; }
    public Dictionary<string, BigInteger> KeySize { get; set; }
    public BigInteger DataSetSize { get; set; }

    public DataSet(string name)
    {
        this.Name = name;
        KeySize = new Dictionary<string, BigInteger>();
        this.DataSetSize = 0;
    }

    

}
