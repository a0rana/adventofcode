namespace AOC_Day_13;

using System.Text.Json.Nodes;


public enum Ordering
{
    VALID,
    INVALID,
    CHECKFURTHER
}

class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("../../../sampleinput/aoc-day-13-data.txt");
        int id = 0;
        List<int> rightPair = new();
        List<JsonNode> nodes = new();
        JsonNode left, right;

        for (int i = 0; i < lines.Length - 1; i += 3)
        {
            id++;

            left = JsonNode.Parse(lines[i]);
            right = JsonNode.Parse(lines[i + 1]);

            nodes.Add(left);
            nodes.Add(right);

            if (IsRightPair(left, right) == Ordering.VALID)
            {
                rightPair.Add(id);
            }
        }

        nodes.Add(JsonNode.Parse("[[2]]"));
        nodes.Add(JsonNode.Parse("[[6]]"));

        Console.WriteLine(rightPair.Sum());

        nodes.Sort((x, y) => IsRightPair(x, y).CompareTo(IsRightPair(y, x)));

        int ind = 1;
        int total = 1;
        foreach (JsonNode node in nodes)
        {
            if (node.AsArray().Count == 1 && node.AsArray()[0] is JsonArray && node.AsArray()[0].AsArray().Count == 1 && node.AsArray()[0].AsArray()[0] is JsonValue && (node.AsArray()[0].AsArray()[0].GetValue<int>() == 2 || node.AsArray()[0].AsArray()[0].GetValue<int>() == 6))
            {
                total *= ind;
            }
            ind++;
        }
        Console.WriteLine(total);
    }

    static Ordering IsRightPair(JsonNode left, JsonNode right)
    {
        //both are integers
        if (left is JsonValue && right is JsonValue)
        {
            int leftFirstValue = left.GetValue<int>();
            int rightFirstValue = right.GetValue<int>();

            //If the left integer is higher than the right integer, the inputs are not in the right order
            if (leftFirstValue > rightFirstValue)
            {
                return Ordering.INVALID;
            }
            else if (leftFirstValue < rightFirstValue)
            {
                return Ordering.VALID;
            }
            else
            {
                return Ordering.CHECKFURTHER;
            }
        }

        //both are lists
        if (left is JsonArray && right is JsonArray)
        {
            int minLength = Math.Min(left.AsArray().Count, right.AsArray().Count);
            for (int i = 0; i < minLength; i++)
            {
                Ordering retValue = IsRightPair(left.AsArray()[i], right.AsArray()[i]);
                if (retValue != Ordering.CHECKFURTHER)
                    return retValue;
            }

            if (left.AsArray().Count < right.AsArray().Count)
            {
                return Ordering.VALID;
            }
            // If the right list runs out of items first, the inputs are not in the right order
            else if (left.AsArray().Count > right.AsArray().Count)
            {
                return Ordering.INVALID;
            }

            return Ordering.CHECKFURTHER;
        }
        //if exactly one value is an integer
        else if (left is JsonValue && right is JsonArray)
        {
            return IsRightPair(JsonNode.Parse("[" + left.GetValue<int>() + "]"), right);
        }
        //if exactly one value is an integer
        else
        {
            return IsRightPair(left, JsonNode.Parse("[" + right.GetValue<int>() + "]"));
        }
    }
}