namespace AOC_Day_6;
class Program
{
    static void Main(string[] args)
    {
        Dictionary<char, int> window = new Dictionary<char, int>();
        string[] lines = File.ReadAllLines("../../../sampleinput/aoc-day-6-data.txt");
        int start = 0;
        int end = 0;
        string str = lines[0];

        while (end < str.Length)
        {
            char ch = str[end];

            if (!window.ContainsKey(ch))
            {
                window[ch] = 1;
            }
            else
            {
                window[ch]++;
            }

            end++;

            while (window[ch] > 1)
            {
                char c2 = str[start];
                window[c2]--;
                start++;
            }

            if(end - start == 14)
            {
                break;
            }
        }

        Console.WriteLine("Marker string is : {0}", str.Substring(start, end - start));
        Console.WriteLine("Position : {0}", end);
    }

    static bool HasUniqueWindow(Dictionary<char, int> window)
    {
        foreach (var kvp in window)
        {
            if (kvp.Value == 0 || kvp.Value > 1)
            {
                return false;
            }
        }
        return true;
    }
}