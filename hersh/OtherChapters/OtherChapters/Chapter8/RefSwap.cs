using System;

class RefSwap
{
    int a, b;

    public RefSwap(int i, int j)
    {
        a = i;
        b = j;
    }

    public void Show()
    {
        Console.WriteLine("a: {0}, b: {1}", a, b);
    }
    public void Swap( RefSwap ob1,  RefSwap ob2)
    {
        RefSwap t;

        t = ob1;
        ob1 = ob2;
        ob2 = t;
    }
}

class RefSwapDemo
{
    public void run()
    {
        RefSwap x = new RefSwap(1, 2);
        RefSwap y = new RefSwap(3, 4);

        Console.Write("x до вызова: ");
        x.Show();

        Console.Write("y до вызова: ");
        y.Show();

        x.Swap( x,  y);

        Console.Write("x после вызова: ");
        x.Show();

        Console.Write("y после вызова: ");
        y.Show();
    }
}