using System.Linq;

namespace AOC_Day_3;
class Program
{
    static void Main(string[] args)
    {
        Dictionary<char, int> lCaseMap = new Dictionary<char, int>();
        Dictionary<char, int> uCaseMap = new Dictionary<char, int>();
        int val = 1;
        

        for (char i = 'a'; i <= 'z'; i++)
        {
            lCaseMap[i] = val;
            val++;
        }

        val = 27;

        for (char i = 'A'; i <= 'Z'; i++)
        {
            uCaseMap[i] = val;
            val++;
        }

        Console.WriteLine("First part sum is : {0}", GetSumForPartOne(lCaseMap, uCaseMap));
        Console.WriteLine("Second part sum is : {0}", GetSumForParTwo(lCaseMap, uCaseMap));
    }

    static long GetSumForPartOne(Dictionary<char, int> lCaseMap, Dictionary<char, int> uCaseMap)
    {
        long sum = 0;
        int val = 0;

        string[] lines = File.ReadAllLines("../../../sampleinput/aoc-day-3-data.txt");
        foreach (string line in lines)
        {
            val = 0;
            string str1 = line.Substring(0, line.Length / 2);
            string str2 = line.Substring(line.Length / 2, line.Length / 2);

            char ch = FindCommonChar(str1, str2);

            if (lCaseMap.ContainsKey(ch))
            {
                val = lCaseMap[ch];
            }
            else if (uCaseMap.ContainsKey(ch))
            {
                val = uCaseMap[ch];
            }

            sum += val;
        }
        return sum;
    }

    static long GetSumForParTwo(Dictionary<char, int> lCaseMap, Dictionary<char, int> uCaseMap)
    {
        long sum = 0;
        int val = 0;

        string[] lines = File.ReadAllLines("../../../sampleinput/aoc-day-3-secondpart-data.txt");
        for(int i=3; i<=lines.Length; i += 3)
        {
            string str1 = lines[i - 3];
            string str2 = lines[i - 2];
            string str3 = lines[i - 1];

            char ch = FindCommonChar(str1, str2, str3);

            if (ch != ' ')
            {
                if (lCaseMap.ContainsKey(ch))
                {
                    val = lCaseMap[ch];
                }
                else if (uCaseMap.ContainsKey(ch))
                {
                    val = uCaseMap[ch];
                }

                sum += val;
            }
        }
        return sum;
    }

    static char FindCommonChar(string firstComp, string secondComp)
    {
        Dictionary<char, bool> map = new Dictionary<char, bool>();

        for (int i = 0; i < firstComp.Length; i++)
        {
            if (!map.ContainsKey(firstComp[i]))
            {
                map[firstComp[i]] = true;
            }
        }

        foreach(char ch in secondComp)
        {
            if (map.ContainsKey(ch))
            {
                return ch;
            }
        }

        return ' ';
    }

    static char FindCommonChar(string firstComp, string secondComp, string thirdComp)
    {
        Dictionary<char, bool> map = new Dictionary<char, bool>();
        Dictionary<char, bool> mapTwo = new Dictionary<char, bool>();

        for (int i = 0; i < firstComp.Length; i++)
        {
            if (!map.ContainsKey(firstComp[i]))
            {
                map[firstComp[i]] = true;
            }
        }

        for (int i = 0; i < thirdComp.Length; i++)
        {
            if (!mapTwo.ContainsKey(thirdComp[i]))
            {
                mapTwo[thirdComp[i]] = true;
            }
        }

        foreach (char ch in secondComp)
        {
            if (map.ContainsKey(ch) && mapTwo.ContainsKey(ch))
            {
                return ch;
            }
        }

        return ' ';
    }
}