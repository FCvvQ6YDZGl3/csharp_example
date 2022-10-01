using System;
using System.Reflection;

class MyClass
{
    int x;
    int y;

    public MyClass(int i, int j)
    {
        x = i;
        y = j;
    }

    public int Sum()
    {
        return x + y;
    }
    public bool IsBetween(int i)
    {
        if (x < i && i < y) return true;
        else return false;
    }

    public void Set(int a, int b)
    {
        Console.Write("В методе Set(int, int). ");

        x = a;
        y = b;
        Show();
    }

    public void Set(double a, double b)
    {
        Console.Write("В методе Set(double, double). ");
        x = (int)a;
        y = (int)b;
        Show();
    }
    public void Show()
    {
        Console.WriteLine("Значение x: {0}, значение y: {1}", x, y);
    }
}

namespace InvokeMethDemo
{
    class Program
    {
        static void Main()
        {
            Type t = typeof(MyClass);
            MyClass reflectOb = new MyClass(10, 20);
            int val;

            Console.WriteLine("Вызов методов, определенных в классе " + t.Name);
            Console.WriteLine();

            MethodInfo[] mi = t.GetMethods();

            foreach(MethodInfo m in mi)
            {
                ParameterInfo[] pi = m.GetParameters();

                if (m.Name.CompareTo("Set") == 0 &&
                    pi[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Set") == 0 &&
                    pi[0].ParameterType == typeof(double))
                {
                    object[] args = new object[2];
                    args[0] = 1.12;
                    args[1] = 23.4;
                    m.Invoke(reflectOb, args);
                }
                else if (m.Name.CompareTo("Sum") == 0)
                {
                    val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine("Сумма равна " + val);
                }
                else if (m.Name.CompareTo("IsBetween") == 0)
                {
                    object[] args = new object[1];
                    args[0] = 14;
                    if ((bool)m.Invoke(reflectOb, args))
                        Console.WriteLine("Значения 14 находится между x и y");
                }
                else if (m.Name.CompareTo("Show") == 0)
                {
                    m.Invoke(reflectOb, null);
                }
            }
            Console.ReadKey();
        }
    }
}
