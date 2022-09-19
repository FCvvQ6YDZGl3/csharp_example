using System;

using Counter;
using AnotherCounter;

using Ctr = Counter;
namespace Counter
{
    class CountDown
    {
        int val;

        public CountDown(int n)
        {
            val = n;
        }

        public void Reset(int n)
        {
            val = n;
        }
        public int Count()
        {
            if (val > 0) return val--;
            else return 0;
        }
    }
}

namespace AnotherCounter
{
    class CountDown
    {
        int val;

        public CountDown(int n)
        {
            val = n;
        }

        public void Reset(int n)
        {
            val = n;
        }
        public int Count()
        {
            if (val > 0) return val--;
            else return 0;
        }
    }
}

class WhyAliasQualifier
{
    static void Main()
    {
        int i;
        Ctr::CountDown cd1 = new Ctr::CountDown(10);
        Ctr.CountDown cd2 = new Ctr.CountDown(10);
        Console.ReadKey();
    }

}