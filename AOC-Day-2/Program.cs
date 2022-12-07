using System.Reflection;

namespace AOC_Day_2;
class Program
{
    static void Main(string[] args)
    {
        long myscore = 0;
        long shapeScore = 0;
        long total = 0;

        string[] lines = File.ReadAllLines("../../../sampleinput/aoc-day-2-data.txt");
        foreach(string line in lines)
        {
            myscore = 0;
            shapeScore = 0;

            string opponentMove = line.Split(" ")[0];
            string myMove = line.Split(" ")[1];

            if(myMove == "X")
            {
                shapeScore = 1;
            }
            else if(myMove == "Y")
            {
                shapeScore = 2;
            }
            else
            {
                shapeScore = 3;
            }

            //draw
            if((opponentMove == "A" && myMove == "X") || (opponentMove == "B" && myMove == "Y") || (opponentMove == "C" && myMove == "Z"))
            {
                myscore = 3; 
            }
            else if((opponentMove == "A" && myMove == "Y") || (opponentMove == "C" && myMove == "X") || (opponentMove == "B" && myMove == "Z")) //won
            {
                myscore = 6;
            }
            else //lost
            {
                myscore = 0;
            }

            total += shapeScore + myscore;
        }

        Console.WriteLine("first game, result: {0}", total);
        total = 0;

        foreach (string line in lines)
        {
            myscore = 0;
            shapeScore = 0;

            string opponentMove = line.Split(" ")[0];
            string myMove = line.Split(" ")[1];

            if (myMove == "X")
            {
                myscore = 0;
            }
            else if (myMove == "Y")
            {
                myscore = 3;
            }
            else
            {
                myscore = 6;
            }

            if (myMove == "Y") //do a draw
            {
                if (opponentMove == "A")
                {
                    shapeScore = 1;
                }
                else if (opponentMove == "B")
                {
                    shapeScore = 2;
                }
                else
                {
                    shapeScore = 3;
                }
            }
            else if(myMove == "X") //need to loose
            {
                //opponent has a rock and I need to loose
                if (opponentMove == "A")
                {
                    //need a scissor
                    shapeScore = 3;
                }
                else if (opponentMove == "B") //oppponent has a paper
                {
                    //use a rock
                    shapeScore = 1;
                }
                else //opponent has a scissor
                {
                    //use a paper
                    shapeScore = 2;
                }
            }
            else //need to win
            {
                if (opponentMove == "A")
                {
                    shapeScore = 2;
                }
                else if (opponentMove == "B")
                {
                    shapeScore = 3;
                }
                else
                {
                    shapeScore = 1;
                }
            }

            total += shapeScore + myscore;
        }

        Console.WriteLine("second game, result: {0}", total);
    }
}

