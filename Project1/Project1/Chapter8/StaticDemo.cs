using System;

class StaticDemo
{
    public static int val = 100;

    public StaticDemo inner;
    public void incrementVal()
    {
        val++;
    }
}

class SDemo
{
    public void run()
    {
        StaticDemo ob = new StaticDemo();
        ob.inner = new StaticDemo();
        ob.inner.incrementVal();

        Console.WriteLine(StaticDemo.val);
    }
}