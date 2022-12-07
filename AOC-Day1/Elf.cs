using System;
namespace AOC_Day1
{
	public class Elf
	{
		long elfId;
		List<long> calories;

		public Elf(long id)
		{
			elfId = id;
			calories = new List<long>();
		}

		public List<long> GetCalories()
		{
			return this.calories;
		}

        public void SetCalorie(long cal)
        {
			this.calories.Add(cal);
        }

        public long GetElfId()
        {
            return this.elfId;
        }
    }
}

