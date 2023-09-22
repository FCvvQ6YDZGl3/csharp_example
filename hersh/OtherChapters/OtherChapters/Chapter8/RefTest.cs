using System;

class RefTest
{
    public void Sqr(ref int i)
    {
        i = i * i;
    }
}
class RefDemo
{
    public void run()
    {
        RefTest ob = new RefTest();
        int a = 10;
        Console.WriteLine("a до вызова: " + a);
        ob.Sqr(ref a);
        Console.WriteLine("a после вызова: {0}", a);
    }
}