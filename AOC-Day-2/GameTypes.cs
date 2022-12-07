using System;
namespace AOC_Day_2
{
	public class Rock
	{
		int points;
		public Rock()
		{
			points = 1;
		}

		public int GetPoints()
		{
			return this.points;
		}
	}

	public class Paper
	{
		int points;
        public Paper()
        {
            points = 2;
        }

        public int GetPoints()
        {
            return this.points;
        }
    }

	public class Scissor
	{
        int points;
        public Scissor()
        {
            points = 3;
        }

        public int GetPoints()
        {
            return this.points;
        }
    }
}

