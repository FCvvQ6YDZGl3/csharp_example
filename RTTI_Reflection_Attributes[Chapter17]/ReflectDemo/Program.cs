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
        x = a;
        y = b;
    }

    public void Set(double a, double b)
    {
        x = (int)a;
        y = (int)b;
    }

    public void Show()
    {
        Console.WriteLine(" x: {0}, y: {1}", x, y);
    }
}

namespace ReflectDemo
{
    class Program
    {
        static void Main()
        {
            Type t = typeof(MyClass);

            Console.WriteLine("Анализ методов, определенных в классе " + t.Name);
            Console.WriteLine();

            Console.WriteLine("Поддерживаемые методы: ");

            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            foreach (MethodInfo m in mi)
            {
                Console.Write(" " + m.ReturnType.Name + " " + m.Name + "(");

                ParameterInfo[] pi = m.GetParameters();
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }
                Console.WriteLine(")");

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
