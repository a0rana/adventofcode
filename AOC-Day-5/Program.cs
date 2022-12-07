namespace AOC_Day_5;
class Program
{
    static void Main(string[] args)
    {
        List<List<char>> listOfStacks = new List<List<char>>();
        List<char> temp;
        List<Stack<char>> los = new List<Stack<char>>();
        Stack<char> tempStack;
        int ind = 0;

        string[] lines = File.ReadAllLines("../../../sampleinput/aoc-day-5-data.txt");
        int numOfStacks = (lines[0].Length / 4) + 1;

        while (numOfStacks > 0)
        {
            temp = new List<char>();
            listOfStacks.Add(temp);
            numOfStacks--;
        }

        foreach (string line in lines)
        {
            if (line == String.Empty)
                break;

            char[] arr = line.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (Char.IsLetter(arr[i]))
                {
                    int stackNum = (i / 4);

                    listOfStacks[stackNum].Add(arr[i]);
                }
            }
            ind++;
        }

        //Console.WriteLine(listOfStacks);

        foreach(List<char> list in listOfStacks)
        {
            list.Reverse();
            tempStack = new Stack<char>(list);
            los.Add(tempStack);
        }

        ind++;

        List<List<int>> instructions = new List<List<int>>();
        List<int> tempIns;
        int res = 0;

        for (int i = ind; i < lines.Length; i++)
        {
            string[] inp = lines[i].Split(" ");
            tempIns = new List<int>();

            for (int j=0; j<inp.Length; j++)
            {
                string st = inp[j];
                if (int.TryParse(st, out res))
                {
                    tempIns.Add(res);
                }
            }
            instructions.Add(tempIns);
        }

        foreach (List<int> instruction in instructions)
        {
            int numOfElements = instruction[0];
            int from = instruction[1] - 1;
            int to = instruction[2] - 1;
            List<char> lTemp = new List<char>();

            Stack<char> fromStack = los[from];
            Stack<char> toStack = los[to];

            while(numOfElements > 0)
            {
                lTemp.Add(fromStack.Pop());
                //toStack.Push(fromStack.Pop());
                numOfElements--;
            }

            lTemp.Reverse();
            foreach (char c in lTemp)
                toStack.Push(c);
        }

        string str = "";

        foreach(Stack<char> st in los)
        {
            str += st.Peek();
        }

        Console.WriteLine(str);

    }
}

