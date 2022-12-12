using System;
using System.Numerics;

namespace AOC_Day_11
{
    public class Monkey
    {
        List<long> items;
        long divisor;
        char action;
        long operand;
        Monkey trueMonkey;
        Monkey falseMonkey;
        bool self;
        long inspected;
        long gcd;

        public Monkey(long[] arr, long div, char act, long op, bool isSelfOperand, long g)
        {
            items = new List<long>(arr);
            divisor = div;
            action = act;
            operand = op;
            self = isSelfOperand;
            inspected = 0;
            gcd = g;
        }

        public Monkey SetTrueConditionMonkey
        {
            set { this.trueMonkey = value; }
        }

        public Monkey SetFalseConditionMonkey
        {
            set { this.falseMonkey = value; }
        }

        private void SendIfFalse(long item)
        {
            falseMonkey.Items.Add(item);
        }

        private void SendIfTrue(long item)
        {
            trueMonkey.Items.Add(item);
        }

        public List<long> Items
        {
            get { return this.items; }
        }

        public long Inspected
        {
            get { return this.inspected; }
        }

        private void TestClause(long val)
        {
            if (val % divisor == 0)
            {
                SendIfTrue(val);
            }
            else
            {
                SendIfFalse(val);
            }
        }

        public void PerformAction()
        {
            foreach (long item in items)
            {
                long temp = Calculate(item) % gcd;
                
                TestClause(temp);
                inspected++;
            }

            items.Clear();
        }

        private long Calculate(long val)
        {
            if (self)
            {
                operand = val;
            }

            switch (action)
            {
                case '+':
                    return val + operand;
                case '-':
                    return val - operand;
                case '*':
                    return val * operand;
                case '/':
                    return val / operand;
                default:
                    return 0;
            }
        }
    }
}

