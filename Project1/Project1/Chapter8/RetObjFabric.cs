using System;


class MyClassF
{
    int a, b;
    public MyClassF Factory(int i, int j)
    {
        MyClassF t = new MyClassF();
        t.a = i;
        t.b = j;
        return t;
    }
    public void Show() {
        Console.WriteLine("a и b: " + a + " " + b);
    }
}

class MakeObjects
{
    public void run()
    {
        MyClassF ob = new MyClassF();
        int i, j;

        for (i = 0, j = 10; i < 10; i++, j--)
        {
            MyClassF anotherObject = ob.Factory(i, j);
            anotherObject.Show();
        }
    }
}