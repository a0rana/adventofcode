namespace AOC_Day_1;
class Program
{
    static void Main(string[] args)
    {
        List<Elf> elfs = new List<Elf>();
        long id = 1;
        Elf tempElf = new Elf(id);
        long sum = 0;
        long maxCalorie = -1;
        long maxCalorieElfId = 0;
        List<long> list = new List<long>();

        try
        {
            string[] lines = File.ReadAllLines("../../../sampleinput/aoc-day-1-data.txt");

            foreach(string line in lines)
            {
                if(line == String.Empty)
                {
                    elfs.Add(tempElf);
                    id++;
                    tempElf = new Elf(id);
                }
                else
                {
                    tempElf.SetCalorie(long.Parse(line));
                }
            }

            foreach(Elf elf in elfs)
            {
                sum = 0;

                foreach(long cal in elf.GetCalories())
                {
                    sum += cal;
                }

                list.Add(sum);

                if (sum > maxCalorie)
                {
                    maxCalorie = sum;
                    maxCalorieElfId = elf.GetElfId();
                }
            }

            list.Sort();

            Console.WriteLine("Max calorie: {0}, for Eld id : {1}", maxCalorie, maxCalorieElfId);
            sum = 0;

            for (int i = 0; i < 3; i++)
            {
                sum += list[list.Count - 1 - i];
            }

            Console.WriteLine("Top 3 Elf sum: {0}", sum);
        }
        catch(Exception e)
        {
            Console.WriteLine("Unable to read file: {0} ", e);
        }
    }
}