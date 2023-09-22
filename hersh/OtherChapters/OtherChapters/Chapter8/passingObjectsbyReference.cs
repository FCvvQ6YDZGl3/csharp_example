using System;

class MyClass
{
    int alpha, beta;

    public MyClass(int i, int j)
    {
        alpha = i;
        beta = j;
    }

    public bool SameAs(MyClass ob)
    {
        return (ob.alpha == alpha) && (ob.beta == beta);
    }

    public void Copy(MyClass ob)
    {
        alpha = ob.alpha;
        beta = ob.beta;
    }

    public void Show()
    {
        Console.WriteLine("alpha: {0}, beta: {1}", alpha, beta);
    }
}

class PassOb
{
    public void run()
    {
        MyClass ob1 = new MyClass(4, 5);
        MyClass ob2 = new MyClass(6, 7);

        Console.Write("ob1: ");
        ob1.Show();

        Console.Write("ob2: ");
        ob2.Show();

        string output;
        if (ob1.SameAs(ob2))
            output = "ob1 и ob2 имеют одинаковые значения.";
        else
            output = "ob1 и ob2 имеют разные значения.";

        Console.WriteLine(output);
        Console.WriteLine();

        ob1.Copy(ob2);

        output = "ob1 после копирования: ";
        Console.WriteLine(output);
        ob1.Show();

        if (ob1.SameAs(ob2))
            output = "ob1 и ob2 имеют одинаковые значения.";
        else
            output = "ob1 и ob2 имеют разные значения.";

        Console.WriteLine(output);
        Console.WriteLine();
    }
}