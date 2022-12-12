namespace AOC_Day_11;

using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        long gcd = 17 * 7 * 13 * 2 * 19 * 3 * 5 * 11;

        Monkey zero = new Monkey(new long[] { 89, 74 }, 17, '*', 5, false, gcd);
        Monkey one = new Monkey(new long[] { 75, 69, 87, 57, 84, 90, 66, 50 }, 7, '+', 3, false, gcd);
        Monkey two = new Monkey(new long[] { 55 }, 13, '+', 7, false, gcd);
        Monkey three = new Monkey(new long[] { 69, 82, 69, 56, 68 }, 2, '+', 5, false, gcd);
        Monkey four = new Monkey(new long[] { 72, 97, 50 }, 19, '+', 2, false, gcd);
        Monkey five = new Monkey(new long[] { 90, 84, 56, 92, 91, 91 }, 3, '*', 19, false, gcd);
        Monkey six = new Monkey(new long[] { 63, 93, 55, 53 }, 5, '*', int.MinValue, true, gcd);
        Monkey seven = new Monkey(new long[] { 50, 61, 52, 58, 86, 68, 97 }, 11, '+', 4, false, gcd);

        zero.SetTrueConditionMonkey = four;
        zero.SetFalseConditionMonkey = seven;

        one.SetTrueConditionMonkey = three;
        one.SetFalseConditionMonkey = two;

        two.SetTrueConditionMonkey = zero;
        two.SetFalseConditionMonkey = seven;

        three.SetTrueConditionMonkey = zero;
        three.SetFalseConditionMonkey = two;

        four.SetTrueConditionMonkey = six;
        four.SetFalseConditionMonkey = five;

        five.SetTrueConditionMonkey = six;
        five.SetFalseConditionMonkey = one;

        six.SetTrueConditionMonkey = three;
        six.SetFalseConditionMonkey = one;

        seven.SetTrueConditionMonkey = five;
        seven.SetFalseConditionMonkey = four;


        for (int i = 0; i < 10000; i++)
        {
            zero.PerformAction();
            one.PerformAction();
            two.PerformAction();
            three.PerformAction();
            four.PerformAction();
            five.PerformAction();
            six.PerformAction();
            seven.PerformAction();
        }

        List<long> inspectedItems = new List<long>();

        inspectedItems.Add(zero.Inspected);
        inspectedItems.Add(one.Inspected);
        inspectedItems.Add(two.Inspected);
        inspectedItems.Add(three.Inspected);
        inspectedItems.Add(four.Inspected);
        inspectedItems.Add(five.Inspected);
        inspectedItems.Add(six.Inspected);
        inspectedItems.Add(seven.Inspected);

        inspectedItems.Sort();

        BigInteger mul = BigInteger.Multiply(BigInteger.Parse(inspectedItems[inspectedItems.Count - 1].ToString()), BigInteger.Parse(inspectedItems[inspectedItems.Count - 2].ToString()));

        Console.WriteLine(mul.ToString());
    }
}