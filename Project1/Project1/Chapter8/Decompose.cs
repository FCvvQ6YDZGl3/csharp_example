using System;

class Decompose
{
    public int GetParts(double n, out double frac)
    {
        int whole;

        whole = (int)n;
        frac = n - whole;
        return whole;
    }
}

class UseOut
{
    public void run()
    {
        Decompose ob = new Decompose();
        int i;
        double f;

        i = ob.GetParts(10.125, out f);

        Console.WriteLine("Целая часть числа равна {0}", i);
        Console.WriteLine("Дробная часть числа равна {0}", f);
    }
}