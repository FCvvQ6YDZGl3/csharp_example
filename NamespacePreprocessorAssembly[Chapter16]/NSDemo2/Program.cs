using System;

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

namespace Counter2
{
    class CountDown
    {
        public void Count()
        {
            Console.WriteLine("Это метод Count() из пространство имен Counter2.");
        }
    }
}

class NSDemo2
{
    static void Main()
    {
        Counter.CountDown cd1 = new Counter.CountDown(10);

        Counter2.CountDown cd2 = new Counter2.CountDown();
        int i;

        do
        {
            i = cd1.Count();
            Console.Write(i + " ");
        } while (i > 0);
        Console.WriteLine();

        cd2.Count();
        Console.ReadKey();
    }
}