namespace AOC_Day_4;
class Program
{
    static void Main(string[] args)
    {
        HashSet<int> set1;
        HashSet<int> set2;
        int cnt = 0;

        string[] lines = File.ReadAllLines("../../../sampleinput/aoc-day-4-data.txt");
        foreach (string line in lines)
        {
            set1 = new HashSet<int>();
            set2 = new HashSet<int>();

            string[] rangeOne = line.Split(",")[0].Split("-");
            string[] rangeTwo = line.Split(",")[1].Split("-");

            int rangeOneStart = int.Parse(rangeOne[0]);
            int rangeOneEnd = int.Parse(rangeOne[1]);

            while (rangeOneStart <= rangeOneEnd)
            {
                set1.Add(rangeOneStart);
                rangeOneStart++;
            }

            int rangeTwoStart = int.Parse(rangeTwo[0]);
            int rangeTwoEnd = int.Parse(rangeTwo[1]);

            while (rangeTwoStart <= rangeTwoEnd)
            {
                set2.Add(rangeTwoStart);
                rangeTwoStart++;
            }

            /*if(set1.IsSupersetOf(set2) || set2.IsSupersetOf(set1))
            {
                cnt++;
            }*/

            if (set1.Overlaps(set2))
            {
                cnt++;
            }
        }
        Console.WriteLine("count is {0}", cnt);
    }
}