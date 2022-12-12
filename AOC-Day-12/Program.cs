namespace AOC_Day_12;
class Program
{
    static int[] startPos;
    static int[] targetPos;
    static HashSet<(int, int)> visited;
    static List<(int locX, int locY)> aLocations;

    static void Main(string[] args)
    {
        visited = new HashSet<(int, int)>();
        aLocations = new();

        char[][] grid = CreateGrid();
        Console.WriteLine("Part One: ");
        Console.WriteLine(BFS(grid, startPos, targetPos));

        int min = int.MaxValue;
        int steps;
        Console.WriteLine("Part Two: ");
        foreach (var location in aLocations)
        {
            steps = BFS(grid, new int[] { location.locX, location.locY }, targetPos);
            if (steps > -1 && steps < min)
            {
                min = steps;
            }
        }
        Console.WriteLine(min);
    }

    static char[][] CreateGrid()
    {
        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-12-data.txt");
        startPos = new int[2];
        targetPos = new int[2];

        char[][] grid = new char[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            grid[i] = new char[lines[i].Length];

            for (int j = 0; j < lines[i].Length; j++)
            {
                if (lines[i][j] == 'S')
                {
                    startPos[0] = i;
                    startPos[1] = j;
                    grid[i][j] = 'a';
                }
                else if (lines[i][j] == 'E')
                {
                    targetPos[0] = i;
                    targetPos[1] = j;
                    grid[i][j] = 'z';
                }
                else
                {
                    grid[i][j] = lines[i][j];
                }

                //for second part
                if (grid[i][j] == 'a')
                {
                    aLocations.Add((i, j));
                }
            }
        }

        return grid;
    }

    static int BFS(char[][] grid, int[] startPos, int[] targetPos)
    {
        Queue<(int posX, int posY, int steps)> q = new();

        int[][] directions = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };

        q.Enqueue((startPos[0], startPos[1], 0));
        visited.Add((startPos[0], startPos[1]));

        while (q.Count > 0)
        {
            var curr = q.Dequeue();

            if (curr.posX == targetPos[0] && curr.posY == targetPos[1])
                return curr.steps;

            foreach (int[] dir in directions)
            {
                int nextX = curr.posX + dir[0];
                int nextY = curr.posY + dir[1];

                //oob check for the next co-ordinate
                if (nextX < 0 || nextX >= grid.Length || nextY < 0 || nextY >= grid[0].Length)
                    continue;

                //diff should not be more than 1 and shouldn't be visited
                if ((grid[nextX][nextY] - grid[curr.posX][curr.posY] <= 1) && visited.Add((nextX, nextY)))
                {
                    q.Enqueue((nextX, nextY, curr.steps + 1));
                }
            }
        }
        visited.Clear();
        return -1;
    }
}

