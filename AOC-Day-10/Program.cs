namespace AOC_Day_10;
class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-10-data.txt");
        int cycle = 0;
        int registerValue = 1;
        int sum = 0;

        foreach(string line in lines)
        {
            string cmd = line.Split(" ")[0];
            int value = (cmd != "noop") ? int.Parse(line.Split(" ")[1]) : 0;

            cycle++;
            if(cycle % 40 == 20)
            {
                sum += registerValue * cycle;
            }

            if(cmd == "addx")
            {
                cycle++;
                if (cycle % 40 == 20)
                {
                    sum += registerValue * cycle;
                }

                registerValue += value;
            }

        }

        Console.WriteLine(sum);

        PartTwo();
    }

    static void PartTwo()
    {
        int registerValue = 1;
        int cycleX = 0;
        int cycleY = 0;

        bool[,] display = new bool[6, 40];
        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-10-data.txt");

        foreach(string line in lines)
        {
            string cmd = line.Split(" ")[0];
            int value = (cmd != "noop") ? int.Parse(line.Split(" ")[1]) : 0;

            display[cycleY, cycleX] = (cycleX >= registerValue - 1 && cycleX <= registerValue + 1);

            cycleX++;
            if(cycleX == 40)
            {
                cycleX = 0;
                cycleY++;
            }

            if(cmd == "addx")
            {
                display[cycleY, cycleX] = (cycleX >= registerValue - 1 && cycleX <= registerValue + 1);

                cycleX++;
                if (cycleX == 40)
                {
                    cycleX = 0;
                    cycleY++;
                }

                registerValue += value;
            }
        }

        for(int i = 0; i < 6; i++)
        {
            for(int j=0; j<40; j++)
            {
                Console.Write((display[i,j] == true) ? "#" : " ");
            }
            Console.WriteLine();
        }
        
    }
}

