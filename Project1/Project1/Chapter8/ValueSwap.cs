using System;

class ValueSwap
{
    public void Swap(ref int a, ref int b)
    {
        int t;
        t = a;
        a = b;
        b = t;
    }
}
class ValueSwapDemo
{
    public void run()
    {
        ValueSwap ob = new ValueSwap();
        int x = 10, y = 20;
        Console.WriteLine("x и y до вызова: {0} {1}", x, y);
        ob.Swap(ref x, ref y);
        Console.WriteLine("x и y после вызова: {0} {1}", x, y);
    }
}