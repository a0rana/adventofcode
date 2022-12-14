namespace AOC_Day_14;
class Program
{
    static int tempMaxY, maxY;
    static readonly int GRID_SIZE = 1000;

    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-14-data.txt");
        char[][] grid = CreateGrid(lines);

        //part one
        //Console.WriteLine(GetSandUnits(grid));

        PartTwo(grid);
    }

    static char[][] CreateGrid(string[] lines)
    {
        char[][] grid = new char[GRID_SIZE][];
        for (int i = 0; i < GRID_SIZE; i++)
        {
            grid[i] = new char[GRID_SIZE];
            for (int j = 0; j < GRID_SIZE; j++)
            {
                //set every tile as air
                grid[i][j] = '.';
            }
        }

        foreach (string line in lines)
        {
            string[] arr = line.Split(" -> ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                string p1 = arr[i];
                string p2 = arr[i + 1];

                //x,y coordinates that form the shape of the path,
                //where x represents distance to the right and y represents distance down

                int p1LocX = int.Parse(p1.Split(",")[0]);
                int p1LocY = int.Parse(p1.Split(",")[1]);

                int p2LocX = int.Parse(p2.Split(",")[0]);
                int p2LocY = int.Parse(p2.Split(",")[1]);

                tempMaxY = Math.Max(p1LocY, p2LocY);
                maxY = Math.Max(maxY, tempMaxY);

                int dx = Math.Abs(p1LocX - p2LocX);
                int dy = Math.Abs(p1LocY - p2LocY);

                if (dx == 0 && (p1LocY - p2LocY) < 0)
                {
                    for (int j = p1LocY; j <= p2LocY; j++)
                    {
                        grid[j][p1LocX] = '#';
                    }
                }
                else if (dx == 0 && (p1LocY - p2LocY) > 0)
                {
                    for (int j = p2LocY; j <= p1LocY; j++)
                    {
                        grid[j][p1LocX] = '#';
                    }
                }
                else if (dy == 0 && (p1LocX - p2LocX) < 0)
                {
                    for (int r = p1LocX; r <= p2LocX; r++)
                    {
                        grid[p1LocY][r] = '#';
                    }
                }
                else if (dy == 0 && (p1LocX - p2LocX) > 0)
                {
                    for (int r = p2LocX; r <= p1LocX; r++)
                    {
                        grid[p1LocY][r] = '#';
                    }
                }
            }
        }

        //source of the sand
        grid[0][500] = '+';

        return grid;
    }

    static int GetSandUnitsPartTwo(char[][] grid)
    {
        int sand = 0;

        while (true)
        {
            int[] position = new int[] { 0, 500 };
            bool landed = false;

            while (true)
            {
                if (position[0] == 0 && position[1] == 500 && grid[position[0]][position[1]] == 'o')
                {
                    break;
                }

                if (grid[position[0] + 1][position[1]] == '.')
                {
                    position[0]++;
                }
                else if (grid[position[0] + 1][position[1] - 1] == '.')
                {
                    position[0]++;
                    position[1]--;
                }
                else if (grid[position[0] + 1][position[1] + 1] == '.')
                {
                    position[0]++;
                    position[1]++;
                }
                else
                {
                    grid[position[0]][position[1]] = 'o';
                    landed = true;
                    sand++;
                    break;
                }
            }
            if (landed == false)
                break;
        }
        return sand;
    }

    static int GetSandUnits(char[][] grid)
    {
        int sand = 0;

        while (true)
        {
            int[] position = new int[] { 0, 500 };
            bool landed = false;

            while (true)
            {
                if (position[0] == GRID_SIZE-1)
                {
                    break;
                }

                if (grid[position[0] + 1][position[1]] == '.')
                {
                    position[0]++;
                }
                else if (grid[position[0] + 1][position[1] - 1] == '.')
                {
                    position[0]++;
                    position[1]--;
                }
                else if (grid[position[0] + 1][position[1] + 1] == '.')
                {
                    position[0]++;
                    position[1]++;
                }
                else
                {
                    grid[position[0]][position[1]] = 'o';
                    landed = true;
                    sand++;
                    break;
                }
            }
            if (landed == false)
                break;
        }
        return sand;
    }

    static void PartTwo(char[][] grid)
    {
        maxY = maxY + 2;
        for (int j = 0; j < GRID_SIZE; j++)
        {
            grid[maxY][j] = '#';
        }

        Console.WriteLine(GetSandUnitsPartTwo(grid));
    }
}

