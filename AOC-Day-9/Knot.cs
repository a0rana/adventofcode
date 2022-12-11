using System;
namespace AOC_Day_9
{
	public class Knot
	{
		int x;
		int y;

		public Knot()
		{
			x = 0;
			y = 0;
		}

		public int X
		{
			get { return x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return y; }
            set { this.y = value; }
        }
    }
}

