using System;

class XYCoord
{
    public int x, y;

    public XYCoord() : this(0, 0)
    {
        Console.WriteLine("В конструкторе XYCoord()");
    }
    public XYCoord(XYCoord obj) : this(obj.x, obj.y)
    {
        Console.WriteLine("В конструкторе XYCoord(obj)");
    }
    public XYCoord(int i, int j)
    {
        Console.WriteLine("В конструкторе XYCoord(int, int)");
        x = i;
        y = j;
    }
    public void Show()
    {
        Console.WriteLine("x, y: {0} {1}", x, y);
    }
}

class OverloadConsDemo
{
    public void run()
    {
        XYCoord t1 = new XYCoord();
        XYCoord t2 = new XYCoord(8, 9);
        XYCoord t3 = new XYCoord(t2);
        t1.Show();
        t2.Show();
        t3.Show();
    }
}

