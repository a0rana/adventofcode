namespace AOC_Day_9;
class Program
{
    static HashSet<(int, int)> visited;

    static void Main(string[] args)
    {
        visited = new HashSet<(int, int)>();

        int knotsCount = 10;

        Knot[] knots = new Knot[knotsCount];

        for (int j = 0; j < knotsCount; j++)
        {
            knots[j] = new Knot();
        }

        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-9-data.txt");

        //start the simulation of movement
        foreach (string line in lines)
        {
            string cmd = line.Split(" ")[0];
            int move = int.Parse(line.Split(" ")[1]);

            int headKnotXDistance = cmd switch { "R" => 1, "L" => -1, _ => 0 };
            int headKnotYDistance = cmd switch { "U" => 1, "D" => -1, _ => 0 };

            while (move > 0)
            {

                knots[0].X += headKnotXDistance;
                knots[0].Y += headKnotYDistance;

                for (int i = 1; i < knots.Length; i++)
                {
                    int diffX = knots[i - 1].X - knots[i].X;
                    int diffY = knots[i - 1].Y - knots[i].Y;
                    if (Math.Abs(diffX) > 1 || Math.Abs(diffY) > 1)
                    {
                        knots[i].X += Math.Sign(diffX);
                        knots[i].Y += Math.Sign(diffY);
                    }
                }
                visited.Add((knots[knots.Length - 1].X, knots[knots.Length - 1].Y));
                move--;
            }
        }

        Console.WriteLine(visited.Count);
    }
}