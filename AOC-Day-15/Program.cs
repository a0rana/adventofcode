namespace AOC_Day_15;
using System.Text.RegularExpressions;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-15-data.txt");
        List<(int sLocX, int sLocY)> sensors = new();
        List<(int bLocX, int bLocY)> beacons = new();
        List<int> dist = new();

        foreach (string line in lines)
        {
            string[] numbers = Regex.Split(line, @"[^0-9|-]+").Where<string>(str => !string.IsNullOrEmpty(str)).ToArray<string>();

            sensors.Add((int.Parse(numbers[0]), int.Parse(numbers[1])));
            beacons.Add((int.Parse(numbers[2]), int.Parse(numbers[3])));
        }

        for (int i = 0; i < sensors.Count; i++)
        {
            dist.Add(GetManhattanDistance(sensors[i], beacons[i]));
        }

        int Y = 2000000;

        List<(int locX, int locY)> intervals = new();

        for (int i = 0; i < sensors.Count; i++)
        {
            int dx = dist[i] - Math.Abs(sensors[i].sLocY - Y);

            if (dx <= 0)
            {
                continue;
            }

            intervals.Add((sensors[i].sLocX - dx, sensors[i].sLocX + dx));
        }

        List<int> allowed_x = new();

        foreach (var beacon in beacons)
        {
            if (beacon.bLocY == Y)
                allowed_x.Add(beacon.bLocX);
        }


        int minX = int.MaxValue;
        int maxX = int.MinValue;

        foreach (var interval in intervals)
        {
            minX = Math.Min(minX, interval.locX);
            maxX = Math.Max(maxX, interval.locY);
        }

        int res = 0;
        for (int i = minX; i <= maxX + 1; i++)
        {
            if (allowed_x.Contains(i))
                continue;

            foreach (var interval in intervals)
            {
                if (interval.locX <= i && i <= interval.locY)
                {
                    res++;
                    break;
                }
            }
        }

        Console.WriteLine(res);

        PartTwo(sensors, dist);
    }

    static int GetManhattanDistance((int locX, int locY) p1, (int locX, int locY) p2)
    {
        return Math.Abs(p1.locX - p2.locX) + Math.Abs(p1.locY - p2.locY);
    }

    static void PartTwo(List<(int sLocX, int sLocY)> sensors, List<int> dist)
    {
        List<int> neg_lines = new();
        List<int> pos_lines = new();

        for (int i = 0; i < sensors.Count; i++)
        {
            int d = dist[i];
            neg_lines.Add(sensors[i].sLocX + sensors[i].sLocY - d);
            neg_lines.Add(sensors[i].sLocX + sensors[i].sLocY + d);
            pos_lines.Add(sensors[i].sLocX - sensors[i].sLocY - d);
            pos_lines.Add(sensors[i].sLocX - sensors[i].sLocY + d);
        }

        int pos = int.MaxValue, neg = int.MaxValue;

        for (int i = 0; i < 2 * sensors.Count; i++)
        {
            for (int j = i + 1; j < 2 * sensors.Count; j++)
            {
                var a = pos_lines[i];
                var b = pos_lines[j];

                if (Math.Abs(a - b) == 2)
                    pos = Math.Min(a, b) + 1;

                a = neg_lines[i];
                b = neg_lines[j];

                if (Math.Abs(a - b) == 2)
                    neg = Math.Min(a, b) + 1;
            }
        }

        int x = (pos + neg) / 2;
        int y = (neg - pos) / 2;

        var bigX = BigInteger.Parse(x.ToString());

        BigInteger ans = bigX * 4000000 + y;
        Console.WriteLine(ans.ToString());
    }
}

